using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A28 RID: 2600
	internal class RankRewardHandler : DlgHandlerBase
	{
		// Token: 0x17002ECC RID: 11980
		// (get) Token: 0x06009EC5 RID: 40645 RVA: 0x001A29E0 File Offset: 0x001A0BE0
		protected override string FileName
		{
			get
			{
				return "GameSystem/RankRewardHandler";
			}
		}

		// Token: 0x06009EC6 RID: 40646 RVA: 0x001A29F8 File Offset: 0x001A0BF8
		protected override void Init()
		{
			base.Init();
			Transform transform = base.transform.Find("Bg");
			this.m_Close = (transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BottomText = (transform.Find("BottomText").GetComponent("XUILabel") as IXUILabel);
			this.m_RightText = (transform.Find("Right/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_ScrollView = (transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_RewardPool.SetupPool(null, transform.Find("ScrollView/RewardTpl").gameObject, 8U, false);
			this.m_ItemPool.SetupPool(null, transform.Find("ScrollView/Item").gameObject, 5U, false);
		}

		// Token: 0x06009EC7 RID: 40647 RVA: 0x001A2ADC File Offset: 0x001A0CDC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x06009EC8 RID: 40648 RVA: 0x001A2B00 File Offset: 0x001A0D00
		public bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x06009EC9 RID: 40649 RVA: 0x001A2B1B File Offset: 0x001A0D1B
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshList(true);
			this.RefreshText();
		}

		// Token: 0x06009ECA RID: 40650 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x06009ECB RID: 40651 RVA: 0x001A2B34 File Offset: 0x001A0D34
		public void SetData(List<RankRewardData> data, XSysDefine sys)
		{
			this.m_Data = data;
			this.Sys = sys;
		}

		// Token: 0x06009ECC RID: 40652 RVA: 0x001A2B48 File Offset: 0x001A0D48
		public void RefreshList(bool resetPos = true)
		{
			bool flag = this.m_Data == null;
			if (!flag)
			{
				this.m_RewardPool.FakeReturnAll();
				this.m_ItemPool.FakeReturnAll();
				for (int i = 0; i < this.m_Data.Count; i++)
				{
					GameObject gameObject = this.m_RewardPool.FetchGameObject(false);
					IXUILabel ixuilabel = gameObject.transform.FindChild("Bg/Rank/RankNum").GetComponent("XUILabel") as IXUILabel;
					bool flag2 = this.m_Data[i].rankMIN == this.m_Data[i].rankMAX;
					if (flag2)
					{
						ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc1"), this.m_Data[i].rankMAX));
					}
					else
					{
						ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc2"), this.m_Data[i].rankMAX));
					}
					int num = 0;
					while (num < this.m_Data[i].rewardID.Count && num < this.m_Data[i].rewardCount.Count)
					{
						GameObject gameObject2 = this.m_ItemPool.FetchGameObject(false);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, this.m_Data[i].rewardID[num], this.m_Data[i].rewardCount[num], false);
						IXUISprite ixuisprite = gameObject2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)((long)this.m_Data[i].rewardID[num]);
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
						gameObject2.transform.parent = gameObject.transform;
						gameObject2.transform.localPosition = new Vector3(this.m_ItemPool.TplPos.x + (float)(this.m_ItemPool.TplWidth * num), 0f);
						num++;
					}
					gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)this.m_RewardPool.TplHeight * i)) + this.m_RewardPool.TplPos;
				}
				this.m_ItemPool.ActualReturnAll(false);
				this.m_RewardPool.ActualReturnAll(false);
				if (resetPos)
				{
					this.m_ScrollView.ResetPosition();
				}
			}
		}

		// Token: 0x06009ECD RID: 40653 RVA: 0x001A2E00 File Offset: 0x001A1000
		private void RefreshText()
		{
			this.m_RightText.gameObject.SetActive(false);
			this.m_BottomText.gameObject.SetActive(false);
			XSysDefine sys = this.Sys;
			if (sys == XSysDefine.XSys_BigMelee)
			{
				this.m_BottomText.gameObject.SetActive(true);
				this.m_BottomText.SetText(XStringDefineProxy.GetString("BIG_MELEE_RANK_REWARD_TIP"));
				this.m_RightText.gameObject.SetActive(true);
			}
		}

		// Token: 0x0400387E RID: 14462
		private List<RankRewardData> m_Data;

		// Token: 0x0400387F RID: 14463
		public XSysDefine Sys;

		// Token: 0x04003880 RID: 14464
		public IXUIButton m_Close;

		// Token: 0x04003881 RID: 14465
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003882 RID: 14466
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003883 RID: 14467
		public IXUILabel m_RightText;

		// Token: 0x04003884 RID: 14468
		public IXUILabel m_BottomText;

		// Token: 0x04003885 RID: 14469
		public IXUIScrollView m_ScrollView;
	}
}
