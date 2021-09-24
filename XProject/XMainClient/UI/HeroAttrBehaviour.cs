using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HeroAttrBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton m_Close;

		public GameObject m_HeroFrame;

		public GameObject m_SkillFrame;

		public GameObject m_GamePlayFrame;

		public IXUICheckBox[] m_Tab = new IXUICheckBox[3];

		public IXUISprite m_HeroIcon;

		public IXUILabel m_HeroName;

		public IXUILabel m_HeroSmallTips;

		public IXUIScrollView m_DescScrollView;

		public XUIPool m_AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_ScrollView;

		public IXUILabel m_GamePlayTips;

		public IXUIScrollView m_GamePlayScrollView;
	}
}
