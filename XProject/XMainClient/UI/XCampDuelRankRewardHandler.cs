using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017DB RID: 6107
	internal class XCampDuelRankRewardHandler : DlgHandlerBase
	{
		// Token: 0x0600FD1D RID: 64797 RVA: 0x003B3A84 File Offset: 0x003B1C84
		protected override void Init()
		{
			base.Init();
			Transform transform = base.transform.Find("Bg");
			this.m_Close = (transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BottomText = (transform.Find("BottomText").GetComponent("XUILabel") as IXUILabel);
			this.m_RightText = (transform.Find("Right/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_ScrollView = (transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_RewardPool.SetupPool(null, transform.Find("ScrollView/RewardTpl").gameObject, 8U, false);
			this.m_ItemPool.SetupPool(null, transform.Find("ScrollView/Item").gameObject, 10U, false);
		}

		// Token: 0x170038AF RID: 14511
		// (get) Token: 0x0600FD1E RID: 64798 RVA: 0x003B3B6C File Offset: 0x003B1D6C
		protected override string FileName
		{
			get
			{
				return "GameSystem/CampDuelRankRewardHandler";
			}
		}

		// Token: 0x0600FD1F RID: 64799 RVA: 0x003B3B83 File Offset: 0x003B1D83
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600FD20 RID: 64800 RVA: 0x003B3BA8 File Offset: 0x003B1DA8
		public bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600FD21 RID: 64801 RVA: 0x003B3BC4 File Offset: 0x003B1DC4
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshList(true);
			this.m_BottomText.gameObject.SetActive(true);
			this.m_BottomText.SetText(XStringDefineProxy.GetString("CAMPDUEL_RANK_REWARD"));
			this.m_RightText.gameObject.SetActive(true);
			this.m_RightText.SetText(XTempActivityDocument.Doc.GetEndTime(XCampDuelDocument.Doc.ActInfo, 1).ToString(XStringDefineProxy.GetString("CAMPDUEL_END_TIME")));
		}

		// Token: 0x0600FD22 RID: 64802 RVA: 0x003B3C50 File Offset: 0x003B1E50
		public void RefreshList(bool resetPos = true)
		{
			List<CampDuelRankReward.RowData> rankRewardList = XCampDuelDocument.Doc.GetRankRewardList();
			bool flag = rankRewardList == null;
			if (!flag)
			{
				this.m_RewardPool.FakeReturnAll();
				this.m_ItemPool.FakeReturnAll();
				int i = 0;
				for (int j = 0; j < rankRewardList.Count; j++)
				{
					bool isWin = rankRewardList[j].IsWin;
					if (isWin)
					{
						GameObject gameObject = this.m_RewardPool.FetchGameObject(false);
						this.RefreshOneRankItem(gameObject.transform.FindChild("Bg/Win"), rankRewardList[j]);
						while (i < rankRewardList.Count)
						{
							bool flag2 = !rankRewardList[i].IsWin;
							if (flag2)
							{
								this.RefreshOneRankItem(gameObject.transform.FindChild("Bg/Lose"), rankRewardList[i]);
								i++;
								break;
							}
							i++;
						}
						gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)this.m_RewardPool.TplHeight * j)) + this.m_RewardPool.TplPos;
					}
				}
				this.m_ItemPool.ActualReturnAll(false);
				this.m_RewardPool.ActualReturnAll(false);
				if (resetPos)
				{
					this.m_ScrollView.ResetPosition();
				}
			}
		}

		// Token: 0x0600FD23 RID: 64803 RVA: 0x003B3DA8 File Offset: 0x003B1FA8
		private void RefreshOneRankItem(Transform t, CampDuelRankReward.RowData data)
		{
			IXUILabel ixuilabel = t.FindChild("Rank/RankNum").GetComponent("XUILabel") as IXUILabel;
			bool flag = data.Rank[0] == data.Rank[1];
			if (flag)
			{
				ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc1"), data.Rank[0]));
			}
			else
			{
				ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("Qualifying_Rank_Reward_Desc2"), data.Rank[1]));
			}
			Transform parent = t.FindChild("Item");
			for (int i = 0; i < (int)data.Reward.count; i++)
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, data.Reward[i, 0], data.Reward[i, 1], false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)data.Reward[i, 0]);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				XSingleton<UiUtility>.singleton.AddChild(parent, gameObject.transform);
				gameObject.transform.localPosition = new Vector3((float)(this.m_ItemPool.TplWidth * i), 0f);
			}
		}

		// Token: 0x04006F6E RID: 28526
		public IXUIButton m_Close;

		// Token: 0x04006F6F RID: 28527
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006F70 RID: 28528
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006F71 RID: 28529
		public IXUILabel m_RightText;

		// Token: 0x04006F72 RID: 28530
		public IXUILabel m_BottomText;

		// Token: 0x04006F73 RID: 28531
		public IXUIScrollView m_ScrollView;
	}
}
