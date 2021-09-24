using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonNestBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton m_Close;

		public XUIPool m_TabTplPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_NestName;

		public IXUILabel m_NormalCurPPT;

		public IXUILabel m_NormalSugPPT;

		public IXUILabel m_NormalSugAttr;

		public IXUILabel m_NormalSugLevel;

		public IXUILabel m_NormalSugMember;

		public IXUILabel m_EasySugAttr;

		public IXUILabel m_EasySugLevel;

		public IXUILabel m_EasySugMember;

		public Transform m_NormalDetail;

		public Transform m_EasyDetail;

		public Transform m_WeakPPTFrame;

		public IXUILabel m_WeakPPT;

		public IXUISprite m_WeakPPTHelp;

		public IXUICheckBox m_DiffEasyCheckBox;

		public IXUICheckBox m_DiffNormalCheckBox;

		public IXUICheckBox m_DiffHardCheckBox;

		public IXUISprite m_DiffHardLock;

		public IXUISprite m_quanMinSpr;

		public Transform m_NestFrameNormal;

		public XUIPool m_NestNormalTplPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUITexture m_NestNormalBg;

		public Transform m_WeakTip;

		public IXUILabel m_WeakName;

		public IXUILabel m_WeakTip1;

		public IXUILabel m_WeakTip2;

		public IXUISprite m_WeakBlock;

		public IXUILabel m_WeakPercent;

		public Transform m_NestFrameHard;

		public IXUILabel m_NestHardName;

		public IXUITexture m_NestHardBossIcon;

		public IXUITexture m_NestHardBg;

		public XUIPool m_ItemTplPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIButton m_SweepButton;

		public GameObject m_SweepCostItem;

		public IXUILabel m_SweepCostItemNum;

		public IXUIButton m_EnterButton;

		public GameObject m_CostItem;

		public IXUILabel m_CostItemNum;

		public IXUILabel m_EnterText;

		public IXUILabel m_ResertTip;

		public IXUISprite m_Help;

		public Transform m_HelpFrame;

		public IXUILabel m_HelpTip;

		public IXUISprite m_HelpClose;
	}
}
