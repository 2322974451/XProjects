using System;
using UILib;
using UnityEngine;

namespace XMainClient
{

	internal class XGuildSignNode
	{

		public BonusState bonusState
		{
			get
			{
				return this.m_bonusState;
			}
		}

		public XGuildSignNode(int key, Transform pGo, Transform cGo)
		{
			this.m_ProgressGo = pGo;
			this.m_CircleGo = cGo;
			this.m_pressCircle = (this.m_CircleGo.GetComponent("XUISprite") as IXUISprite);
			this.m_pressCircle.ID = (ulong)((long)key);
			this.m_slider = (this.m_ProgressGo.GetComponent("XUISlider") as IXUISlider);
			this.m_Filled = (this.m_CircleGo.FindChild("filled").GetComponent("XUISprite") as IXUISprite);
			this.m_Packeton = (this.m_CircleGo.FindChild("Packeton").GetComponent("XUISprite") as IXUISprite);
			this.m_Finish = (this.m_CircleGo.FindChild("Sprite").GetComponent("XUISprite") as IXUISprite);
			this.m_SignNumber = (this.m_CircleGo.FindChild("T").GetComponent("XUILabel") as IXUILabel);
			this.m_redSprite = (this.m_CircleGo.FindChild("RedPoint").GetComponent("XUISprite") as IXUISprite);
			this.Reset();
		}

		public void SetSignNumber(uint number)
		{
			this.m_SignNumber.SetText(number.ToString());
		}

		public void SetBonusProgress(float p)
		{
			float value = (p > 0f) ? (p * 0.9f + 0.1f) : 0f;
			this.m_slider.Value = value;
		}

		public void SetBonusStatu(BonusState _bonusState)
		{
			this.Reset();
			this.m_bonusState = _bonusState;
			switch (_bonusState)
			{
			case BonusState.Bonus_Active:
				this.m_Filled.SetVisible(true);
				this.m_Finish.SetVisible(false);
				this.m_Packeton.SetVisible(true);
				this.m_redSprite.SetVisible(false);
				break;
			case BonusState.Bonus_UnActive:
				this.m_Filled.SetVisible(false);
				this.m_Packeton.SetVisible(false);
				this.m_Finish.SetVisible(false);
				this.m_redSprite.SetVisible(false);
				break;
			case BonusState.Bonus_Actived:
				this.m_Filled.SetVisible(true);
				this.m_Packeton.SetVisible(true);
				this.m_Finish.SetVisible(false);
				this.m_redSprite.SetVisible(true);
				break;
			case BonusState.Bouns_Over:
				this.m_Filled.SetVisible(true);
				this.m_Finish.SetVisible(true);
				this.m_Packeton.SetVisible(true);
				this.m_redSprite.SetVisible(false);
				break;
			}
		}

		public void Reset()
		{
			this.m_slider.Value = 0f;
			this.m_Filled.SetVisible(false);
			this.m_Packeton.SetVisible(false);
			this.m_Finish.SetVisible(false);
			this.m_redSprite.SetVisible(false);
		}

		private Transform m_ProgressGo;

		private Transform m_CircleGo;

		private IXUISlider m_slider;

		private IXUISprite m_Filled;

		private IXUISprite m_Packeton;

		private IXUISprite m_Finish;

		private IXUILabel m_SignNumber;

		public IXUISprite m_pressCircle;

		public IXUISprite m_redSprite;

		private BonusState m_bonusState;
	}
}
