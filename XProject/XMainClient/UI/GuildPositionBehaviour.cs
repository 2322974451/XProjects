using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200175E RID: 5982
	internal class GuildPositionBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F716 RID: 63254 RVA: 0x00382C44 File Offset: 0x00380E44
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Memu/template");
			this.m_MenuPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, true);
			this.m_backSprite = (base.transform.FindChild("Memu/back").GetComponent("XUISprite") as IXUISprite);
			this.m_memuSprite = (base.transform.FindChild("Memu").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04006B6F RID: 27503
		public XUIPool m_MenuPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006B70 RID: 27504
		public IXUISprite m_backSprite;

		// Token: 0x04006B71 RID: 27505
		public IXUISprite m_memuSprite;
	}
}
