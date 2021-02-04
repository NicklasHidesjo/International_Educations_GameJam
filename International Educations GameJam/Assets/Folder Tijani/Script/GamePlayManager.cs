using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] List<Item> items = new List<Item>();

    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject winScreen;

    [SerializeField] GameUIDisplayer gameUIDisplayer;

    [SerializeField] bool dead = false;
    [SerializeField] private bool allowedToMove = false;

    private SoundScript soundScript;

    private AudioSource audioSource;
    public bool AllowedToMove { get { return allowedToMove; } }

    private void Awake()
    {
        gameUIDisplayer = FindObjectOfType<GameUIDisplayer>();

        soundScript = FindObjectOfType<SoundScript>();

        audioSource = FindObjectOfType<AudioSource>();
    }

    public void StartGame()
    {
        allowedToMove = true;

        startScreen.SetActive(false);

        /*audioSource.clip = */
        
        soundScript.source.Stop();

        soundScript.PlayMusic(1, 1f);


        //soundScript.PlayMusic(1);
    }

    private void WonGame()
    {
        winScreen.SetActive(true);
        allowedToMove = false;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);

        allowedToMove = false;
    }

    private void Update()
    {
        if (dead)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ItemPickupTracker(Item pickedUp)
    {
        bool allItemsMatched = true;

        items.Add(pickedUp);

        gameUIDisplayer.SetPickUpText(pickedUp.Type);

        foreach (ItemType itemType in /*(ItemType[])*/ItemType.GetValues(typeof(ItemType)))
        {
            bool matchFound = false;
            foreach (var item in items)
            {
                if (matchFound) continue;
                if (item.Type == itemType)
                {
                    matchFound = true;
                }
            }

            if (!matchFound)
            {
                allItemsMatched = false;
                break;
            }
        }

        if (allItemsMatched)
        {
            WonGame();
        }
    }
}
