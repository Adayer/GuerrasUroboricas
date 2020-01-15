using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public GameObject[] myTurrets;
    public GameObject currentTurret;

    public GameObject tipoDeTorre1;
    public GameObject tipoDeTorre2;


    RoundManagement rm;

    GameManager gm;
    float currentDamage;

    float currenetHP;
    bool canInteract = true;

    int ronda;
    // Start is called before the first frame update
    void Start()
    {
        myTurrets =  GameObject.FindGameObjectsWithTag("OrangeSpawners");

        gm = FindObjectOfType<GameManager>();
        rm = FindObjectOfType<RoundManagement>();

        currenetHP = 10;

    }

    private void Awake()
    {
        currentTurret = myTurrets[0];
    }

    // Update is called once per frame
    void Update()
    {
        //print(currenetHP);
        print("can interact" + canInteract);
        if (canInteract == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                print("W");
            }
            SelectTurrert();
        }
        else
        {
            print("wait");
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            gm.player1Ready = true;
        }
    }

    public void SelectTurrert()
    {
        ronda = rm.CurrentRoundFunc();

        myTurrets[ronda] = currentTurret;
        myTurrets[ronda].SetActive(true);

    }

    public float GetDamage()
    {
        for (int i = 0; i < myTurrets.Length; i++)
        {
            if(myTurrets[i] == tipoDeTorre1)
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
    public void SetInteraction(bool interactable)
    {
        canInteract = interactable;
    }
}
