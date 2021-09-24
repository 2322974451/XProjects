using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RankRewardHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/RankRewardHandler";
			}
		}

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
			this.RefreshText();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		public void SetData(List<RankRewardData> data, XSysDefine sys)
		{
			this.m_Data = data;
			this.Sys = sys;
		}

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

		private List<RankRewardData> m_Data;

		public XSysDefine Sys;

		public IXUIButton m_Close;

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_RightText;

		public IXUILabel m_BottomText;

		public IXUIScrollView m_ScrollView;
	}
}
