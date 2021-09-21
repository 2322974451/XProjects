using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018D4 RID: 6356
	internal class FriendsWeddingLevelUpBehaviour : DlgBehaviourBase
	{
		// Token: 0x0601091E RID: 67870 RVA: 0x00414950 File Offset: 0x00412B50
		private void Awake()
		{
			this.m_LevelTip = (base.transform.Find("open/Tips").GetComponent("XUILabel") as IXUILabel);
			this.m_GetBtn = (base.transform.Find("open/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_ItemDesc = base.transform.Find("open/desc").gameObject;
			this.m_Skill = base.transform.Find("open/Skill").gameObject;
			this.m_SkillName = (base.transform.Find("open/Skill/tmp/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillIcon = (base.transform.Find("open/Skill/tmp/SkillIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_Item = base.transform.Find("open/items").gameObject;
			this.m_ItemName = (base.transform.Find("open/items/tmp/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_ItemIconTran = base.transform.Find("open/items/tmp");
		}

		// Token: 0x0400782F RID: 30767
		public IXUILabel m_LevelTip;

		// Token: 0x04007830 RID: 30768
		public IXUIButton m_GetBtn;

		// Token: 0x04007831 RID: 30769
		public GameObject m_ItemDesc;

		// Token: 0x04007832 RID: 30770
		public IXUILabel m_SkillName;

		// Token: 0x04007833 RID: 30771
		public IXUISprite m_SkillIcon;

		// Token: 0x04007834 RID: 30772
		public GameObject m_Skill;

		// Token: 0x04007835 RID: 30773
		public IXUILabel m_ItemName;

		// Token: 0x04007836 RID: 30774
		public Transform m_ItemIconTran;

		// Token: 0x04007837 RID: 30775
		public GameObject m_Item;
	}
}
