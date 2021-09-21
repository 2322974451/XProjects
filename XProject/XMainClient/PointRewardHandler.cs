using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A2A RID: 2602
	internal class PointRewardHandler : DlgHandlerBase
	{
		// Token: 0x17002ECD RID: 11981
		// (get) Token: 0x06009ED0 RID: 40656 RVA: 0x001A2ED4 File Offset: 0x001A10D4
		protected override string FileName
		{
			get
			{
				return "GameSystem/PointRewardHandler";
			}
		}

		// Token: 0x06009ED1 RID: 40657 RVA: 0x001A2EEC File Offset: 0x001A10EC
		protected override void Init()
		{
			base.Init();
			Transform transform = base.transform.Find("Bg");
			this.m_Close = (transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_CurrentText = (transform.Find("CurrentPoint").GetComponent("XUILabel") as IXUILabel);
			this.m_CurrentPoint = (transform.Find("CurrentPoint/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_BottomText = (transform.Find("BottomText").GetComponent("XUILabel") as IXUILabel);
			this.m_RightText = (transform.Find("RightText").GetComponent("XUILabel") as IXUILabel);
			this.m_TitleText = (transform.Find("Title/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_ScrollView = (transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_RewardPool.SetupPool(null, transform.Find("ScrollView/RewardTpl").gameObject, 8U, false);
			this.m_ItemPool.SetupPool(null, transform.Find("ScrollView/ItemTpl").gameObject, 5U, false);
		}

		// Token: 0x06009ED2 RID: 40658 RVA: 0x001A3030 File Offset: 0x001A1230
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x06009ED3 RID: 40659 RVA: 0x001A3054 File Offset: 0x001A1254
		public bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x06009ED4 RID: 40660 RVA: 0x001A306F File Offset: 0x001A126F
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshList(true);
			this.RefreshText();
		}

		// Token: 0x06009ED5 RID: 40661 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x06009ED6 RID: 40662 RVA: 0x001A3088 File Offset: 0x001A1288
		public void SetData(List<PointRewardData> data, XSysDefine sys)
		{
			this.m_Data = data;
			this.Sys = sys;
		}

		// Token: 0x06009ED7 RID: 40663 RVA: 0x001A309C File Offset: 0x001A129C
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
					IXUILabel ixuilabel = gameObject.transform.FindChild("Bg/Point/Num").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(this.m_Data[i].point.ToString());
					for (int j = 0; j < this.m_Data[i].rewardItem.size; j++)
					{
						GameObject gameObject2 = this.m_ItemPool.FetchGameObject(false);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, this.m_Data[i].rewardItem.BufferKeys[j], this.m_Data[i].rewardItem.BufferValues[j], false);
						IXUISprite ixuisprite = gameObject2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)((long)this.m_Data[i].rewardItem.BufferKeys[j]);
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
						gameObject2.transform.parent = gameObject.transform;
						gameObject2.transform.localPosition = new Vector3(this.m_ItemPool.TplPos.x - this.m_RewardPool.TplPos.x + (float)(this.m_ItemPool.TplWidth * j), 0f);
					}
					gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)this.m_RewardPool.TplHeight * i)) + this.m_RewardPool.TplPos;
					this.RefreshItemText(gameObject, this.m_Data[i]);
				}
				this.m_ItemPool.ActualReturnAll(false);
				this.m_RewardPool.ActualReturnAll(false);
				if (resetPos)
				{
					this.m_ScrollView.ResetPosition();
				}
			}
		}

		// Token: 0x06009ED8 RID: 40664 RVA: 0x001A3308 File Offset: 0x001A1508
		private void RefreshText()
		{
			this.m_RightText.gameObject.SetActive(false);
			this.m_BottomText.gameObject.SetActive(false);
			this.m_CurrentText.gameObject.SetActive(false);
			this.m_TitleText.SetText(XStringDefineProxy.GetString("POINT_REWARD"));
			XSysDefine sys = this.Sys;
			if (sys != XSysDefine.XSys_BigMelee)
			{
				if (sys != XSysDefine.XSys_Battlefield)
				{
					if (sys == XSysDefine.XSys_MulActivity_SkyArena)
					{
						this.m_RightText.gameObject.SetActive(true);
						this.m_RightText.SetText(XStringDefineProxy.GetString("POINT_REWARD_RIGHT_TIP"));
						this.m_TitleText.SetText(XStringDefineProxy.GetString("PREVIEW_REWARD"));
					}
				}
				else
				{
					this.m_RightText.gameObject.SetActive(true);
					this.m_BottomText.gameObject.SetActive(true);
					this.m_RightText.SetText(XStringDefineProxy.GetString("POINT_REWARD_RIGHT_TIP"));
					this.m_BottomText.SetText(XStringDefineProxy.GetString("BATTLEFIELD_POINT_REWARD_BOTTOM_TIP"));
				}
			}
			else
			{
				this.m_RightText.gameObject.SetActive(true);
				this.m_BottomText.gameObject.SetActive(true);
				this.m_RightText.SetText(XStringDefineProxy.GetString("POINT_REWARD_RIGHT_TIP"));
				this.m_BottomText.SetText(XStringDefineProxy.GetString("BIG_MELEE_POINT_REWARD_BOTTOM_TIP"));
			}
		}

		// Token: 0x06009ED9 RID: 40665 RVA: 0x001A3478 File Offset: 0x001A1678
		private void RefreshItemText(GameObject go, PointRewardData data)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Bg/Count").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Bg/Point").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.gameObject.SetActive(false);
			ixuilabel2.SetText(XStringDefineProxy.GetString("POINT_REACH"));
			XSysDefine sys = this.Sys;
			if (sys != XSysDefine.XSys_Battlefield)
			{
				if (sys == XSysDefine.XSys_MulActivity_SkyArena)
				{
					ixuilabel2.SetText(XStringDefineProxy.GetString("FLOOR_REACH"));
				}
			}
			else
			{
				ixuilabel.gameObject.SetActive(true);
				uint pointRewardGetCount = XBattleFieldEntranceDocument.Doc.GetPointRewardGetCount(data.id);
				BattleFieldPointReward.RowData curPointRewardList = XBattleFieldEntranceDocument.Doc.GetCurPointRewardList(data.id);
				string arg = (curPointRewardList.count - pointRewardGetCount).ToString();
				ixuilabel.SetText(string.Format("{0}/{1}", arg, curPointRewardList.count.ToString()));
			}
		}

		// Token: 0x04003889 RID: 14473
		private List<PointRewardData> m_Data;

		// Token: 0x0400388A RID: 14474
		public XSysDefine Sys;

		// Token: 0x0400388B RID: 14475
		public IXUIButton m_Close;

		// Token: 0x0400388C RID: 14476
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400388D RID: 14477
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400388E RID: 14478
		public IXUILabel m_CurrentText;

		// Token: 0x0400388F RID: 14479
		public IXUILabel m_CurrentPoint;

		// Token: 0x04003890 RID: 14480
		public IXUILabel m_BottomText;

		// Token: 0x04003891 RID: 14481
		public IXUILabel m_RightText;

		// Token: 0x04003892 RID: 14482
		public IXUILabel m_TitleText;

		// Token: 0x04003893 RID: 14483
		public IXUIScrollView m_ScrollView;
	}
}
