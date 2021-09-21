using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000F49 RID: 3913
	internal class XRotationEventArgs : XEventArgs
	{
		// Token: 0x0600CFF3 RID: 53235 RVA: 0x00303AB8 File Offset: 0x00301CB8
		public XRotationEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Rotation;
		}

		// Token: 0x0600CFF4 RID: 53236 RVA: 0x00303AE0 File Offset: 0x00301CE0
		public override void Recycle()
		{
			this.TargetDir = Vector3.forward;
			this.Palstance = 0f;
			base.Recycle();
			XEventPool<XRotationEventArgs>.Recycle(this);
		}

		// Token: 0x04005DEB RID: 24043
		public Vector3 TargetDir = Vector3.forward;

		// Token: 0x04005DEC RID: 24044
		public float Palstance = 0f;
	}
}
