using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
	[SerializeField] private float m_alphaSpeed;

	private Image m_blackScreen = null;

	private FadingState m_currentFadingState = FadingState.FadingIn;


	private void Awake()
	{
		m_blackScreen = this.GetComponent<Image>();
	}
	private void Start()
	{
		RoundController.Instance.CmpFadeToBlack = this;
	}

	private void Update()
	{
		switch (m_currentFadingState)
		{
			case FadingState.FadingIn://Black to white
				{
					
					Color color = m_blackScreen.color;
					color = new Color(color.r, color.g, color.b, color.a - m_alphaSpeed * Time.deltaTime);
					m_blackScreen.color = color;

					if (color.a <= 0)
					{
						color.a = 0;
						m_blackScreen.color = color;
						RoundController.Instance.HasFadedIn();
						m_currentFadingState = FadingState.Neutral;
					}
				}
				break;
			case FadingState.FadingOut://White to blakc
				{
					Color color = m_blackScreen.color;
					color = new Color(color.r, color.g, color.b, color.a + m_alphaSpeed * Time.deltaTime);
					m_blackScreen.color = color;
						
					if (color.a >= 1)
					{
						color.a = 1;
						m_blackScreen.color = color;
						RoundController.Instance.HasFadedOut();
						m_currentFadingState = FadingState.FadingIn;
					}
				}
				break;
			case FadingState.Neutral:
				break;
			default:
				break;
		}
	}

	public void StartFadeOut()
	{
		m_currentFadingState = FadingState.FadingOut;
	}



}
