using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMortar : TowerBase
{
	[SerializeField] private float m_minDamage = 0f;
	[SerializeField] private float m_maxDamage = 0f;

	int objective = 0;

	public override void TowerAct()
	{
		if (!m_p1IsOwner)
		{
			objective = Random.Range(1, RoundController.Instance.CurrentRound);

			RoundController.Instance.P1.P1BuiltTowers[objective + 1].GetComponent<TowerBase>().DealDamage(Random.Range(m_minDamage, m_maxDamage));
			RoundController.Instance.P1.P1BuiltTowers[objective - 1].GetComponent<TowerBase>().DealDamage(Random.Range(m_minDamage, m_maxDamage));
			RoundController.Instance.P1.P1BuiltTowers[objective].GetComponent<TowerBase>().DealDamage(Random.Range(m_minDamage, m_maxDamage));
		}
		else
		{

			objective = Random.Range(1, RoundController.Instance.CurrentRound);
			

			RoundController.Instance.P2.P2BuiltTowers[objective + 1].GetComponent<TowerBase>().DealDamage(Random.Range(m_minDamage, m_maxDamage));
			RoundController.Instance.P2.P2BuiltTowers[objective - 1].GetComponent<TowerBase>().DealDamage(Random.Range(m_minDamage, m_maxDamage));
			RoundController.Instance.P2.P2BuiltTowers[objective].GetComponent<TowerBase>().DealDamage(Random.Range(m_minDamage, m_maxDamage));
		}
	}
}
