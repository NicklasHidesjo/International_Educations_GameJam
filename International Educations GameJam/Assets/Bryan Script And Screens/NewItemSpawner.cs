using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewItemSpawner : MonoBehaviour
{
    [SerializeField] List<Transform> m_SpawnPoints = new List<Transform>();
    [SerializeField] Item[] m_ItemsToSpawn = new Item[0];


    void Start()
    {



        foreach (var items in m_ItemsToSpawn)
        {
            if(m_SpawnPoints.Count < 1)
            {
                Debug.LogWarning("Not Enough spawnpoints " + m_SpawnPoints.Count);
                break;
            }

            int Index;
            Index = Random.Range(0, m_SpawnPoints.Count);

            Instantiate(items, m_SpawnPoints[Index].position, Quaternion.identity);

            m_SpawnPoints.RemoveAt(Index);

            
            

        }
    }
}
