using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMage : TowerBase
{
	[SerializeField] private float m_minDamage = 0f;
	[SerializeField] private float m_maxDamage = 0f;

	public override void TowerAct()
	{
		if (!m_p1IsOwner)
		{
			for (int i = 0; i < RoundController.Instance.P1.P1BuiltTowers.Count; i++)
			{
				if(RoundController.Instance.P1.P1BuiltTowers[RoundController.Instance.P1.P1BuiltTowers.Count - i - 1].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Dead)
				{
					RoundController.Instance.P1.P1BuiltTowers[RoundController.Instance.P1.P1BuiltTowers.Count - i - 1].GetComponent<TowerBase>().DealDamage(Random.Range(m_minDamage, m_maxDamage));
					break;
				}
			}
			
		}
		else
		{
			for (int i = 0; i < RoundController.Instance.P2.P2BuiltTowers.Count; i++)
			{
				if (RoundController.Instance.P2.P2BuiltTowers[RoundController.Instance.P2.P2BuiltTowers.Count - i - 1].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Dead)
				{
					RoundController.Instance.P2.P2BuiltTowers[RoundController.Instance.P2.P2BuiltTowers.Count - i - 1].GetComponent<TowerBase>().DealDamage(Random.Range(m_minDamage, m_maxDamage));
					break;
				}
			}
			
		}
	}
}
