using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A62 RID: 2658
	internal class XGuildGrowthBuffBehavior : DlgBehaviourBase
	{
		// Token: 0x0600A13F RID: 41279 RVA: 0x001B3A28 File Offset: 0x001B1C28
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
			this.m_DetailCostArrow = (base.transform.FindChild("Bg/Detail/CurrentAttr/P").GetComponent("XUISprite") as IXUISprite);
			this.m_DetailNextKeepCost = (base.transform.FindChild("Bg/Detail/CurrentAttr/NextAttr").GetComponent("XUILabel") as IXUILabel);
			this.m_NextAttrText = (base.transform.FindChild("Bg/Detail/NextText").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailCost = (base.transform.FindChild("Bg/Detail/Cost").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.LevelUpBtn = (base.transform.Find("Bg/Detail/Levelup").GetComponent("XUIButton") as IXUIButton);
			this.LevelUpText = (base.transform.FindChild("Bg/Detail/Levelup/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_levelUpFx = base.transform.Find("Bg/SkillList/effect");
			this.m_levelUpFx.gameObject.SetActive(false);
			this.ScrollView = (base.transform.Find("Bg/SkillList").GetComponent("XUIScrollView") as IXUIScrollView);
			GameObject gameObject = base.transform.Find("Bg/SkillList/SkillTpl").gameObject;
			this.BuffItemPool.SetupPool(gameObject.transform.parent.gameObject, gameObject, 10U, false);
			this.m_PointLeft = (base.transform.FindChild("Bg/Point/value").GetComponent("XUILabel") as IXUILabel);
			this.m_PointClick = (base.transform.FindChild("Bg/Point/P").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x040039FF RID: 14847
		public IXUIButton CloseBtn;

		// Token: 0x04003A00 RID: 14848
		public IXUIButton HelpBtn;

		// Token: 0x04003A01 RID: 14849
		public IXUISprite m_DetailBuffIcon;

		// Token: 0x04003A02 RID: 14850
		public IXUILabel m_DetailBuffName;

		// Token: 0x04003A03 RID: 14851
		public IXUILabel m_DetailMaxLevel;

		// Token: 0x04003A04 RID: 14852
		public IXUILabel m_DetailCurrLevel;

		// Token: 0x04003A05 RID: 14853
		public IXUILabel m_DetailNextLevel;

		// Token: 0x04003A06 RID: 14854
		public IXUILabel m_DetailCurrKeepCost;

		// Token: 0x04003A07 RID: 14855
		public IXUISprite m_DetailCostArrow;

		// Token: 0x04003A08 RID: 14856
		public IXUILabel m_DetailNextKeepCost;

		// Token: 0x04003A09 RID: 14857
		public IXUILabel m_NextAttrText;

		// Token: 0x04003A0A RID: 14858
		public IXUILabelSymbol m_DetailCost;

		// Token: 0x04003A0B RID: 14859
		public IXUIButton LevelUpBtn;

		// Token: 0x04003A0C RID: 14860
		public IXUILabel LevelUpText;

		// Token: 0x04003A0D RID: 14861
		public Transform m_levelUpFx;

		// Token: 0x04003A0E RID: 14862
		public IXUIScrollView ScrollView;

		// Token: 0x04003A0F RID: 14863
		public XUIPool BuffItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003A10 RID: 14864
		public IXUILabel m_PointLeft;

		// Token: 0x04003A11 RID: 14865
		public IXUISprite m_PointClick;
	}
}
