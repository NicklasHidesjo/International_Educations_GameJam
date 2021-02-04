using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] List<Item> items = new List<Item>();

    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject InGameScreen;

    [SerializeField] GameUIDisplayer gameUIDisplayer;

    [SerializeField] bool dead = false;
    [SerializeField] private bool allowedToMove = false;

    private SoundScript soundScript;

    private AudioSource audioSource;
    public bool AllowedToMove { get { return allowedToMove; } }

    private void Awake()
    {
        soundScript = FindObjectOfType<SoundScript>();
        audioSource = FindObjectOfType<AudioSource>();
    }

    public void StartGame()
    {
        allowedToMove = true;

        startScreen.SetActive(false);

        InGameScreen.SetActive(true);

        soundScript.source.Stop();

        soundScript.PlayMusic(1, 0.5f);
    }

    private void WonGame()
    {
        InGameScreen.SetActive(false);
        winScreen.SetActive(true);
        allowedToMove = false;
    }

    public void GameOver()
    {
        InGameScreen.SetActive(false);
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

        foreach (ItemType itemType in ItemType.GetValues(typeof(ItemType)))
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
