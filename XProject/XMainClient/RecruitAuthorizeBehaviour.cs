using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A44 RID: 2628
	internal class RecruitAuthorizeBehaviour : DlgBehaviourBase
	{
		// Token: 0x06009FA9 RID: 40873 RVA: 0x001A7894 File Offset: 0x001A5A94
		private void Awake()
		{
			this._info = (base.transform.Find("Info/Info").GetComponent("XUILabel") as IXUILabel);
			this._Close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this._Empty = base.transform.Find("Empty");
			this._MemberScrollView = (base.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this._MemberWrapContent = (base.transform.Find("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		// Token: 0x04003901 RID: 14593
		public IXUILabel _info;

		// Token: 0x04003902 RID: 14594
		public IXUIButton _Close;

		// Token: 0x04003903 RID: 14595
		public Transform _Empty;

		// Token: 0x04003904 RID: 14596
		public IXUIScrollView _MemberScrollView;

		// Token: 0x04003905 RID: 14597
		public IXUIWrapContent _MemberWrapContent;
	}
}
