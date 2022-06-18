using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] ringPrefabs;
    private int ySpawn = 0;
    public int numberOfRings;

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel(numberOfRings);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void CreateLevel(int ringLength)
    {
        for (int i = 0; i < ringLength; i++)
        {
            if (i == 0)
            {
                GameObject startRing = Instantiate(ringPrefabs[i], Vector3.down * ySpawn, transform.rotation);
                startRing.transform.parent = transform;
                ySpawn += 5;
            }

            else if(i == ringLength - 1)
            {
                GameObject finishRing = Instantiate(ringPrefabs[ringPrefabs.Length-1], Vector3.down * ySpawn, transform.rotation);
                finishRing.transform.parent = transform;
                ySpawn += 5;
            }

            else
            {
                int ringIndex = Random.Range(1, ringPrefabs.Length-1);
                GameObject ring = Instantiate(ringPrefabs[ringIndex], Vector3.down * ySpawn, transform.rotation);
                ring.transform.parent = transform;
                ySpawn += 5;
            }

        }

    }
}
