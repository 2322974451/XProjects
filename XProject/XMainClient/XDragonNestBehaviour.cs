using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CD1 RID: 3281
	internal class XDragonNestBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B7FF RID: 47103 RVA: 0x0024CEB8 File Offset: 0x0024B0B8
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_quanMinSpr = (base.transform.Find("Bg/qmms").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.transform.Find("Bg/Tab/Panel/TabTpl");
			this.m_TabTplPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.m_DiffEasyCheckBox = (base.transform.Find("Bg/ToggleDiffEasy").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_DiffNormalCheckBox = (base.transform.Find("Bg/ToggleDiffNormal").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_DiffHardCheckBox = (base.transform.Find("Bg/ToggleDiffHard").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_DiffHardLock = (base.transform.Find("Bg/ToggleDiffHard/Lock").GetComponent("XUISprite") as IXUISprite);
			this.m_NestName = (base.transform.Find("Bg/DetailFrame/NestName").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalCurPPT = (base.transform.Find("Bg/DetailFrame/DiffNormal/CurPPT").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalSugPPT = (base.transform.Find("Bg/DetailFrame/DiffNormal/SugPPT").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalSugAttr = (base.transform.Find("Bg/DetailFrame/DiffNormal/SugAttr").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalSugLevel = (base.transform.Find("Bg/DetailFrame/DiffNormal/SugLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalSugMember = (base.transform.Find("Bg/DetailFrame/DiffNormal/SugMember").GetComponent("XUILabel") as IXUILabel);
			this.m_EasySugAttr = (base.transform.Find("Bg/DetailFrame/DiffEasy/SugAttr").GetComponent("XUILabel") as IXUILabel);
			this.m_EasySugLevel = (base.transform.Find("Bg/DetailFrame/DiffEasy/SugLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_EasySugMember = (base.transform.Find("Bg/DetailFrame/DiffEasy/SugMember").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalDetail = base.transform.Find("Bg/DetailFrame/DiffNormal");
			this.m_EasyDetail = base.transform.Find("Bg/DetailFrame/DiffEasy");
			this.m_WeakPPTFrame = base.transform.Find("Bg/DetailFrame/DiffNormal/WeakPPT");
			this.m_WeakPPT = (base.transform.Find("Bg/DetailFrame/DiffNormal/WeakPPT/PPT").GetComponent("XUILabel") as IXUILabel);
			this.m_WeakPPTHelp = (base.transform.Find("Bg/DetailFrame/DiffNormal/WeakPPT/Help").GetComponent("XUISprite") as IXUISprite);
			this.m_NestFrameNormal = base.transform.Find("Bg/NestFrameNormal");
			transform = base.transform.Find("Bg/NestFrameNormal/NestTpl");
			this.m_NestNormalTplPool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			this.m_NestNormalBg = (base.transform.Find("Bg/NestFrameNormal/Bg").GetComponent("XUITexture") as IXUITexture);
			this.m_WeakTip = base.transform.Find("Bg/NestFrameNormal/WeakTip/Tips");
			this.m_WeakName = (base.transform.Find("Bg/NestFrameNormal/WeakTip/Tips/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_WeakTip1 = (base.transform.Find("Bg/NestFrameNormal/WeakTip/Tips/Tip1").GetComponent("XUILabel") as IXUILabel);
			this.m_WeakTip2 = (base.transform.Find("Bg/NestFrameNormal/WeakTip/Tips/Tip2").GetComponent("XUILabel") as IXUILabel);
			this.m_WeakBlock = (base.transform.Find("Bg/NestFrameNormal/Block").GetComponent("XUISprite") as IXUISprite);
			this.m_WeakPercent = (base.transform.Find("Bg/NestFrameNormal/WeakTip/Percent").GetComponent("XUILabel") as IXUILabel);
			this.m_NestFrameHard = base.transform.Find("Bg/NestFrameHard");
			this.m_NestHardName = (base.transform.Find("Bg/NestFrameHard/NestTpl/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_NestHardBossIcon = (base.transform.Find("Bg/NestFrameHard/NestTpl/Boss").GetComponent("XUITexture") as IXUITexture);
			this.m_NestHardBg = (base.transform.Find("Bg/NestFrameHard/Bg").GetComponent("XUITexture") as IXUITexture);
			transform = base.transform.Find("Bg/ItemList/ItemTpl");
			this.m_ItemTplPool.SetupPool(transform.parent.gameObject, transform.gameObject, 8U, false);
			this.m_SweepButton = (base.transform.Find("Bg/SweepButton").GetComponent("XUIButton") as IXUIButton);
			this.m_SweepCostItem = base.transform.Find("Bg/SweepButton/Item").gameObject;
			this.m_SweepCostItemNum = (base.transform.Find("Bg/SweepButton/Item/Cost").GetComponent("XUILabel") as IXUILabel);
			this.m_EnterButton = (base.transform.Find("Bg/Enter").GetComponent("XUIButton") as IXUIButton);
			this.m_CostItem = base.transform.Find("Bg/ItemTpl").gameObject;
			this.m_CostItemNum = (base.transform.Find("Bg/ItemTpl/Cost").GetComponent("XUILabel") as IXUILabel);
			this.m_EnterText = (base.transform.Find("Bg/Enter/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_ResertTip = (base.transform.Find("Bg/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUISprite") as IXUISprite);
			this.m_HelpFrame = base.transform.Find("Bg/HelpFrame");
			this.m_HelpTip = (base.transform.Find("Bg/HelpFrame/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_HelpClose = (base.transform.Find("Bg/HelpFrame/Block").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x0400488B RID: 18571
		public IXUIButton m_Close;

		// Token: 0x0400488C RID: 18572
		public XUIPool m_TabTplPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400488D RID: 18573
		public IXUILabel m_NestName;

		// Token: 0x0400488E RID: 18574
		public IXUILabel m_NormalCurPPT;

		// Token: 0x0400488F RID: 18575
		public IXUILabel m_NormalSugPPT;

		// Token: 0x04004890 RID: 18576
		public IXUILabel m_NormalSugAttr;

		// Token: 0x04004891 RID: 18577
		public IXUILabel m_NormalSugLevel;

		// Token: 0x04004892 RID: 18578
		public IXUILabel m_NormalSugMember;

		// Token: 0x04004893 RID: 18579
		public IXUILabel m_EasySugAttr;

		// Token: 0x04004894 RID: 18580
		public IXUILabel m_EasySugLevel;

		// Token: 0x04004895 RID: 18581
		public IXUILabel m_EasySugMember;

		// Token: 0x04004896 RID: 18582
		public Transform m_NormalDetail;

		// Token: 0x04004897 RID: 18583
		public Transform m_EasyDetail;

		// Token: 0x04004898 RID: 18584
		public Transform m_WeakPPTFrame;

		// Token: 0x04004899 RID: 18585
		public IXUILabel m_WeakPPT;

		// Token: 0x0400489A RID: 18586
		public IXUISprite m_WeakPPTHelp;

		// Token: 0x0400489B RID: 18587
		public IXUICheckBox m_DiffEasyCheckBox;

		// Token: 0x0400489C RID: 18588
		public IXUICheckBox m_DiffNormalCheckBox;

		// Token: 0x0400489D RID: 18589
		public IXUICheckBox m_DiffHardCheckBox;

		// Token: 0x0400489E RID: 18590
		public IXUISprite m_DiffHardLock;

		// Token: 0x0400489F RID: 18591
		public IXUISprite m_quanMinSpr;

		// Token: 0x040048A0 RID: 18592
		public Transform m_NestFrameNormal;

		// Token: 0x040048A1 RID: 18593
		public XUIPool m_NestNormalTplPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040048A2 RID: 18594
		public IXUITexture m_NestNormalBg;

		// Token: 0x040048A3 RID: 18595
		public Transform m_WeakTip;

		// Token: 0x040048A4 RID: 18596
		public IXUILabel m_WeakName;

		// Token: 0x040048A5 RID: 18597
		public IXUILabel m_WeakTip1;

		// Token: 0x040048A6 RID: 18598
		public IXUILabel m_WeakTip2;

		// Token: 0x040048A7 RID: 18599
		public IXUISprite m_WeakBlock;

		// Token: 0x040048A8 RID: 18600
		public IXUILabel m_WeakPercent;

		// Token: 0x040048A9 RID: 18601
		public Transform m_NestFrameHard;

		// Token: 0x040048AA RID: 18602
		public IXUILabel m_NestHardName;

		// Token: 0x040048AB RID: 18603
		public IXUITexture m_NestHardBossIcon;

		// Token: 0x040048AC RID: 18604
		public IXUITexture m_NestHardBg;

		// Token: 0x040048AD RID: 18605
		public XUIPool m_ItemTplPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040048AE RID: 18606
		public IXUIButton m_SweepButton;

		// Token: 0x040048AF RID: 18607
		public GameObject m_SweepCostItem;

		// Token: 0x040048B0 RID: 18608
		public IXUILabel m_SweepCostItemNum;

		// Token: 0x040048B1 RID: 18609
		public IXUIButton m_EnterButton;

		// Token: 0x040048B2 RID: 18610
		public GameObject m_CostItem;

		// Token: 0x040048B3 RID: 18611
		public IXUILabel m_CostItemNum;

		// Token: 0x040048B4 RID: 18612
		public IXUILabel m_EnterText;

		// Token: 0x040048B5 RID: 18613
		public IXUILabel m_ResertTip;

		// Token: 0x040048B6 RID: 18614
		public IXUISprite m_Help;

		// Token: 0x040048B7 RID: 18615
		public Transform m_HelpFrame;

		// Token: 0x040048B8 RID: 18616
		public IXUILabel m_HelpTip;

		// Token: 0x040048B9 RID: 18617
		public IXUISprite m_HelpClose;
	}
}
