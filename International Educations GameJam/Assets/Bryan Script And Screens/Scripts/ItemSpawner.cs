using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject m_ItemToSpawn;

    public int amount_of_Items_toSpawn;

    public Vector3 PosOfTheTransform;
    public Vector3 Size;

    private int ItemsCreated;

    void Awake()
    {
        // spawns in the Prefabs on startup
        for (int i = 0; i < amount_of_Items_toSpawn; i++)
        {
            SpawnItemOnGround();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnItemOnGround()
    {
        // makes a gird where he is able to spawn a prefab
        Vector3 Pos = PosOfTheTransform + new Vector3(Random.Range(-Size.x / 2, Size.x / 2), Random.Range(-Size.y / 2, Size.y / 2), Random.Range(-Size.z / 2, Size.z / 2));
        GameObject NewItem = Instantiate(m_ItemToSpawn, Pos, Quaternion.identity);
        NewItem.name = "Items " + ItemsCreated;
        ItemsCreated++;
    }



    private void OnDrawGizmosSelected()
    {
        // draws the spawning grid
        Gizmos.color = new Color(255, 0, 0);
        Gizmos.DrawCube(PosOfTheTransform, Size);
    }
}
