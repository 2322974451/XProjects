using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C6A RID: 3178
	internal class PrerogativeDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B3E3 RID: 46051 RVA: 0x0023101C File Offset: 0x0022F21C
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this._ruleBtn = (base.transform.Find("Bg/RuleBtn").GetComponent("XUIButton") as IXUIButton);
			this._shopBtn = (base.transform.Find("Bg/ShopBtn").GetComponent("XUIButton") as IXUIButton);
			this._setting = base.transform.Find("Bg/Setting");
			this._desc = (base.transform.Find("Bg/Intro").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x040045BC RID: 17852
		public IXUIButton m_Close;

		// Token: 0x040045BD RID: 17853
		public IXUIButton _ruleBtn;

		// Token: 0x040045BE RID: 17854
		public IXUIButton _shopBtn;

		// Token: 0x040045BF RID: 17855
		public Transform _setting;

		// Token: 0x040045C0 RID: 17856
		public IXUILabel _desc;
	}
}
