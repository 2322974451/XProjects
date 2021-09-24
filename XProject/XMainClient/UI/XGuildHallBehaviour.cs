using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildHallBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnExit = (base.transform.FindChild("Bg/BtnExit").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnSignIn = (base.transform.FindChild("Bg/BtnSignIn").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnSignIn.ID = 810UL;
			this.m_BtnSkill = (base.transform.FindChild("Bg/BtnSkill").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnSkill.ID = 812UL;
			this.m_BtnMembers = (base.transform.FindChild("Bg/BtnMembers").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnMembers.ID = 813UL;
			this.m_BtnApprove = (base.transform.FindChild("Bg/BtnApprove").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnApprove.ID = 811UL;
			this.m_BtnLog = (base.transform.FindChild("Bg/BtnLog").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnEditAnnounce = (base.transform.FindChild("Bg/BtnEditAnnounce").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnRank = (base.transform.FindChild("Bg/BtnRank").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnEnter = (base.transform.FindChild("Bg/BtnEnter").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnEnter.ID = 17UL;
			this.m_BtnMall = (base.transform.FindChild("Bg/BtnMall").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnDonate = (base.transform.FindChild("Bg/Donation").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnDmx = (base.transform.FindChild("Bg/BtnDmx").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnDmx.ID = 840UL;
			this.m_checkGuildList.Add(this.m_BtnDmx);
			this.m_BtnGZ = (base.transform.FindChild("Bg/BtnGz").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnGZ.ID = 833UL;
			this.m_BtnRedPacker = (base.transform.FindChild("Bg/BtnRed").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnRedPacker.ID = 830UL;
			this.m_BtnJoker = (base.transform.FindChild("Bg/BtnJoker").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnJoker.ID = 820UL;
			this.m_checkGuildList.Add(this.m_BtnJoker);
			this.m_BtnConsider = (base.transform.FindChild("Bg/BtnConsider").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnConsider.ID = 823UL;
			this.m_BtnBuild = (base.transform.FindChild("Bg/BtnBuild").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnBuild.ID = 824UL;
			this.m_BtnWXGroup = (base.transform.Find("Bg/Group/BtnWXGroup").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnWXGroup.gameObject.SetActive(false);
			this.m_BtnWXGroupShare = (base.transform.Find("Bg/Group/BtnWXGroupShare").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnWXGroupShare.gameObject.SetActive(false);
			this.m_WXGroupTip = (base.transform.Find("Bg/Group/BtnWXGroup/LivenessTips").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnQQGroup = (base.transform.Find("Bg/Group/BtnQQGroup").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnQQGroup.gameObject.SetActive(false);
			this.m_QQGroupTip = (base.transform.Find("Bg/Group/BtnQQGroup/LivenessTips").GetComponent("XUILabel") as IXUILabel);
			this.m_QQGroupName = (base.transform.Find("Bg/Group/QQGroupInfo").GetComponent("XUILabel") as IXUILabel);
			this.m_QQGroupName.gameObject.SetActive(false);
			this.m_BtnEditPortrait = (base.transform.FindChild("Bg/BtnEditPortrait").GetComponent("XUIButton") as IXUIButton);
			this.m_Portrait = (base.transform.FindChild("Bg/BasicInfo/Content/Portrait").GetComponent("XUISprite") as IXUISprite);
			this.m_Annoucement = (base.transform.FindChild("Bg/Bg3/Announcement").GetComponent("XUILabel") as IXUILabel);
			this.m_Annoucement.SetText("");
			this.m_BasicInfoDisplay.Init(base.transform.FindChild("Bg/BasicInfo/Content"), true);
			this.m_LivenessTipSprite = (base.transform.FindChild("Bg/BasicInfo/Content/Liveness/Tips").GetComponent("XUISprite") as IXUISprite);
			this.m_LivenessTipsLabel = (base.transform.FindChild("Bg/BasicInfo/Content/LivenessTips").GetComponent("XUILabel") as IXUILabel);
			this.m_PopularityTipSprite = (base.transform.FindChild("Bg/BasicInfo/Content/Popularity/Tips").GetComponent("XUISprite") as IXUISprite);
			this.m_PopularityTipLabel = (base.transform.FindChild("Bg/BasicInfo/Content/prestigeTips").GetComponent("XUILabel") as IXUILabel);
			this.m_PopularityTipLabel.SetVisible(false);
			this.m_LivenessTipsLabel.SetVisible(false);
			this.m_ExpTipsSprite = (base.transform.FindChild("Bg/BasicInfo/Content/Exp/Tips").GetComponent("XUISprite") as IXUISprite);
			this.m_ExpTipsLabel = (base.transform.FindChild("Bg/BasicInfo/Content/ExpTips").GetComponent("XUILabel") as IXUILabel);
			this.m_ExpTipsLabel.SetVisible(false);
			this.m_EditAnnouncePanel = base.transform.FindChild("Bg/EditAnnouncePanel").gameObject;
			this.m_LogPanel = base.transform.FindChild("Bg/LogPanel").gameObject;
			this.m_ShielterItemPool.SetupPool(base.transform.Find("Bg/Bg3").gameObject, base.transform.Find("Bg/Bg3/HallShelterIcon").gameObject, 5U, false);
			this.m_GrowthBuffHelpFrame = base.transform.Find("Bg/Bg3/HelpFrame");
			this.m_GrowthBuffHelpLabel = (this.m_GrowthBuffHelpFrame.Find("Helps").GetComponent("XUILabel") as IXUILabel);
			this.m_GrowthBuffHelpFrame.gameObject.SetActive(false);
		}

		private void OnApplicationPause(bool pause)
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			specificDocument.QueryWXGroup();
		}

		public IXUIButton m_Close = null;

		public IXUIButton m_BtnExit;

		public IXUIButton m_BtnLog;

		public IXUIButton m_BtnEditAnnounce;

		public IXUIButton m_BtnRank;

		public IXUIButton m_BtnEnter;

		public IXUIButton m_BtnEditPortrait;

		public IXUIButton m_BtnMall;

		public IXUIButton m_BtnSignIn;

		public IXUIButton m_BtnSkill;

		public IXUIButton m_BtnMembers;

		public IXUIButton m_BtnApprove;

		public IXUIButton m_BtnDonate;

		public IXUIButton m_BtnGZ;

		public IXUIButton m_BtnRedPacker;

		public IXUIButton m_BtnDmx;

		public IXUIButton m_BtnJoker;

		public IXUIButton m_BtnConsider;

		public IXUIButton m_BtnBuild;

		public IXUIButton m_BtnWXGroup;

		public IXUIButton m_BtnWXGroupShare;

		public IXUILabel m_WXGroupTip;

		public IXUIButton m_BtnQQGroup;

		public IXUILabel m_QQGroupTip;

		public IXUILabel m_QQGroupName;

		public IXUISprite m_Portrait;

		public IXUISprite m_LivenessTipSprite;

		public IXUILabel m_LivenessTipsLabel;

		public IXUISprite m_PopularityTipSprite;

		public IXUILabel m_PopularityTipLabel;

		public IXUISprite m_ExpTipsSprite;

		public IXUILabel m_ExpTipsLabel;

		public IXUILabel m_Annoucement;

		public GameObject m_EditAnnouncePanel;

		public GameObject m_LogPanel;

		public List<IXUIButton> m_checkGuildList = new List<IXUIButton>();

		public XGuildBasicInfoDisplay m_BasicInfoDisplay = new XGuildBasicInfoDisplay();

		public XUIPool m_ShielterItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public Transform m_GrowthBuffHelpFrame;

		public IXUILabel m_GrowthBuffHelpLabel;
	}
}
