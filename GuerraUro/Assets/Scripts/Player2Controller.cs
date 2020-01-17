using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

	[SerializeField] private GameObject[] m_slots;

	[SerializeField] private GameObject[] m_r1Towers = null;
	[SerializeField] private GameObject[] m_r2Towers = null;
	[SerializeField] private GameObject[] m_r3Towers = null;

	private GameObject[] m_towersRound;
	private int m_currentTowerIndex = 0;

	private List<GameObject> m_p2BuiltTowers = new List<GameObject>(0);

	private bool m_hasBuilt = false;

	[SerializeField] private GameObject m_currentAttackIndicatorGO = null;
	[SerializeField] private GameObject m_currentBuildingIndicatorGO = null;

	public List<GameObject> P2BuiltTowers { get => m_p2BuiltTowers; set => m_p2BuiltTowers = value; }

	private void Start()
	{
		m_towersRound = m_r1Towers;
		for (int i = 0; i < m_slots.Length; i++)
		{
			m_slots[i].SetActive(false);
		}
		m_slots[1].SetActive(false);
		for (int i = 0; i < m_towersRound.Length; i++)
		{
			m_towersRound[i].transform.position = m_slots[0].transform.position;
			if(i != 0)
			{
				m_towersRound[i].SetActive(false);
			}
		}
	}

	private void Update()
	{
		if (RoundController.Instance.CurrentRoundState == RoundState.Building && !m_hasBuilt)
		{
			if (Input.GetKeyDown(KeyCode.K))
			{
				m_currentTowerIndex--;
				if (m_currentTowerIndex < 0)
				{
					m_currentTowerIndex = m_towersRound.Length - 1;
				}
				ChangeActiveTower();
			}
			else if (Input.GetKeyDown(KeyCode.L))
			{
				m_currentTowerIndex++;
				if (m_currentTowerIndex >= m_towersRound.Length)
				{
					m_currentTowerIndex = 0;
				}
				ChangeActiveTower();
			}
			if (Input.GetKeyDown(KeyCode.Backspace))
			{
				Build();
			}
		}

	}

	void Build()
	{
		if (!m_hasBuilt)
		{
			m_hasBuilt = true;

			GameObject newTower = Instantiate(m_towersRound[m_currentTowerIndex], m_slots[RoundController.Instance.CurrentRound].transform.position, Quaternion.identity);
			m_p2BuiltTowers.Add(newTower);
			
			newTower.GetComponent<TowerBase>().P1IsOwner = false;

			for (int i = 0; i < m_towersRound.Length; i++)
			{
				m_towersRound[i].SetActive(false);
			}
			RoundController.Instance.P2HasBuilt();
		}
	}

	public void ForceBuild()
	{
		if (!m_hasBuilt)
		{
			ToggleBuildingIndicator(false);
			m_hasBuilt = true;

			GameObject newTower = Instantiate(m_towersRound[m_currentTowerIndex], m_slots[RoundController.Instance.CurrentRound].transform.position, Quaternion.identity);
			m_p2BuiltTowers.Add(newTower);
			
			newTower.GetComponent<TowerBase>().P1IsOwner = false;

			for (int i = 0; i < m_towersRound.Length; i++)
			{
				m_towersRound[i].SetActive(false);
			}
		}
	}

	void ChangeActiveTower()
	{
		for (int i = 0; i < m_towersRound.Length; i++)
		{
			if (m_currentTowerIndex == i)
			{
				m_towersRound[i].SetActive(true);
			}
			else
			{
				m_towersRound[i].SetActive(false);
			}
		}
	}

	public void NextRound()
	{
		m_hasBuilt = false;
		m_slots[RoundController.Instance.CurrentRound].SetActive(true);

		for (int i = 0; i < m_towersRound.Length; i++)
		{
			m_towersRound[i].transform.position = m_slots[RoundController.Instance.CurrentRound].transform.position;

			if (m_currentTowerIndex == i)
			{
				m_towersRound[i].SetActive(true);
			}
			else
			{
				m_towersRound[i].SetActive(false);
			}
		}

		for (int i = 0; i < m_p2BuiltTowers.Count; i++)
		{
			if (m_p2BuiltTowers[i].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Dead)
			{
				m_p2BuiltTowers[i].GetComponent<TowerBase>().CurrentTowerState = TowerStates.Good;
			}
		}

	}

	public void TowerAct(int towerIndex)
	{
		m_p2BuiltTowers[towerIndex].GetComponent<TowerBase>().TowerAct();
	}

	public void EndTurn()
	{
		List<GameObject> auxList = RoundController.Instance.P1.AuxListForRoundChange;

		for (int i = 0; i < auxList.Count; i++)
		{
			auxList[i].transform.position = m_slots[i].transform.position;
			auxList[i].GetComponent<TowerBase>().P1IsOwner = false;
			auxList[i].GetComponent<TowerBase>().Heal();
			auxList[i].GetComponent<SpriteRenderer>().flipX = true;
		}
		m_p2BuiltTowers = auxList;

		if (RoundController.Instance.CurrentTurn == 1)
		{
			m_towersRound = m_r2Towers;
		}
		if (RoundController.Instance.CurrentTurn == 2)
		{
			m_towersRound = m_r3Towers;
		}

		NextRound();
	}

	public void UpdateAttackIndicator(int index)
	{
		m_currentAttackIndicatorGO.transform.position = m_slots[index].transform.position;
	}
	public void ToggleAttackIndicator(bool toggle)
	{
		m_currentAttackIndicatorGO.SetActive(toggle);
	}

	public void UpdateBuildingIndicator(int index)
	{
		m_currentBuildingIndicatorGO.transform.position = m_slots[index].transform.position;
	}
	public void ToggleBuildingIndicator(bool toggle)
	{
		m_currentBuildingIndicatorGO.SetActive(toggle);
	}
}
