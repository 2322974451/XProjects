using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XCampDuelPointRewardHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			Transform transform = base.transform.Find("Bg");
			this.m_Close = (transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_RewardPool.SetupPool(null, transform.Find("ScrollView/RewardTpl").gameObject, 8U, false);
			this.m_ItemPool.SetupPool(null, transform.Find("ScrollView/ItemTpl").gameObject, 10U, false);
			this.m_ExItem = transform.Find("ScrollView/Extra");
			this.m_ExItem.gameObject.SetActive(false);
		}

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/CampDuelPointReward";
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
		}

		public void RefreshList(bool resetPos = true)
		{
			List<CampDuelPointReward.RowData> pointRewardList = XCampDuelDocument.Doc.GetPointRewardList(this.CampID);
			bool flag = pointRewardList == null;
			if (!flag)
			{
				this.m_RewardPool.FakeReturnAll();
				this.m_ItemPool.FakeReturnAll();
				for (int i = 0; i < pointRewardList.Count; i++)
				{
					GameObject gameObject = this.m_RewardPool.FetchGameObject(false);
					IXUILabel ixuilabel = gameObject.transform.FindChild("Bg/Point/Num").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(pointRewardList[i].Point.ToString());
					for (int j = 0; j < (int)pointRewardList[i].Reward.count; j++)
					{
						GameObject gameObject2 = this.m_ItemPool.FetchGameObject(false);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, pointRewardList[i].Reward[j, 0], pointRewardList[i].Reward[j, 1], false);
						IXUISprite ixuisprite = gameObject2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)((long)pointRewardList[i].Reward[j, 0]);
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
						gameObject2.transform.parent = gameObject.transform;
						gameObject2.transform.localPosition = new Vector3(this.m_ItemPool.TplPos.x - this.m_RewardPool.TplPos.x + (float)(this.m_ItemPool.TplWidth * j), 0f);
					}
					bool flag2 = pointRewardList[i].EXReward.bufferRef.Length != 0;
					if (flag2)
					{
						GameObject gameObject3 = this.m_ItemPool.FetchGameObject(false);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject3, pointRewardList[i].EXReward[0], pointRewardList[i].EXReward[1], false);
						IXUISprite ixuisprite2 = gameObject3.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite2.ID = (ulong)((long)pointRewardList[i].EXReward[0]);
						ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
						gameObject3.transform.parent = gameObject.transform;
						gameObject3.transform.localPosition = new Vector3(this.m_ExItem.localPosition.x - this.m_RewardPool.TplPos.x, 0f);
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

		public int CampID;

		private IXUIButton m_Close;

		private XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform m_ExItem;

		private IXUIScrollView m_ScrollView;
	}
}
