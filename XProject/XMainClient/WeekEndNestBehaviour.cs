using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E8A RID: 3722
	internal class WeekEndNestBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C6C1 RID: 50881 RVA: 0x002C03D0 File Offset: 0x002BE5D0
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg");
			this.m_tex = (transform.FindChild("Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_closedBtn = (transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_helpBtn = (transform.FindChild("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_reddotGo = transform.FindChild("Right/BtnStartSingle/RedPoint").gameObject;
			this.m_getBtn = (transform.FindChild("Right/BtnStartSingle").GetComponent("XUIButton") as IXUIButton);
			this.m_gotoTeamBtn = (transform.FindChild("Right/BtnStartTeam").GetComponent("XUIButton") as IXUIButton);
			this.m_getSpr = (transform.FindChild("Right/BtnStartSingle").GetComponent("XUISprite") as IXUISprite);
			this.m_tittleLab = (transform.FindChild("Left/CurrName").GetComponent("XUILabel") as IXUILabel);
			this.m_rulesLab = (transform.FindChild("Left/GameRule").GetComponent("XUILabel") as IXUILabel);
			this.m_timesLab = (transform.FindChild("Right/Times").GetComponent("XUILabel") as IXUILabel);
			Transform transform2 = transform.FindChild("WeekReward/ItemTpl");
			this.m_parentTra = transform.FindChild("WeekReward/ListPanel");
			this.m_itemPool.SetupPool(transform.FindChild("WeekReward").gameObject, transform2.gameObject, 3U, true);
		}

		// Token: 0x04005731 RID: 22321
		public IXUILabel m_timesLab;

		// Token: 0x04005732 RID: 22322
		public IXUILabel m_tittleLab;

		// Token: 0x04005733 RID: 22323
		public IXUILabel m_rulesLab;

		// Token: 0x04005734 RID: 22324
		public IXUISprite m_getSpr;

		// Token: 0x04005735 RID: 22325
		public IXUIButton m_closedBtn;

		// Token: 0x04005736 RID: 22326
		public IXUIButton m_helpBtn;

		// Token: 0x04005737 RID: 22327
		public IXUIButton m_getBtn;

		// Token: 0x04005738 RID: 22328
		public IXUIButton m_gotoTeamBtn;

		// Token: 0x04005739 RID: 22329
		public GameObject m_reddotGo;

		// Token: 0x0400573A RID: 22330
		public Transform m_parentTra;

		// Token: 0x0400573B RID: 22331
		public IXUITexture m_tex;

		// Token: 0x0400573C RID: 22332
		public XUIPool m_itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
