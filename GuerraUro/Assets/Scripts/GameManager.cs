using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] orangeSpawnersArray;
    public GameObject[] blueSpawnersArray;
    public int ronda;

    public bool player1Ready;
    public bool player2Ready;

    Player1 player1;
    Player2 player2;


    float currentTimer;
    float maxTimer = 120.0f;

    float currentTimer2;
    float maxTimer2 = 4.0f;

    public bool canInteract;
    // Start is called before the first frame update
    void Start()
    {

        ronda = 0;
        orangeSpawnersArray = GameObject.FindGameObjectsWithTag("OrangeSpawners");
        blueSpawnersArray = GameObject.FindGameObjectsWithTag("BlueSpawners");
        player1 = FindObjectOfType<Player1>();
        player2 = FindObjectOfType<Player2>();


        for (int i = 0; i < orangeSpawnersArray.Length; i++)
        {
            orangeSpawnersArray[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < blueSpawnersArray.Length; i++)
        {
            blueSpawnersArray[i].gameObject.SetActive(false);
        }
        currentTimer = -1;
        currentTimer2 = maxTimer2;
        canInteract = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer2 -= Time.deltaTime;
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;

        }
        if (currentTimer2 > 0)
        {

        }
        print(currentTimer2);


        if (currentTimer2 <= 0)
        {
                canInteract = true;
                player1.SelectTurrert();
                player2.SelectTurrert();

                currentTimer = maxTimer;

        }

        if (currentTimer <= 0 ||( (player1Ready == true && player2Ready == true) && canInteract == true))
        {
                print("me cago en tu puta madre");
                player1.ApplyDamage(player2.GetDamage());
                player2.ApplyDamage(player1.GetDamage());

                ronda += 1;
                currentTimer2 = maxTimer2;
                canInteract = false;
        }


    }

    public int CurrentRoundFunc()
    {
        return ronda;
    }
}
