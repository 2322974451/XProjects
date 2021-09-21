using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000F77 RID: 3959
	internal class XNavigationEventArgs : XEventArgs
	{
		// Token: 0x0600D088 RID: 53384 RVA: 0x0030493F File Offset: 0x00302B3F
		public XNavigationEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_NaviMove;
		}

		// Token: 0x0600D089 RID: 53385 RVA: 0x00304963 File Offset: 0x00302B63
		public override void Recycle()
		{
			base.Recycle();
			this.Dest = Vector3.zero;
			this.CameraFollow = true;
			this.SpeedRatio = 1f;
			XEventPool<XNavigationEventArgs>.Recycle(this);
		}

		// Token: 0x04005E4D RID: 24141
		public Vector3 Dest;

		// Token: 0x04005E4E RID: 24142
		public bool CameraFollow = true;

		// Token: 0x04005E4F RID: 24143
		public float SpeedRatio = 1f;
	}
}
