using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealing : TowerBase
{
	[SerializeField] private float m_minHeal = 0f;
	[SerializeField] private float m_maxHeal = 0f;

	int objective = 0;

	public override void TowerAct()
	{
		if (m_p1IsOwner)
		{
			objective = Random.Range(0, RoundController.Instance.CurrentRound + 1);
			RoundController.Instance.P1.P1BuiltTowers[objective].GetComponent<TowerBase>().HealAmount(Random.Range(m_minHeal, m_maxHeal));
		}
		else
		{

			objective = Random.Range(0, RoundController.Instance.CurrentRound + 1);
			
			RoundController.Instance.P2.P2BuiltTowers[objective].GetComponent<TowerBase>().HealAmount(Random.Range(m_minHeal, m_maxHeal));
		}
	}
}
