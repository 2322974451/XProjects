using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200175A RID: 5978
	internal class GuildCollectRewardBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F6F4 RID: 63220 RVA: 0x003821C0 File Offset: 0x003803C0
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Bg/Title/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_LeftTime = (base.transform.Find("Bg/LeftTime").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.Find("Bg/Panel/Tpl");
			this.m_CollectPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			transform = base.transform.Find("Bg/Panel/ItemTpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 30U, false);
		}

		// Token: 0x04006B63 RID: 27491
		public IXUIButton m_Close;

		// Token: 0x04006B64 RID: 27492
		public IXUIButton m_Help;

		// Token: 0x04006B65 RID: 27493
		public IXUILabel m_LeftTime;

		// Token: 0x04006B66 RID: 27494
		public XUIPool m_CollectPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006B67 RID: 27495
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
