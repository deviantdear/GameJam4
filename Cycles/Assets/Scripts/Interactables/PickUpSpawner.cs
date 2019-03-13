using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public List<Transform> prefabToSpawn;
    private int pick;
    public int numPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numPrefabs; i++)
        {
            for (int j = 0; j < numPrefabs; j++)
            {
                float xpos = transform.position.x + i * 5;
                float zpos = transform.position.z + j * 5;
                pick = Random.Range(0, prefabToSpawn.Count);
                Object instanceObj = Instantiate(prefabToSpawn[pick], new Vector3(xpos, 0.85f, zpos), Quaternion.identity);
            }
        }
    }

}
