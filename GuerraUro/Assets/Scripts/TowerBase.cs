using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBase : MonoBehaviour
{

	[SerializeField] protected Image m_lifeBar = null;
	[SerializeField] private TowerCategory m_towerCategory = TowerCategory.Offense;

	private TowerStates m_currentTowerState = TowerStates.Good;

	protected bool m_p1IsOwner = false;

	[SerializeField] protected float m_maxLife = 0f;
	protected float m_currentLife = 0f;

	public bool P1IsOwner { get => m_p1IsOwner; set => m_p1IsOwner = value; }
	public TowerCategory TowerCategory { get => m_towerCategory; set => m_towerCategory = value; }
	public TowerStates CurrentTowerState { get => m_currentTowerState; set => m_currentTowerState = value; }

	

	private void Start()
	{
		m_currentLife = m_maxLife;
		RoundController.Instance.CheckIfDead += CheckIfDead;
		m_currentTowerState = TowerStates.Good;
	}


	public virtual void TowerAct()
	{

	}

	public void DealDamage(float damage)
	{
		if(m_currentTowerState != TowerStates.Shielded)
		{
			m_currentLife = m_currentLife - damage;
			m_lifeBar.fillAmount = m_currentLife / m_maxLife;
		}
		
	}

	public void Heal()
	{
		
		m_currentLife = m_maxLife;
		m_lifeBar.fillAmount = m_currentLife / m_maxLife;
		m_currentTowerState = TowerStates.Good;
	}
	public void HealAmount(float healAmount)
	{
		m_currentLife = m_currentLife + healAmount;
		m_lifeBar.fillAmount = m_currentLife / m_maxLife;
		if (m_currentLife > m_maxLife)
		{
			m_currentLife = m_maxLife;
		}
		if(m_currentTowerState == TowerStates.Dead)
		{
			m_currentTowerState = TowerStates.Good;
		}
	}
	public void Shield()
	{
		m_currentTowerState = TowerStates.Shielded;
	}
	public void Shock()
	{
		m_currentTowerState = TowerStates.Stunned;
	}

	void CheckIfDead()
	{
		if(m_currentLife <= 0)
		{
			m_currentTowerState = TowerStates.Dead;
		}
	}

	public float CalculateLifePercentage()
	{
		float porcentaje = m_currentLife / m_maxLife;

		return porcentaje;
	}
}
