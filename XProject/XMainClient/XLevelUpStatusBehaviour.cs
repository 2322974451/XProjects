using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelUpStatusBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_AttrFrame = base.transform.Find("Bg/AttrFrame").gameObject;
			this.m_FishFrame = base.transform.Find("Bg/FishFrame").gameObject;
			Transform transform = this.m_AttrFrame.transform.FindChild("AttrTpl");
			this.m_AttrPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.m_iPlayTween = (base.transform.FindChild("Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_NewSkillFrame = this.m_AttrFrame.transform.FindChild("NewSkillFrame");
			this.m_sprSkillBg = (this.m_AttrFrame.transform.Find("p").GetComponent("XUISprite") as IXUISprite);
			transform = this.m_NewSkillFrame.FindChild("SkillTpl");
			this.m_SkillPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_lblSkillPoint = (this.m_AttrFrame.transform.Find("SkillPoint/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_lblCurrLevel = (this.m_AttrFrame.transform.Find("CurLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_tweenLevel = (this.m_AttrFrame.transform.Find("CurLevel").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_PreFishingLevel = (this.m_FishFrame.transform.Find("PreLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_CurFishingLevel = (this.m_FishFrame.transform.Find("CurLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_FishingTitle = (this.m_FishFrame.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_objWing = base.transform.Find("UI_level").gameObject;
			this.m_lblLevel = (base.transform.Find("UI_level/LevelNum").GetComponent("XUILabel") as IXUILabel);
		}

		public XUIPool m_AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUITweenTool m_iPlayTween;

		public IXUIButton m_Close;

		public Transform m_NewSkillFrame;

		public XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUISprite m_sprSkillBg;

		public IXUILabel m_PreFishingLevel;

		public IXUILabel m_CurFishingLevel;

		public IXUILabel m_FishingTitle;

		public GameObject m_AttrFrame;

		public GameObject m_FishFrame;

		public GameObject m_objWing;

		public IXUILabel m_lblLevel;

		public IXUILabel m_lblSkillPoint;

		public IXUILabel m_lblCurrLevel;

		public IXUITweenTool m_tweenLevel;
	}
}
