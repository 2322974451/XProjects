using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000F46 RID: 3910
	internal class XMoveEventArgs : XActionArgs
	{
		// Token: 0x0600CFE3 RID: 53219 RVA: 0x00303963 File Offset: 0x00301B63
		public XMoveEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Move;
		}

		// Token: 0x0600CFE4 RID: 53220 RVA: 0x003039A3 File Offset: 0x00301BA3
		public override void Recycle()
		{
			base.Recycle();
			this.Destination = Vector3.zero;
			this.Speed = 0f;
			this.Inertia = false;
			this.Stoppage = true;
			this.StopTowards = 0f;
			XEventPool<XMoveEventArgs>.Recycle(this);
		}

		// Token: 0x04005DE1 RID: 24033
		public Vector3 Destination = Vector3.zero;

		// Token: 0x04005DE2 RID: 24034
		public float Speed = 0f;

		// Token: 0x04005DE3 RID: 24035
		public bool Inertia = false;

		// Token: 0x04005DE4 RID: 24036
		public bool Stoppage = true;

		// Token: 0x04005DE5 RID: 24037
		public float StopTowards = 0f;
	}
}
