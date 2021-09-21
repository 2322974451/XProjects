using System;
using UILib;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000CF2 RID: 3314
	internal class XGuildSignNode
	{
		// Token: 0x1700329B RID: 12955
		// (get) Token: 0x0600B96E RID: 47470 RVA: 0x0025A66C File Offset: 0x0025886C
		public BonusState bonusState
		{
			get
			{
				return this.m_bonusState;
			}
		}

		// Token: 0x0600B96F RID: 47471 RVA: 0x0025A684 File Offset: 0x00258884
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

		// Token: 0x0600B970 RID: 47472 RVA: 0x0025A7AB File Offset: 0x002589AB
		public void SetSignNumber(uint number)
		{
			this.m_SignNumber.SetText(number.ToString());
		}

		// Token: 0x0600B971 RID: 47473 RVA: 0x0025A7C4 File Offset: 0x002589C4
		public void SetBonusProgress(float p)
		{
			float value = (p > 0f) ? (p * 0.9f + 0.1f) : 0f;
			this.m_slider.Value = value;
		}

		// Token: 0x0600B972 RID: 47474 RVA: 0x0025A7FC File Offset: 0x002589FC
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

		// Token: 0x0600B973 RID: 47475 RVA: 0x0025A910 File Offset: 0x00258B10
		public void Reset()
		{
			this.m_slider.Value = 0f;
			this.m_Filled.SetVisible(false);
			this.m_Packeton.SetVisible(false);
			this.m_Finish.SetVisible(false);
			this.m_redSprite.SetVisible(false);
		}

		// Token: 0x04004A05 RID: 18949
		private Transform m_ProgressGo;

		// Token: 0x04004A06 RID: 18950
		private Transform m_CircleGo;

		// Token: 0x04004A07 RID: 18951
		private IXUISlider m_slider;

		// Token: 0x04004A08 RID: 18952
		private IXUISprite m_Filled;

		// Token: 0x04004A09 RID: 18953
		private IXUISprite m_Packeton;

		// Token: 0x04004A0A RID: 18954
		private IXUISprite m_Finish;

		// Token: 0x04004A0B RID: 18955
		private IXUILabel m_SignNumber;

		// Token: 0x04004A0C RID: 18956
		public IXUISprite m_pressCircle;

		// Token: 0x04004A0D RID: 18957
		public IXUISprite m_redSprite;

		// Token: 0x04004A0E RID: 18958
		private BonusState m_bonusState;
	}
}
