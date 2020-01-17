using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RoundController : TemporalSingleton<RoundController>
{

	public delegate void TowerCheck();

	public event TowerCheck CheckIfDead;



	private RoundState m_currentRoundState = RoundState.None;

	[SerializeField] private Player1Controller m_p1 = null;
	[SerializeField] private Player2Controller m_p2 = null;

	[SerializeField] private float m_timeChoosing = 0f;
	[SerializeField] private float m_timeBetweenAttacks = 0f;

	private float m_currentTimeChoosing = 0f;
	private float m_currentTimeBetweenAttacks = 0f;

	private int m_currentRound = 0;
	private int m_currentTurn = 0;
	private int m_currentActIndex = 0;
	private TowerCategory m_towerPhase = TowerCategory.Utility;
	private bool m_tower1HasActed = false;
	private bool m_tower2HasActed = false;


	private bool m_p1HasBuilt = false;
	private bool m_p2HasBuilt = false;

	private FadeToBlack m_cmpFadeToBlack = null;

	[SerializeField] private TextMeshProUGUI m_scoreText = null;
	private int m_p1Score = 0;
	private int m_p2Score = 0;

	public int CurrentRound { get => m_currentRound; set => m_currentRound = value; }
	public RoundState CurrentRoundState { get => m_currentRoundState; set => m_currentRoundState = value; }
	public Player1Controller P1 { get => m_p1; set => m_p1 = value; }
	public Player2Controller P2 { get => m_p2; set => m_p2 = value; }
	public FadeToBlack CmpFadeToBlack { get => m_cmpFadeToBlack; set => m_cmpFadeToBlack = value; }
	public int CurrentTurn { get => m_currentTurn; set => m_currentTurn = value; }

	public override void Awake()
	{
		base.Awake();
		m_currentTimeChoosing = m_timeChoosing;
		m_currentRound = 0;
	}

	void Update()
	{
		m_scoreText.text = m_p1Score + " - " + m_p2Score;

		if(m_currentRoundState == RoundState.Building)
		{
			m_currentTimeChoosing = m_currentTimeChoosing - Time.deltaTime;
			if(m_currentTimeChoosing <= 0)
			{


				m_p1.ForceBuild();
				m_p2.ForceBuild();

				m_p1.ToggleAttackIndicator(true);
				m_p1.UpdateAttackIndicator(0);
				m_p2.ToggleAttackIndicator(true);
				m_p2.UpdateAttackIndicator(0);


				m_currentActIndex = 0;
				m_currentTimeBetweenAttacks = 0;
				m_currentRoundState = RoundState.Acting;
				m_towerPhase = TowerCategory.Utility;
			}
		}
		else if(m_currentRoundState == RoundState.Acting)
		{
			m_currentTimeBetweenAttacks = m_currentTimeBetweenAttacks - Time.deltaTime;

			switch (m_towerPhase)
			{
				case TowerCategory.Offense:
					{
						if (m_currentTimeBetweenAttacks <= 0)
						{
							if (!m_tower2HasActed && !m_tower1HasActed)
							{
								if (m_p1.P1BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().TowerCategory == TowerCategory.Offense)
								{
									if (m_p1.P1BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Dead && m_p1.P1BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Stunned)
									{
										m_p1.ToggleAttackIndicator(true);
										m_tower1HasActed = true;
										m_p1.UpdateAttackIndicator(m_currentActIndex);
										m_p2.UpdateAttackIndicator(m_currentActIndex);
										m_currentTimeBetweenAttacks = m_timeBetweenAttacks;
									}
								}
								else
								{
									m_p1.ToggleAttackIndicator(false);
								}
								if (m_p2.P2BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().TowerCategory == TowerCategory.Offense)
								{
									if (m_p2.P2BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Dead && m_p2.P2BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Stunned)
									{
										m_p2.ToggleAttackIndicator(true);
										m_tower2HasActed = true;
										m_p1.UpdateAttackIndicator(m_currentActIndex);
										m_p2.UpdateAttackIndicator(m_currentActIndex);
										m_currentTimeBetweenAttacks = m_timeBetweenAttacks;
									}
								}
								else
								{
									m_p2.ToggleAttackIndicator(false);
								}
							}
						}
					}
					break;
				case TowerCategory.Defence:
					{
						if (m_currentTimeBetweenAttacks <= 0)
						{
							if (!m_tower2HasActed && !m_tower1HasActed)
							{
								if (m_p1.P1BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().TowerCategory == TowerCategory.Defence)
								{
									if(m_p1.P1BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Dead && m_p1.P1BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Stunned)
									{
										m_p1.ToggleAttackIndicator(true);
										m_tower1HasActed = true;
										m_p1.UpdateAttackIndicator(m_currentActIndex);
										m_p2.UpdateAttackIndicator(m_currentActIndex);
										m_currentTimeBetweenAttacks = m_timeBetweenAttacks;
									}
								}
								else
								{
									m_p1.ToggleAttackIndicator(false);
								}
								if (m_p2.P2BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().TowerCategory == TowerCategory.Defence)
								{
									if (m_p2.P2BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Dead && m_p2.P2BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Stunned)
									{
										m_p2.ToggleAttackIndicator(true);
										m_tower2HasActed = true;
										m_p1.UpdateAttackIndicator(m_currentActIndex);
										m_p2.UpdateAttackIndicator(m_currentActIndex);
										m_currentTimeBetweenAttacks = m_timeBetweenAttacks;
									}
								}
								else
								{
									m_p2.ToggleAttackIndicator(false);
								}
							}
						}
					}
					break;
				case TowerCategory.Utility:
					{
						if(m_currentTimeBetweenAttacks <= 0)
						{
							if(!m_tower2HasActed  && !m_tower1HasActed)
							{
								if (m_p1.P1BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().TowerCategory == TowerCategory.Utility)
								{
									if (m_p1.P1BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Dead && m_p1.P1BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Stunned)
									{
										m_p1.ToggleAttackIndicator(true);
										m_tower1HasActed = true;
										m_p1.UpdateAttackIndicator(m_currentActIndex);
										m_p2.UpdateAttackIndicator(m_currentActIndex);
										m_currentTimeBetweenAttacks = m_timeBetweenAttacks;
									}
								}
								else
								{
									m_p1.ToggleAttackIndicator(false);
								}

								if (m_p2.P2BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().TowerCategory == TowerCategory.Utility)
								{
									if (m_p2.P2BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Dead && m_p2.P2BuiltTowers[m_currentActIndex].GetComponent<TowerBase>().CurrentTowerState != TowerStates.Stunned)
									{
										m_p2.ToggleAttackIndicator(true);
										m_tower2HasActed = true;
										m_p1.UpdateAttackIndicator(m_currentActIndex);
										m_p2.UpdateAttackIndicator(m_currentActIndex);
										m_currentTimeBetweenAttacks = m_timeBetweenAttacks;
									}
								}
								else
								{
									m_p2.ToggleAttackIndicator(false);
								}
							}
						}
					}
					break;
				default:
					break;
			}

			if (m_tower1HasActed)
			{
				m_p1.ToggleAttackIndicator(true);

			}
			else
			{
				m_p1.ToggleAttackIndicator(false);
			}

			if (m_tower2HasActed)
			{
				m_p2.ToggleAttackIndicator(true);
			}
			else
			{
				m_p2.ToggleAttackIndicator(false);
			}


			if (m_currentTimeBetweenAttacks <= 0)
			{
				if (m_tower1HasActed)
				{
					m_p1.TowerAct(m_currentActIndex);
					m_tower1HasActed = false;
				}

				if (m_tower2HasActed)
				{
					m_p2.TowerAct(m_currentActIndex);
					m_tower2HasActed = false;
				}

				if (!m_tower1HasActed && !m_tower2HasActed)
				{
					m_currentActIndex++;
					CheckIfDead();
				}

				if (m_currentActIndex > m_currentRound)
				{
					

					switch (m_towerPhase)
					{
						case TowerCategory.Offense:
							{
								RoundIsFinished();
							}
							break;
						case TowerCategory.Defence:
							{
								m_currentActIndex = 0;
								m_towerPhase = TowerCategory.Offense;
							}
							break;
						case TowerCategory.Utility:
							{
								m_currentActIndex = 0;
								m_towerPhase = TowerCategory.Defence;
							}
							break;
						default:
							break;
					}
				}
			}

			
		}
	}


	public void P1HasBuilt()
	{
		m_p1.ToggleBuildingIndicator(false);
		m_p1HasBuilt = true;
		if (m_p2HasBuilt)
		{
			m_p1.ToggleAttackIndicator(true);
			m_p1.UpdateAttackIndicator(0);
			m_p2.ToggleAttackIndicator(true);
			m_p2.UpdateAttackIndicator(0);



			m_currentActIndex = 0;
			m_currentTimeBetweenAttacks = 0;
			m_currentRoundState = RoundState.Acting;
			m_towerPhase = TowerCategory.Utility;
		}
	}
	public void P2HasBuilt()
	{
		m_p2.ToggleBuildingIndicator(false);
		m_p2HasBuilt = true;
		if (m_p1HasBuilt)
		{
			m_p1.ToggleAttackIndicator(true);
			m_p1.UpdateAttackIndicator(0);

			m_p2.ToggleAttackIndicator(true);
			m_p2.UpdateAttackIndicator(0);


			m_currentActIndex = 0;
			m_currentTimeBetweenAttacks = 0;
			m_currentRoundState = RoundState.Acting;
			m_towerPhase = TowerCategory.Utility;
		}
	}

	public void RoundIsFinished()
	{
		m_currentRound = m_currentRound + 1;

		m_p1HasBuilt = false;
		m_p2HasBuilt = false;

		m_p1.ToggleAttackIndicator(false);
		m_p2.ToggleAttackIndicator(false);


		if (m_currentRound == 3 || m_currentRound == 6)
		{
			GetRoundWinner();
			m_currentRoundState = RoundState.None;
			m_cmpFadeToBlack.StartFadeOut();
		}
		if(m_currentRound == 9)
		{
			GetRoundWinner();
		}
		else
		{
			m_p1.ToggleBuildingIndicator(true);
			m_p1.UpdateBuildingIndicator(m_currentRound);

			m_p2.ToggleBuildingIndicator(true);
			m_p2.UpdateBuildingIndicator(m_currentRound);

			m_p1.NextRound();
			m_p2.NextRound();

			m_currentTimeChoosing = m_timeChoosing;

			m_currentRoundState = RoundState.Building;
		
		}	
	}

	public void HasFadedIn()
	{
		m_p1.ToggleBuildingIndicator(true);
		m_p1.UpdateBuildingIndicator(m_currentRound);

		m_p2.ToggleBuildingIndicator(true);
		m_p2.UpdateBuildingIndicator(m_currentRound);

		m_currentTimeChoosing = m_timeChoosing;
		m_currentRoundState = RoundState.Building;
	}
	
	public void HasFadedOut()
	{
		if(m_currentRound == 9)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		m_currentTurn++;
		m_p1.EndTurn();
		m_p2.EndTurn();
		
	}

	void GetRoundWinner()
	{
		float totalLifePercentage1 = 0f;

		for (int i = 0; i < m_p1.P1BuiltTowers.Count; i++)
		{
			totalLifePercentage1 = totalLifePercentage1 + m_p1.P1BuiltTowers[i].GetComponent<TowerBase>().CalculateLifePercentage();
		}

		float totalLifePercentage2 = 0f;

		for (int i = 0; i < m_p2.P2BuiltTowers.Count; i++)
		{
			totalLifePercentage2 = totalLifePercentage2 + m_p2.P2BuiltTowers[i].GetComponent<TowerBase>().CalculateLifePercentage();
		}

		if(totalLifePercentage1 > totalLifePercentage2)
		{
			m_p1Score++;
		}
		else if(totalLifePercentage1 < totalLifePercentage2)
		{
			m_p2Score++;
		}
	}
}
