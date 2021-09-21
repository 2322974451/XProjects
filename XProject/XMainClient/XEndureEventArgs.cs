using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000F4A RID: 3914
	internal class XEndureEventArgs : XEventArgs
	{
		// Token: 0x0600CFF5 RID: 53237 RVA: 0x00303B07 File Offset: 0x00301D07
		public XEndureEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Endure;
		}

		// Token: 0x0600CFF6 RID: 53238 RVA: 0x00303B32 File Offset: 0x00301D32
		public override void Recycle()
		{
			this.Fx = null;
			this.Dir = Vector3.zero;
			this.HitFrom = null;
			base.Recycle();
			XEventPool<XEndureEventArgs>.Recycle(this);
		}

		// Token: 0x04005DED RID: 24045
		public string Fx = null;

		// Token: 0x04005DEE RID: 24046
		public Vector3 Dir = Vector3.zero;

		// Token: 0x04005DEF RID: 24047
		public XEntity HitFrom = null;
	}
}
