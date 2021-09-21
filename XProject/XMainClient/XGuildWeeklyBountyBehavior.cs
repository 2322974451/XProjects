using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A5B RID: 2651
	internal class XGuildWeeklyBountyBehavior : DlgBehaviourBase
	{
		// Token: 0x0600A0D0 RID: 41168 RVA: 0x001AFC6C File Offset: 0x001ADE6C
		private void Awake()
		{
			this.AboutBtn = (base.transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
			this.BountyListTrans = base.transform.Find("BountyList");
			this.BountyItemPool.SetupPool(this.BountyListTrans.gameObject, this.BountyListTrans.Find("BountyItem").gameObject, 12U, false);
			this.TaskDecLabel = (base.transform.Find("Text/TaskDec").GetComponent("XUILabel") as IXUILabel);
			this.GetLabel = (base.transform.transform.Find("GetBtn/GetLabel").GetComponent("XUILabel") as IXUILabel);
			this.RewardsParentTrans = base.transform.Find("TaskRewards");
			this.CloseBtn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.RefreshBtn = (base.transform.Find("RefreshBtn").GetComponent("XUIButton") as IXUIButton);
			this.HelpBtn = (base.transform.Find("ReqHelp").GetComponent("XUIButton") as IXUIButton);
			this.CommitBtn = (base.transform.Find("CommitBtn").GetComponent("XUIButton") as IXUIButton);
			this.CommitBtnRedpoint = base.transform.Find("CommitBtn/RedPoint").gameObject;
			this.GetBtn = (base.transform.Find("GetBtn").GetComponent("XUIButton") as IXUIButton);
			this.ChestX = base.transform.transform.Find("ChestX");
			this.ChestXExpLabel = (this.ChestX.Find("Exp").GetComponent("XUILabel") as IXUILabel);
			this.FreeLabelObj = base.transform.Find("RefreshBtn/FreeLabel").gameObject;
			this.DragonCoinCostLabel = (base.transform.Find("RefreshBtn/godLabel").GetComponent("XUILabel") as IXUILabel);
			this.WeeklyAskLabel = (base.transform.Find("AskTimesLabel").GetComponent("XUILabel") as IXUILabel);
			this.CommitLabel = (base.transform.Find("CommitBtn/T").GetComponent("XUILabel") as IXUILabel);
			this.HelpBtnLabel = (base.transform.Find("ReqHelp/GetLabel").GetComponent("XUILabel") as IXUILabel);
			this.LeftTimeLabel = (base.transform.Find("LeftTimeLabel").GetComponent("XUILabel") as IXUILabel);
			this.CurrentValueLabel = (base.transform.Find("CurrentOwnedNum").GetComponent("XUILabel") as IXUILabel);
			this.SingleTaskBountyLabel = (base.transform.Find("SingleTaskBountyValue").GetComponent("XUILabel") as IXUILabel);
			this.ProgressLabel = (base.transform.Find("SingleTaskBountyValue/t").GetComponent("XUILabel") as IXUILabel);
			this.MailRoot = base.transform.Find("mail");
			this.MailCloseSprite = (this.MailRoot.Find("Bg/Black").GetComponent("XUISprite") as IXUISprite);
			this.MailWrapContent = (this.MailRoot.Find("MailDlg/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.MailScrollView = (this.MailRoot.Find("MailDlg").GetComponent("XUIScrollView") as IXUIScrollView);
			this.SendGrateFulBtn = (this.MailRoot.Find("OK").GetComponent("XUIButton") as IXUIButton);
			this.BountyListScrollView = (this.BountyListTrans.GetComponent("XUIScrollView") as IXUIScrollView);
			this.RightItem = base.transform.Find("RightItem").gameObject;
			this.effectRoot = base.transform.Find("EffectPanel/Effect");
		}

		// Token: 0x040039B1 RID: 14769
		public XUIPool BountyItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040039B2 RID: 14770
		public Transform BountyListTrans;

		// Token: 0x040039B3 RID: 14771
		public IXUILabel TaskDecLabel;

		// Token: 0x040039B4 RID: 14772
		public IXUILabel GetLabel;

		// Token: 0x040039B5 RID: 14773
		public Transform RewardsParentTrans;

		// Token: 0x040039B6 RID: 14774
		public IXUIButton CloseBtn;

		// Token: 0x040039B7 RID: 14775
		public IXUIButton RefreshBtn;

		// Token: 0x040039B8 RID: 14776
		public IXUIButton HelpBtn;

		// Token: 0x040039B9 RID: 14777
		public IXUIButton CommitBtn;

		// Token: 0x040039BA RID: 14778
		public IXUIButton GetBtn;

		// Token: 0x040039BB RID: 14779
		public Transform ChestX;

		// Token: 0x040039BC RID: 14780
		public IXUILabel ChestXExpLabel;

		// Token: 0x040039BD RID: 14781
		public IXUILabel DragonCoinCostLabel;

		// Token: 0x040039BE RID: 14782
		public IXUILabel WeeklyAskLabel;

		// Token: 0x040039BF RID: 14783
		public IXUILabel CommitLabel;

		// Token: 0x040039C0 RID: 14784
		public IXUILabel HelpBtnLabel;

		// Token: 0x040039C1 RID: 14785
		public IXUILabel LeftTimeLabel;

		// Token: 0x040039C2 RID: 14786
		public IXUILabel CurrentValueLabel;

		// Token: 0x040039C3 RID: 14787
		public IXUILabel SingleTaskBountyLabel;

		// Token: 0x040039C4 RID: 14788
		public IXUILabel ProgressLabel;

		// Token: 0x040039C5 RID: 14789
		public IXUIScrollView BountyListScrollView;

		// Token: 0x040039C6 RID: 14790
		public IXUIButton AboutBtn;

		// Token: 0x040039C7 RID: 14791
		public GameObject FreeLabelObj;

		// Token: 0x040039C8 RID: 14792
		public Transform MailRoot;

		// Token: 0x040039C9 RID: 14793
		public Transform effectRoot;

		// Token: 0x040039CA RID: 14794
		public IXUISprite MailCloseSprite;

		// Token: 0x040039CB RID: 14795
		public IXUIWrapContent MailWrapContent;

		// Token: 0x040039CC RID: 14796
		public IXUIScrollView MailScrollView;

		// Token: 0x040039CD RID: 14797
		public IXUIButton SendGrateFulBtn;

		// Token: 0x040039CE RID: 14798
		public GameObject CommitBtnRedpoint;

		// Token: 0x040039CF RID: 14799
		public GameObject RightItem;
	}
}
