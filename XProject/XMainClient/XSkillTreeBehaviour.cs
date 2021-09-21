using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E5B RID: 3675
	internal class XSkillTreeBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C4E5 RID: 50405 RVA: 0x002B2648 File Offset: 0x002B0848
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

		// Token: 0x040055E1 RID: 21985
		public IXUIButton m_Close;

		// Token: 0x040055E2 RID: 21986
		public GameObject m_TransferFrame;

		// Token: 0x040055E3 RID: 21987
		public GameObject m_SkillTreeFrame;

		// Token: 0x040055E4 RID: 21988
		public IXUISprite m_ResetProBtn;

		// Token: 0x040055E5 RID: 21989
		public IXUISprite m_ResetSkillBtn;

		// Token: 0x040055E6 RID: 21990
		public IXUISprite m_SwitchSkillPageBtn;

		// Token: 0x040055E7 RID: 21991
		public IXUILabel m_SkillPageText;

		// Token: 0x040055E8 RID: 21992
		public IXUILabel m_UseSkillPoint;

		// Token: 0x040055E9 RID: 21993
		public IXUILabel m_UseAwakeSkillPoint;

		// Token: 0x040055EA RID: 21994
		public IXUILabel m_LeftSkillPoint;

		// Token: 0x040055EB RID: 21995
		public IXUILabel m_FreeResetSkillTip;

		// Token: 0x040055EC RID: 21996
		public IXUIScrollView m_SkillTreeScrollView;

		// Token: 0x040055ED RID: 21997
		public XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040055EE RID: 21998
		public XUIPool m_ArrowPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040055EF RID: 21999
		public GameObject m_LevelUpFx;

		// Token: 0x040055F0 RID: 22000
		public IXUITweenTool m_CatchFrameTween;

		// Token: 0x040055F1 RID: 22001
		public IXUITweenTool m_DetailFrameTween;

		// Token: 0x040055F2 RID: 22002
		public IXUIButton m_CatchBackBtn;

		// Token: 0x040055F3 RID: 22003
		public IXUIButton m_ChooseBtn;

		// Token: 0x040055F4 RID: 22004
		public IXUIButton m_LearnBtn;

		// Token: 0x040055F5 RID: 22005
		public IXUISprite m_SkillPlayBtn;

		// Token: 0x040055F6 RID: 22006
		public GameObject m_SkillLearnRedPoint;

		// Token: 0x040055F7 RID: 22007
		public GameObject m_NonPreView;

		// Token: 0x040055F8 RID: 22008
		public IXUITexture m_Snapshot;

		// Token: 0x040055F9 RID: 22009
		public IXUISprite[] m_SkillSlotList = new IXUISprite[XSkillTreeDocument.SkillSlotCount];

		// Token: 0x040055FA RID: 22010
		public IXUIScrollView m_SkillDetailScrollView;

		// Token: 0x040055FB RID: 22011
		public Transform DetailSkillFrame;

		// Token: 0x040055FC RID: 22012
		public IXUILabel m_SkillName_L;

		// Token: 0x040055FD RID: 22013
		public IXUILabel m_SkillType_L;

		// Token: 0x040055FE RID: 22014
		public IXUILabel m_SkillAttrText;

		// Token: 0x040055FF RID: 22015
		public IXUILabel m_SkillCostText;

		// Token: 0x04005600 RID: 22016
		public IXUILabel m_SkillCDText;

		// Token: 0x04005601 RID: 22017
		public IXUILabel m_SkillDetail_L;

		// Token: 0x04005602 RID: 22018
		public IXUILabel m_SkillCurrDesc;

		// Token: 0x04005603 RID: 22019
		public IXUILabel m_SkillPreSkillPointTips;

		// Token: 0x04005604 RID: 22020
		public IXUILabel m_SkillNextDesc;

		// Token: 0x04005605 RID: 22021
		public IXUILabel m_SkillNextReq;

		// Token: 0x04005606 RID: 22022
		public IXUILabel m_SuperIndureAttack;

		// Token: 0x04005607 RID: 22023
		public IXUILabel m_SuperIndureDenfense;

		// Token: 0x04005608 RID: 22024
		public IXUILabel m_SkillName_S;

		// Token: 0x04005609 RID: 22025
		public IXUILabel m_SkillType_S;

		// Token: 0x0400560A RID: 22026
		public IXUILabel m_SkillDetail_S;

		// Token: 0x0400560B RID: 22027
		public IXUIScrollView m_SkillDetailScrollView_S;

		// Token: 0x0400560C RID: 22028
		public IXUILabel m_ChooseTips;

		// Token: 0x0400560D RID: 22029
		public Transform m_FxFirework;

		// Token: 0x0400560E RID: 22030
		public XUIPool m_Tabs = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
