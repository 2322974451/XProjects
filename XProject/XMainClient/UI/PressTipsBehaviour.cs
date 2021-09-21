using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001873 RID: 6259
	internal class PressTipsBehaviour : DlgBehaviourBase
	{
		// Token: 0x060104B2 RID: 66738 RVA: 0x003F12B3 File Offset: 0x003EF4B3
		private void Awake()
		{
			this._ContentTransform = base.transform.Find("Info");
			this._ContentValue = (this._ContentTransform.GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0400752B RID: 29995
		public IXUILabel _ContentValue;

		// Token: 0x0400752C RID: 29996
		public Transform _ContentTransform;
	}
}
