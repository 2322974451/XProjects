using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildWeeklyBountyBehavior : DlgBehaviourBase
	{

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

		public XUIPool BountyItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public Transform BountyListTrans;

		public IXUILabel TaskDecLabel;

		public IXUILabel GetLabel;

		public Transform RewardsParentTrans;

		public IXUIButton CloseBtn;

		public IXUIButton RefreshBtn;

		public IXUIButton HelpBtn;

		public IXUIButton CommitBtn;

		public IXUIButton GetBtn;

		public Transform ChestX;

		public IXUILabel ChestXExpLabel;

		public IXUILabel DragonCoinCostLabel;

		public IXUILabel WeeklyAskLabel;

		public IXUILabel CommitLabel;

		public IXUILabel HelpBtnLabel;

		public IXUILabel LeftTimeLabel;

		public IXUILabel CurrentValueLabel;

		public IXUILabel SingleTaskBountyLabel;

		public IXUILabel ProgressLabel;

		public IXUIScrollView BountyListScrollView;

		public IXUIButton AboutBtn;

		public GameObject FreeLabelObj;

		public Transform MailRoot;

		public Transform effectRoot;

		public IXUISprite MailCloseSprite;

		public IXUIWrapContent MailWrapContent;

		public IXUIScrollView MailScrollView;

		public IXUIButton SendGrateFulBtn;

		public GameObject CommitBtnRedpoint;

		public GameObject RightItem;
	}
}
