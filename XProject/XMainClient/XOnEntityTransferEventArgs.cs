using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000F98 RID: 3992
	internal class XOnEntityTransferEventArgs : XEventArgs
	{
		// Token: 0x0600D0D6 RID: 53462 RVA: 0x003051A1 File Offset: 0x003033A1
		public XOnEntityTransferEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnEntityTransfer;
			this.TransPos = Vector3.zero;
		}

		// Token: 0x0600D0D7 RID: 53463 RVA: 0x003051C1 File Offset: 0x003033C1
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XOnEntityTransferEventArgs>.Recycle(this);
		}

		// Token: 0x04005E80 RID: 24192
		public Vector3 TransPos;
	}
}
