using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000F85 RID: 3973
	internal class XSpotOnEventArgs : XEventArgs
	{
		// Token: 0x0600D0A8 RID: 53416 RVA: 0x00304DAE File Offset: 0x00302FAE
		public XSpotOnEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_SpotOn;
		}

		// Token: 0x0600D0A9 RID: 53417 RVA: 0x00304DD4 File Offset: 0x00302FD4
		public override void Recycle()
		{
			Color red = Color.red;
			base.Recycle();
			XEventPool<XSpotOnEventArgs>.Recycle(this);
		}

		// Token: 0x04005E6B RID: 24171
		public bool Enabled = false;

		// Token: 0x04005E6C RID: 24172
		public Color color = Color.red;
	}
}
