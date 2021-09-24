using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XSpriteSkillTipBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Black").GetComponent("XUISprite") as IXUISprite);
			this.m_MainSkill = (base.transform.Find("Bg/Bg/ToolTipCaptian").GetComponent("XUISprite") as IXUISprite);
			this.m_MainTopFrame = (base.transform.Find("Bg/Bg/ToolTipCaptian/TopFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_MainMiddleFrame = (base.transform.Find("Bg/Bg/ToolTipCaptian/MiddleFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_MainBottomFrame = (base.transform.Find("Bg/Bg/ToolTipCaptian/BottomFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_MainSkillName = (this.m_MainSkill.gameObject.transform.Find("TopFrame/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_MainSkillType = (this.m_MainSkill.gameObject.transform.Find("TopFrame/Type").GetComponent("XUILabel") as IXUILabel);
			this.m_MainSkillLevel = (this.m_MainSkill.gameObject.transform.Find("TopFrame/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_MainIcon = (this.m_MainSkill.gameObject.transform.Find("TopFrame/ItemTpl/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_MainSkillDuration = (this.m_MainSkill.gameObject.transform.Find("TopFrame/Duration").GetComponent("XUILabel") as IXUILabel);
			this.m_MainDesc = (this.m_MainSkill.gameObject.transform.Find("MiddleFrame/Desc").GetComponent("XUILabel") as IXUILabel);
			this.m_MainCurrEffect = (this.m_MainSkill.gameObject.transform.Find("BottomFrame/CurrEffect").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalSkill = (base.transform.Find("Bg/Bg/ToolTipNormal").GetComponent("XUISprite") as IXUISprite);
			this.m_NormalTopFrame = (base.transform.Find("Bg/Bg/ToolTipNormal/TopFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_NormalMiddleFrame = (base.transform.Find("Bg/Bg/ToolTipNormal/BottomFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_NormalSkillName = (this.m_NormalSkill.gameObject.transform.Find("TopFrame/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalSkillType = (this.m_NormalSkill.gameObject.transform.Find("TopFrame/Type").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalSkillQuality = (this.m_NormalSkill.gameObject.transform.Find("TopFrame/Quality").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalIcon = (this.m_NormalSkill.gameObject.transform.Find("TopFrame/ItemTpl/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_NormalCurrEffect = (this.m_NormalSkill.gameObject.transform.Find("BottomFrame/Effect").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalIconQuality = (this.m_NormalSkill.gameObject.transform.Find("TopFrame/ItemTpl/Frame").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUISprite m_Close;

		public IXUISprite m_MainSkill;

		public IXUISprite m_MainTopFrame;

		public IXUISprite m_MainMiddleFrame;

		public IXUISprite m_MainBottomFrame;

		public IXUILabel m_MainSkillName;

		public IXUILabel m_MainSkillType;

		public IXUILabel m_MainSkillLevel;

		public IXUILabel m_MainCurrEffect;

		public IXUILabel m_MainDesc;

		public IXUISprite m_MainIcon;

		public IXUILabel m_MainSkillDuration;

		public IXUISprite m_NormalSkill;

		public IXUISprite m_NormalTopFrame;

		public IXUISprite m_NormalMiddleFrame;

		public IXUILabel m_NormalSkillName;

		public IXUILabel m_NormalSkillType;

		public IXUILabel m_NormalSkillQuality;

		public IXUILabel m_NormalCurrEffect;

		public IXUISprite m_NormalIcon;

		public IXUISprite m_NormalIconQuality;
	}
}
