using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildSkillBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_GuildPoint = (base.transform.FindChild("Bg/Point/value").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailSkillIcon = (base.transform.FindChild("Bg/Detail/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_DetailSkillName = (base.transform.FindChild("Bg/Detail/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailCurrLevel = (base.transform.FindChild("Bg/Detail/CurrentLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailNextLevel = (base.transform.FindChild("Bg/Detail/CurrentLevel/NextLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailCurrAttr = (base.transform.FindChild("Bg/Detail/CurrentAttr").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailNextAttr = (base.transform.FindChild("Bg/Detail/CurrentAttr/NextAttr").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailMaxLevel = (base.transform.FindChild("Bg/Detail/MaxLevel/NextAttr").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailMaxLevelLabel = (base.transform.FindChild("Bg/Detail/MaxLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailUpMaxLevel = (base.transform.FindChild("Bg/Detail/MaxLevel/Study").GetComponent("XUIButton") as IXUIButton);
			this.m_RedPoint = base.transform.FindChild("Bg/Detail/MaxLevel/Study/RedPoint");
			this.m_DetailTip = (base.transform.FindChild("Bg/Detail/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailCost = (base.transform.FindChild("Bg/Detail/Cost").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_DetailCostRed = (base.transform.FindChild("Bg/Detail/CostRed").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_LevelUp = (base.transform.FindChild("Bg/Detail/Levelup").GetComponent("XUIButton") as IXUIButton);
			this.m_LevelUpLabel = (base.transform.FindChild("Bg/Detail/Levelup/Text").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/SkillList/SkillTpl");
			this.m_SkillPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			this.m_SkillScroll = (base.transform.FindChild("Bg/SkillList").GetComponent("XUIScrollView") as IXUIScrollView);
		}

		public IXUIButton m_Close;

		public IXUILabel m_GuildPoint;

		public IXUISprite m_DetailSkillIcon;

		public IXUILabel m_DetailSkillName;

		public IXUILabel m_DetailCurrLevel;

		public IXUILabel m_DetailNextLevel;

		public IXUILabel m_DetailCurrAttr;

		public IXUILabel m_DetailNextAttr;

		public IXUILabel m_DetailMaxLevelLabel;

		public IXUILabel m_DetailMaxLevel;

		public IXUIButton m_DetailUpMaxLevel;

		public IXUILabel m_DetailTip;

		public IXUILabelSymbol m_DetailCost;

		public IXUILabelSymbol m_DetailCostRed;

		public IXUIButton m_LevelUp;

		public IXUILabel m_LevelUpLabel;

		public Transform m_RedPoint;

		public XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_SkillScroll;
	}
}
