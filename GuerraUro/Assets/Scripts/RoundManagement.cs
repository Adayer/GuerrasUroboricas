using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManagement : MonoBehaviour
{
    //public GameObject[] orangeSpawnersArray;
    //public GameObject[] blueSpawnersArray;

    //public float cur_cooldown = 0f;
    //float max_cooldwon = 30f;

    //public float cur_Attackcooldown = 0f;
    //float max_Attackcooldwon = 3f;

    //public int currentRound = 0;

    //Player1 player1;
    //Player2 player2;



    //public enum RoundsSM
    //{
    //    Building,
    //    Attacking,
    //    EndGame
    //}

    //public RoundsSM m_currentMode = RoundsSM.Building;

    //private void Start()
    //{
    //    player1 = FindObjectOfType<Player1>();
    //    player2 = FindObjectOfType<Player2>();

    //    orangeSpawnersArray = GameObject.FindGameObjectsWithTag("OrangeSpawners");
    //    blueSpawnersArray = GameObject.FindGameObjectsWithTag("BlueSpawners");
    //    for (int i = 0; i < orangeSpawnersArray.Length; i++)
    //    {
    //        orangeSpawnersArray[i].gameObject.SetActive(false);
    //    }

    //    for (int i = 0; i < blueSpawnersArray.Length; i++)
    //    {
    //        blueSpawnersArray[i].gameObject.SetActive(false);
    //    }
    //    blueSpawnersArray[0].gameObject.SetActive(false);
    //    orangeSpawnersArray[0].gameObject.SetActive(false);
    //}

    //void Update()
    //{
    //    Debug.Log("kk " + m_currentMode + " " + currentRound);
    //    switch (m_currentMode)
    //    {
    //        case RoundsSM.Building:
    //            CoolDown();
    //            player1.SetInteraction(true);
    //            player2.SetInteraction(true);
    //            break;
    //        case RoundsSM.Attacking:
    //            player1.SetInteraction(false);
    //            player2.SetInteraction(false);
    //            CoolDownAttack();
    //            player1.ApplyDamage(player2.GetDamage());
    //            player2.ApplyDamage(player1.GetDamage());
    //            break;
    //        case RoundsSM.EndGame:
    //            break;
    //    }
    //}

    //void CoolDown()
    //{
    //    cur_cooldown = cur_cooldown + Time.deltaTime;
    //    if(cur_cooldown >= max_cooldwon)
    //    {
    //        cur_cooldown = 0;
    //        m_currentMode = RoundsSM.Attacking;

    //    }
    //}
    //void CoolDownAttack()
    //{
    //    cur_Attackcooldown = cur_Attackcooldown + Time.deltaTime;
    //    if (cur_Attackcooldown >= max_Attackcooldwon)
    //    {
    //        cur_Attackcooldown = 0;
    //        m_currentMode = RoundsSM.Building;
    //        currentRound = currentRound + 1;
    //    }
    //}
    //public int CurrentRoundFunc()
    //{
    //    return currentRound;
    //}
}


