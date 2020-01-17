using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFlamethrower : TowerBase
{

	[SerializeField] private float m_minDamage = 0f;
	[SerializeField] private float m_maxDamage = 0f;

	public override void TowerAct()
	{
		if (!m_p1IsOwner)
		{
			for (int i = 0; i < RoundController.Instance.P1.P1BuiltTowers.Count; i++)
			{
				if (RoundController.Instance.P1.P1BuiltTowers[i].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Dead)
				{
					RoundController.Instance.P1.P1BuiltTowers[i].GetComponent<TowerBase>().DealDamage(Random.Range(m_minDamage, m_maxDamage));
					if(i < RoundController.Instance.P1.P1BuiltTowers.Count - 1)
					{
						for (int j = i + 1; j < RoundController.Instance.P1.P1BuiltTowers.Count; j++)
						{
							if (RoundController.Instance.P1.P1BuiltTowers[j].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Dead)
							{
								RoundController.Instance.P1.P1BuiltTowers[j].GetComponent<TowerBase>().DealDamage(Random.Range(m_minDamage, m_maxDamage));
								break;
							}
						}
					}
					break;
				}
			}

		}
		else
		{
			for (int i = 0; i < RoundController.Instance.P2.P2BuiltTowers.Count; i++)
			{
				if (RoundController.Instance.P2.P2BuiltTowers[i].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Dead)
				{
					RoundController.Instance.P2.P2BuiltTowers[i].GetComponent<TowerBase>().DealDamage(Random.Range(m_minDamage, m_maxDamage));
					if (i < RoundController.Instance.P2.P2BuiltTowers.Count - 1)
					{
						for (int j = i + 1; j < RoundController.Instance.P2.P2BuiltTowers.Count; j++)
						{
							if (RoundController.Instance.P2.P2BuiltTowers[j].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Dead)
							{
								RoundController.Instance.P2.P2BuiltTowers[j].GetComponent<TowerBase>().DealDamage(Random.Range(m_minDamage, m_maxDamage));
								break;
							}
						}
					}
					break;
				}
			}

		}
	}
}

