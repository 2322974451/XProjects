using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BB3 RID: 2995
	public class CarnivalBehavior : DlgBehaviourBase
	{
		// Token: 0x0600AB96 RID: 43926 RVA: 0x001F5B94 File Offset: 0x001F3D94
		private void Awake()
		{
			this._endLabel = (base.transform.Find("Bg/Deadline").GetComponent("XUILabel") as IXUILabel);
			this._contentPanel = base.transform.Find("Bg/contentFrame").gameObject;
			this._rwdPanel = base.transform.Find("Bg/rwdFrame").gameObject;
			this._close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			for (int i = 0; i < 7; i++)
			{
				this._tabs[i] = (base.transform.Find("Bg/Tabs/TabTpl" + i + "/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
				this._redpoint[i] = this._tabs[i].gameObject.transform.Find("RedPoint").gameObject;
				this._lock[i] = this._tabs[i].gameObject.transform.Find("lock");
			}
		}

		// Token: 0x04004057 RID: 16471
		public IXUILabel _endLabel;

		// Token: 0x04004058 RID: 16472
		public GameObject _contentPanel;

		// Token: 0x04004059 RID: 16473
		public GameObject _rwdPanel;

		// Token: 0x0400405A RID: 16474
		public IXUIButton _close;

		// Token: 0x0400405B RID: 16475
		public IXUICheckBox[] _tabs = new IXUICheckBox[7];

		// Token: 0x0400405C RID: 16476
		public GameObject[] _redpoint = new GameObject[7];

		// Token: 0x0400405D RID: 16477
		public Transform[] _lock = new Transform[7];
	}
}
