using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XCampDuelRankRewardHandler : DlgHandlerBase
	{

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

		protected override string FileName
		{
			get
			{
				return "GameSystem/CampDuelRankRewardHandler";
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshList(true);
			this.m_BottomText.gameObject.SetActive(true);
			this.m_BottomText.SetText(XStringDefineProxy.GetString("CAMPDUEL_RANK_REWARD"));
			this.m_RightText.gameObject.SetActive(true);
			this.m_RightText.SetText(XTempActivityDocument.Doc.GetEndTime(XCampDuelDocument.Doc.ActInfo, 1).ToString(XStringDefineProxy.GetString("CAMPDUEL_END_TIME")));
		}

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

		public IXUIButton m_Close;

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_RightText;

		public IXUILabel m_BottomText;

		public IXUIScrollView m_ScrollView;
	}
}
