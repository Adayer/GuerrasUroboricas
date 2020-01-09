using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GameObject[] myTurrets;
    public GameObject currentTurret;

    public GameObject tipoDeTorre1;
    public GameObject tipoDeTorre2;

    GameManager gm;
    float currentDamage;

    float currenetHP;

    int ronda;
    // Start is called before the first frame update
    void Start()
    {
        myTurrets = GameObject.FindGameObjectsWithTag("BlueSpawners");
        currentTurret = myTurrets[0];
        gm = FindObjectOfType<GameManager>();

        currenetHP = 10;

    }

    // Update is called once per frame
    void Update()
    {
        print(currenetHP);
        
        if (gm.canInteract == true)
        {

        }
        else
        {
            print("wait");
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            gm.player1Ready = true;
        }
    }

    public void SelectTurrert()
    {
        ronda = gm.CurrentRoundFunc();

        myTurrets[ronda] = currentTurret;
        myTurrets[ronda].SetActive(true);

    }

    public float GetDamage()
    {
        for (int i = 0; i < myTurrets.Length; i++)
        {
            if (myTurrets[i] == tipoDeTorre1)
            { currentDamage += 1; }

            if (myTurrets[i] == tipoDeTorre2)
            { currentDamage += 1; }

            else
            {
                currentDamage += 0;
            }

        }
        return currentDamage;
    }

    public void ApplyDamage(float damage)
    {
        currenetHP -= damage;
    }
}
