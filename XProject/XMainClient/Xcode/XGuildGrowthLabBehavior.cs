using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildGrowthLabBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.HelpBtn = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_DetailBuffIcon = (base.transform.FindChild("Bg/Detail/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_DetailBuffName = (base.transform.FindChild("Bg/Detail/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailMaxLevel = (base.transform.FindChild("Bg/Detail/MaxLevel/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailCurrLevel = (base.transform.FindChild("Bg/Detail/CurrentLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailNextLevel = (base.transform.FindChild("Bg/Detail/CurrentLevel/NextLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailCurrKeepCost = (base.transform.FindChild("Bg/Detail/CurrentAttr").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailNextKeepCost = (base.transform.FindChild("Bg/Detail/CurrentAttr/NextAttr").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailCost = (base.transform.FindChild("Bg/Detail/Cost").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.LevelUpBtn = (base.transform.Find("Bg/Detail/Levelup").GetComponent("XUIButton") as IXUIButton);
			this.LevelUpText = (base.transform.FindChild("Bg/Detail/Levelup/Text").GetComponent("XUILabel") as IXUILabel);
			this.ScrollView = (base.transform.Find("Bg/SkillList").GetComponent("XUIScrollView") as IXUIScrollView);
			GameObject gameObject = base.transform.Find("Bg/SkillList/SkillTpl").gameObject;
			this.BuffItemPool.SetupPool(gameObject.transform.parent.gameObject, gameObject, 10U, false);
			this.m_PointLeft = (base.transform.FindChild("Bg/Point/value").GetComponent("XUILabel") as IXUILabel);
			this.m_PointClick = (base.transform.FindChild("Bg/Point/P").GetComponent("XUISprite") as IXUISprite);
		}

		public IXUIButton CloseBtn;

		public IXUIButton HelpBtn;

		public IXUISprite m_DetailBuffIcon;

		public IXUILabel m_DetailBuffName;

		public IXUILabel m_DetailMaxLevel;

		public IXUILabel m_DetailCurrLevel;

		public IXUILabel m_DetailNextLevel;

		public IXUILabel m_DetailCurrKeepCost;

		public IXUILabel m_DetailNextKeepCost;

		public IXUILabelSymbol m_DetailCost;

		public IXUIButton LevelUpBtn;

		public IXUILabel LevelUpText;

		public IXUIScrollView ScrollView;

		public XUIPool BuffItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_PointLeft;

		public IXUISprite m_PointClick;
	}
}
