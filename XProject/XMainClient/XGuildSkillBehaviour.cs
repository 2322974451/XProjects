using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E40 RID: 3648
	internal class XGuildSkillBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C3F4 RID: 50164 RVA: 0x002AA608 File Offset: 0x002A8808
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

		// Token: 0x0400550A RID: 21770
		public IXUIButton m_Close;

		// Token: 0x0400550B RID: 21771
		public IXUILabel m_GuildPoint;

		// Token: 0x0400550C RID: 21772
		public IXUISprite m_DetailSkillIcon;

		// Token: 0x0400550D RID: 21773
		public IXUILabel m_DetailSkillName;

		// Token: 0x0400550E RID: 21774
		public IXUILabel m_DetailCurrLevel;

		// Token: 0x0400550F RID: 21775
		public IXUILabel m_DetailNextLevel;

		// Token: 0x04005510 RID: 21776
		public IXUILabel m_DetailCurrAttr;

		// Token: 0x04005511 RID: 21777
		public IXUILabel m_DetailNextAttr;

		// Token: 0x04005512 RID: 21778
		public IXUILabel m_DetailMaxLevelLabel;

		// Token: 0x04005513 RID: 21779
		public IXUILabel m_DetailMaxLevel;

		// Token: 0x04005514 RID: 21780
		public IXUIButton m_DetailUpMaxLevel;

		// Token: 0x04005515 RID: 21781
		public IXUILabel m_DetailTip;

		// Token: 0x04005516 RID: 21782
		public IXUILabelSymbol m_DetailCost;

		// Token: 0x04005517 RID: 21783
		public IXUILabelSymbol m_DetailCostRed;

		// Token: 0x04005518 RID: 21784
		public IXUIButton m_LevelUp;

		// Token: 0x04005519 RID: 21785
		public IXUILabel m_LevelUpLabel;

		// Token: 0x0400551A RID: 21786
		public Transform m_RedPoint;

		// Token: 0x0400551B RID: 21787
		public XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400551C RID: 21788
		public IXUIScrollView m_SkillScroll;
	}
}
