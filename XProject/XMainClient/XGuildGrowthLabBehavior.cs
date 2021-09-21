using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A68 RID: 2664
	internal class XGuildGrowthLabBehavior : DlgBehaviourBase
	{
		// Token: 0x0600A18F RID: 41359 RVA: 0x001B5758 File Offset: 0x001B3958
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

		// Token: 0x04003A33 RID: 14899
		public IXUIButton CloseBtn;

		// Token: 0x04003A34 RID: 14900
		public IXUIButton HelpBtn;

		// Token: 0x04003A35 RID: 14901
		public IXUISprite m_DetailBuffIcon;

		// Token: 0x04003A36 RID: 14902
		public IXUILabel m_DetailBuffName;

		// Token: 0x04003A37 RID: 14903
		public IXUILabel m_DetailMaxLevel;

		// Token: 0x04003A38 RID: 14904
		public IXUILabel m_DetailCurrLevel;

		// Token: 0x04003A39 RID: 14905
		public IXUILabel m_DetailNextLevel;

		// Token: 0x04003A3A RID: 14906
		public IXUILabel m_DetailCurrKeepCost;

		// Token: 0x04003A3B RID: 14907
		public IXUILabel m_DetailNextKeepCost;

		// Token: 0x04003A3C RID: 14908
		public IXUILabelSymbol m_DetailCost;

		// Token: 0x04003A3D RID: 14909
		public IXUIButton LevelUpBtn;

		// Token: 0x04003A3E RID: 14910
		public IXUILabel LevelUpText;

		// Token: 0x04003A3F RID: 14911
		public IXUIScrollView ScrollView;

		// Token: 0x04003A40 RID: 14912
		public XUIPool BuffItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003A41 RID: 14913
		public IXUILabel m_PointLeft;

		// Token: 0x04003A42 RID: 14914
		public IXUISprite m_PointClick;
	}
}
