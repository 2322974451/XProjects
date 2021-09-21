using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C27 RID: 3111
	internal class AnnounceBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B062 RID: 45154 RVA: 0x0021A4DC File Offset: 0x002186DC
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg");
			this.m_closedSpr = (transform.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_iconSpr = (transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_playerTween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			transform = transform.FindChild("SkillFrame").transform;
			this.m_nameLab = (transform.FindChild("AttrName").GetComponent("XUILabel") as IXUILabel);
			this.m_levelLab = (transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel);
			this.m_describeLab = (transform.FindChild("Describe").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04004395 RID: 17301
		public IXUISprite m_closedSpr;

		// Token: 0x04004396 RID: 17302
		public IXUISprite m_iconSpr;

		// Token: 0x04004397 RID: 17303
		public IXUILabel m_nameLab;

		// Token: 0x04004398 RID: 17304
		public IXUILabel m_levelLab;

		// Token: 0x04004399 RID: 17305
		public IXUILabel m_describeLab;

		// Token: 0x0400439A RID: 17306
		public IXUITweenTool m_playerTween = null;
	}
}
