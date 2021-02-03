using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] List<Item> items = new List<Item>();
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject winScreen;

    [SerializeField] bool dead = false;

    [SerializeField] private bool allowedToMove = false;

    public bool AllowedToMove { get { return allowedToMove; } }

    public void StartGame()
    {
        allowedToMove = true;

        startScreen.SetActive(false);
    }

    private void WonGame()
    {
        Debug.Log("all items found. We won");

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

        foreach (ItemType itemType in /*(ItemType[])*/ItemType.GetValues(typeof(ItemType)))
        {
            bool matchFound = false;
            Debug.Log(itemType);
            foreach (var item in items)
            {
                if (matchFound)
                {
                    continue;
                }

                if (item.Type == itemType)
                {
                    Debug.Log("match found for " + item.Type);

                    matchFound = true;
                }
            }

            if (!matchFound)
            {
                allItemsMatched = false;
                Debug.Log("no match found");
                break;
            }
        }

        if (allItemsMatched)
        {
            WonGame();
        }
    }
}
