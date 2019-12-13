using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] orangeSpawnersArray;
    public GameObject[] blueSpawnersArray;

    // Start is called before the first frame update
    void Start()
    {
        orangeSpawnersArray = GameObject.FindGameObjectsWithTag("OrangeSpawners");
        blueSpawnersArray = GameObject.FindGameObjectsWithTag("BlueSpawners");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
