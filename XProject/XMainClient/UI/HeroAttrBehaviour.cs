using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017CC RID: 6092
	internal class HeroAttrBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600FC6B RID: 64619 RVA: 0x003ADE00 File Offset: 0x003AC000
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_HeroFrame = base.transform.Find("HeroFrame").gameObject;
			this.m_SkillFrame = base.transform.Find("SkillFrame").gameObject;
			this.m_GamePlayFrame = base.transform.Find("GamePlayFrame").gameObject;
			for (int i = 0; i < 3; i++)
			{
				this.m_Tab[i] = (base.transform.Find(string.Format("Tabs/Tab{0}", i)).GetComponent("XUICheckBox") as IXUICheckBox);
			}
			this.m_HeroIcon = (this.m_HeroFrame.transform.Find("Left/Hero").GetComponent("XUISprite") as IXUISprite);
			this.m_HeroName = (this.m_HeroFrame.transform.Find("Left/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_HeroSmallTips = (this.m_HeroFrame.transform.Find("Left/ScrollView/Desc").GetComponent("XUILabel") as IXUILabel);
			this.m_DescScrollView = (this.m_HeroFrame.transform.Find("Left/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform = this.m_HeroFrame.transform.Find("Panel/Tpl");
			this.m_AttrPool.SetupPool(transform.parent.gameObject, transform.gameObject, 15U, false);
			transform = this.m_SkillFrame.transform.Find("Panel/Tpl");
			this.m_SkillPool.SetupPool(transform.parent.gameObject, transform.gameObject, 15U, false);
			this.m_ScrollView = (this.m_SkillFrame.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_GamePlayTips = (this.m_GamePlayFrame.transform.Find("ScrollView/Desc").GetComponent("XUILabel") as IXUILabel);
			this.m_GamePlayScrollView = (this.m_GamePlayFrame.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
		}

		// Token: 0x04006EED RID: 28397
		public IXUIButton m_Close;

		// Token: 0x04006EEE RID: 28398
		public GameObject m_HeroFrame;

		// Token: 0x04006EEF RID: 28399
		public GameObject m_SkillFrame;

		// Token: 0x04006EF0 RID: 28400
		public GameObject m_GamePlayFrame;

		// Token: 0x04006EF1 RID: 28401
		public IXUICheckBox[] m_Tab = new IXUICheckBox[3];

		// Token: 0x04006EF2 RID: 28402
		public IXUISprite m_HeroIcon;

		// Token: 0x04006EF3 RID: 28403
		public IXUILabel m_HeroName;

		// Token: 0x04006EF4 RID: 28404
		public IXUILabel m_HeroSmallTips;

		// Token: 0x04006EF5 RID: 28405
		public IXUIScrollView m_DescScrollView;

		// Token: 0x04006EF6 RID: 28406
		public XUIPool m_AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006EF7 RID: 28407
		public XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006EF8 RID: 28408
		public IXUIScrollView m_ScrollView;

		// Token: 0x04006EF9 RID: 28409
		public IXUILabel m_GamePlayTips;

		// Token: 0x04006EFA RID: 28410
		public IXUIScrollView m_GamePlayScrollView;
	}
}
