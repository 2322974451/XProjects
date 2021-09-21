using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018A5 RID: 6309
	internal class XGuildHallBehaviour : DlgBehaviourBase
	{
		// Token: 0x060106DA RID: 67290 RVA: 0x00403068 File Offset: 0x00401268
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

		// Token: 0x060106DB RID: 67291 RVA: 0x0040377C File Offset: 0x0040197C
		private void OnApplicationPause(bool pause)
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			specificDocument.QueryWXGroup();
		}

		// Token: 0x0400769B RID: 30363
		public IXUIButton m_Close = null;

		// Token: 0x0400769C RID: 30364
		public IXUIButton m_BtnExit;

		// Token: 0x0400769D RID: 30365
		public IXUIButton m_BtnLog;

		// Token: 0x0400769E RID: 30366
		public IXUIButton m_BtnEditAnnounce;

		// Token: 0x0400769F RID: 30367
		public IXUIButton m_BtnRank;

		// Token: 0x040076A0 RID: 30368
		public IXUIButton m_BtnEnter;

		// Token: 0x040076A1 RID: 30369
		public IXUIButton m_BtnEditPortrait;

		// Token: 0x040076A2 RID: 30370
		public IXUIButton m_BtnMall;

		// Token: 0x040076A3 RID: 30371
		public IXUIButton m_BtnSignIn;

		// Token: 0x040076A4 RID: 30372
		public IXUIButton m_BtnSkill;

		// Token: 0x040076A5 RID: 30373
		public IXUIButton m_BtnMembers;

		// Token: 0x040076A6 RID: 30374
		public IXUIButton m_BtnApprove;

		// Token: 0x040076A7 RID: 30375
		public IXUIButton m_BtnDonate;

		// Token: 0x040076A8 RID: 30376
		public IXUIButton m_BtnGZ;

		// Token: 0x040076A9 RID: 30377
		public IXUIButton m_BtnRedPacker;

		// Token: 0x040076AA RID: 30378
		public IXUIButton m_BtnDmx;

		// Token: 0x040076AB RID: 30379
		public IXUIButton m_BtnJoker;

		// Token: 0x040076AC RID: 30380
		public IXUIButton m_BtnConsider;

		// Token: 0x040076AD RID: 30381
		public IXUIButton m_BtnBuild;

		// Token: 0x040076AE RID: 30382
		public IXUIButton m_BtnWXGroup;

		// Token: 0x040076AF RID: 30383
		public IXUIButton m_BtnWXGroupShare;

		// Token: 0x040076B0 RID: 30384
		public IXUILabel m_WXGroupTip;

		// Token: 0x040076B1 RID: 30385
		public IXUIButton m_BtnQQGroup;

		// Token: 0x040076B2 RID: 30386
		public IXUILabel m_QQGroupTip;

		// Token: 0x040076B3 RID: 30387
		public IXUILabel m_QQGroupName;

		// Token: 0x040076B4 RID: 30388
		public IXUISprite m_Portrait;

		// Token: 0x040076B5 RID: 30389
		public IXUISprite m_LivenessTipSprite;

		// Token: 0x040076B6 RID: 30390
		public IXUILabel m_LivenessTipsLabel;

		// Token: 0x040076B7 RID: 30391
		public IXUISprite m_PopularityTipSprite;

		// Token: 0x040076B8 RID: 30392
		public IXUILabel m_PopularityTipLabel;

		// Token: 0x040076B9 RID: 30393
		public IXUISprite m_ExpTipsSprite;

		// Token: 0x040076BA RID: 30394
		public IXUILabel m_ExpTipsLabel;

		// Token: 0x040076BB RID: 30395
		public IXUILabel m_Annoucement;

		// Token: 0x040076BC RID: 30396
		public GameObject m_EditAnnouncePanel;

		// Token: 0x040076BD RID: 30397
		public GameObject m_LogPanel;

		// Token: 0x040076BE RID: 30398
		public List<IXUIButton> m_checkGuildList = new List<IXUIButton>();

		// Token: 0x040076BF RID: 30399
		public XGuildBasicInfoDisplay m_BasicInfoDisplay = new XGuildBasicInfoDisplay();

		// Token: 0x040076C0 RID: 30400
		public XUIPool m_ShielterItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040076C1 RID: 30401
		public Transform m_GrowthBuffHelpFrame;

		// Token: 0x040076C2 RID: 30402
		public IXUILabel m_GrowthBuffHelpLabel;
	}
}
