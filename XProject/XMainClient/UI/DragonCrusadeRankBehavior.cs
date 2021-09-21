using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001736 RID: 5942
	internal class DragonCrusadeRankBehavior : DlgBehaviourBase
	{
		// Token: 0x0600F56F RID: 62831 RVA: 0x003767D0 File Offset: 0x003749D0
		private void Awake()
		{
			this.mClosedBtn = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_scroll_view = (base.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_EmptyHint = base.transform.Find("ScrollView/EmptyRank").gameObject;
		}

		// Token: 0x04006A54 RID: 27220
		public IXUIScrollView m_scroll_view;

		// Token: 0x04006A55 RID: 27221
		public IXUIButton mClosedBtn = null;

		// Token: 0x04006A56 RID: 27222
		public GameObject m_EmptyHint;
	}
}
