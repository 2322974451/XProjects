using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSkillTreeBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_TransferFrame = base.transform.Find("Bg/TransferFrame").gameObject;
			this.m_SkillTreeFrame = base.transform.Find("Bg/SkillTreeFrame").gameObject;
			this.m_FreeResetSkillTip = (this.m_SkillTreeFrame.transform.Find("Other/ResetTip").GetComponent("XUILabel") as IXUILabel);
			this.m_UseSkillPoint = (this.m_SkillTreeFrame.transform.Find("Other/UsePoint").GetComponent("XUILabel") as IXUILabel);
			this.m_UseAwakeSkillPoint = (this.m_SkillTreeFrame.transform.Find("Other/UseAwakePoint").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftSkillPoint = (this.m_SkillTreeFrame.transform.Find("Other/LeftPoint").GetComponent("XUILabel") as IXUILabel);
			this.m_ResetProBtn = (this.m_SkillTreeFrame.transform.Find("Other/ResetProf").GetComponent("XUISprite") as IXUISprite);
			this.m_ResetSkillBtn = (this.m_SkillTreeFrame.transform.Find("Other/ResetSkillPoint").GetComponent("XUISprite") as IXUISprite);
			this.m_SwitchSkillPageBtn = (this.m_SkillTreeFrame.transform.Find("Other/SwitchSkillPage").GetComponent("XUISprite") as IXUISprite);
			this.m_SkillPageText = (this.m_SkillTreeFrame.transform.Find("Other/SwitchSkillPage/Text").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.Find("Bg/Tabs/Tpl");
			this.m_Tabs.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			transform = this.m_SkillTreeFrame.transform.Find("SkillTree/Skill/SkillTpl");
			this.m_SkillPool.SetupPool(transform.parent.gameObject, transform.gameObject, 16U, false);
			transform = this.m_SkillTreeFrame.transform.Find("SkillTree/Arrow/ArrowTpl");
			this.m_ArrowPool.SetupPool(transform.parent.gameObject, transform.gameObject, 16U, false);
			this.m_SkillTreeScrollView = (this.m_SkillTreeFrame.transform.Find("SkillTree").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_LevelUpFx = this.m_SkillTreeFrame.transform.Find("SkillTree/effect").gameObject;
			this.m_LevelUpFx.SetActive(false);
			this.m_CatchFrameTween = (this.m_SkillTreeFrame.transform.Find("CatchWindow").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_DetailFrameTween = (this.m_SkillTreeFrame.transform.Find("DetailWindow").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_ChooseBtn = (this.m_SkillTreeFrame.transform.Find("DetailWindow/DetailSkillBg/CatchButton").GetComponent("XUIButton") as IXUIButton);
			this.m_LearnBtn = (this.m_SkillTreeFrame.transform.Find("DetailWindow/DetailSkillBg/LearnButton").GetComponent("XUIButton") as IXUIButton);
			this.m_CatchBackBtn = (this.m_SkillTreeFrame.transform.Find("CatchWindow/BackButton").GetComponent("XUIButton") as IXUIButton);
			this.m_SkillPlayBtn = (this.m_SkillTreeFrame.transform.Find("DetailWindow/DetailSkillBg/Snapshot/Play").GetComponent("XUISprite") as IXUISprite);
			this.m_SkillLearnRedPoint = this.m_LearnBtn.gameObject.transform.Find("RedPoint").gameObject;
			this.m_NonPreView = this.m_SkillTreeFrame.transform.Find("DetailWindow/DetailSkillBg/NonPreView").gameObject;
			this.m_Snapshot = (this.m_SkillTreeFrame.transform.Find("DetailWindow/DetailSkillBg/Snapshot").GetComponent("XUITexture") as IXUITexture);
			for (int i = 0; i < XSkillTreeDocument.SkillSlotCount; i++)
			{
				this.m_SkillSlotList[i] = (this.m_SkillTreeFrame.transform.Find(string.Format("CatchWindow/BaseSkill/Skill{0}", i)).GetComponent("XUISprite") as IXUISprite);
				this.m_SkillSlotList[i].ID = (ulong)((long)i);
			}
			this.DetailSkillFrame = this.m_SkillTreeFrame.transform.Find("DetailWindow/DetailSkillBg");
			this.m_SkillDetailScrollView = (this.DetailSkillFrame.Find("DetailSkill").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_SkillName_L = (this.DetailSkillFrame.Find("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillType_L = (this.DetailSkillFrame.Find("Name/Type").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillAttrText = (this.DetailSkillFrame.Find("Attr/AttrT").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillCostText = (this.DetailSkillFrame.Find("Attr/CostT").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillCDText = (this.DetailSkillFrame.Find("Attr/CDT").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillDetail_L = (this.DetailSkillFrame.Find("DetailSkill/Detail/SkillDetail").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillCurrDesc = (this.DetailSkillFrame.Find("DetailSkill/Current/CurDesc").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillPreSkillPointTips = (this.DetailSkillFrame.Find("DetailSkill/Current/UnLearn").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillNextDesc = (this.DetailSkillFrame.Find("DetailSkill/Next/NextDesc").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillNextReq = (this.DetailSkillFrame.Find("DetailSkill/Next/RequieLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_SuperIndureAttack = (this.DetailSkillFrame.Find("DetailSkill/Indure/Attack/T").GetComponent("XUILabel") as IXUILabel);
			this.m_SuperIndureDenfense = (this.DetailSkillFrame.Find("DetailSkill/Indure/Defense/T").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillName_S = (this.m_SkillTreeFrame.transform.Find("CatchWindow/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillType_S = (this.m_SkillTreeFrame.transform.Find("CatchWindow/Name/Type").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillDetailScrollView_S = (this.m_SkillTreeFrame.transform.Find("CatchWindow/DragBox/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_SkillDetail_S = (this.m_SkillTreeFrame.transform.Find("CatchWindow/DragBox/ScrollView/SkillDetail").GetComponent("XUILabel") as IXUILabel);
			this.m_ChooseTips = (this.m_SkillTreeFrame.transform.Find("CatchWindow/Tips").GetComponent("XUILabel") as IXUILabel);
			this.m_FxFirework = base.transform.Find("Bg/FxFirework");
		}

		public IXUIButton m_Close;

		public GameObject m_TransferFrame;

		public GameObject m_SkillTreeFrame;

		public IXUISprite m_ResetProBtn;

		public IXUISprite m_ResetSkillBtn;

		public IXUISprite m_SwitchSkillPageBtn;

		public IXUILabel m_SkillPageText;

		public IXUILabel m_UseSkillPoint;

		public IXUILabel m_UseAwakeSkillPoint;

		public IXUILabel m_LeftSkillPoint;

		public IXUILabel m_FreeResetSkillTip;

		public IXUIScrollView m_SkillTreeScrollView;

		public XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_ArrowPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public GameObject m_LevelUpFx;

		public IXUITweenTool m_CatchFrameTween;

		public IXUITweenTool m_DetailFrameTween;

		public IXUIButton m_CatchBackBtn;

		public IXUIButton m_ChooseBtn;

		public IXUIButton m_LearnBtn;

		public IXUISprite m_SkillPlayBtn;

		public GameObject m_SkillLearnRedPoint;

		public GameObject m_NonPreView;

		public IXUITexture m_Snapshot;

		public IXUISprite[] m_SkillSlotList = new IXUISprite[XSkillTreeDocument.SkillSlotCount];

		public IXUIScrollView m_SkillDetailScrollView;

		public Transform DetailSkillFrame;

		public IXUILabel m_SkillName_L;

		public IXUILabel m_SkillType_L;

		public IXUILabel m_SkillAttrText;

		public IXUILabel m_SkillCostText;

		public IXUILabel m_SkillCDText;

		public IXUILabel m_SkillDetail_L;

		public IXUILabel m_SkillCurrDesc;

		public IXUILabel m_SkillPreSkillPointTips;

		public IXUILabel m_SkillNextDesc;

		public IXUILabel m_SkillNextReq;

		public IXUILabel m_SuperIndureAttack;

		public IXUILabel m_SuperIndureDenfense;

		public IXUILabel m_SkillName_S;

		public IXUILabel m_SkillType_S;

		public IXUILabel m_SkillDetail_S;

		public IXUIScrollView m_SkillDetailScrollView_S;

		public IXUILabel m_ChooseTips;

		public Transform m_FxFirework;

		public XUIPool m_Tabs = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
