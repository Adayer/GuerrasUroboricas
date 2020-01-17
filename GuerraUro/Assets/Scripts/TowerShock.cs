using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShock : TowerBase
{

	int objective = 0;

	public override void TowerAct()
	{
		if (!m_p1IsOwner)
		{
			objective = Random.Range(0, RoundController.Instance.CurrentRound + 1);
			while(RoundController.Instance.P1.P1BuiltTowers[objective].GetComponent<TowerBase>().CurrentTowerState == TowerStates.Stunned || RoundController.Instance.P1.P1BuiltTowers[objective].GetComponent<TowerBase>().CurrentTowerState == TowerStates.Dead)
			{
				objective = Random.Range(0, RoundController.Instance.CurrentRound + 1);
			}
			RoundController.Instance.P1.P1BuiltTowers[objective].GetComponent<TowerBase>().Shock();
		}
		else
		{

			objective = Random.Range(0, RoundController.Instance.CurrentRound + 1);
			while (RoundController.Instance.P2.P2BuiltTowers[objective].GetComponent<TowerBase>().CurrentTowerState == TowerStates.Shielded || RoundController.Instance.P2.P2BuiltTowers[objective].GetComponent<TowerBase>().CurrentTowerState == TowerStates.Dead)
			{
				objective = Random.Range(0, RoundController.Instance.CurrentRound + 1);
			}
			RoundController.Instance.P2.P2BuiltTowers[objective].GetComponent<TowerBase>().Shock();
		}
	}
}
