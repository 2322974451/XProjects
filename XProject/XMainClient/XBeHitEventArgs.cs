using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F5F RID: 3935
	internal class XBeHitEventArgs : XActionArgs
	{
		// Token: 0x0600D02B RID: 53291 RVA: 0x0030414C File Offset: 0x0030234C
		public XBeHitEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BeHit;
		}

		// Token: 0x0600D02C RID: 53292 RVA: 0x00304181 File Offset: 0x00302381
		public override void Recycle()
		{
			this.HitData = null;
			this.HitDirection = Vector3.forward;
			this.ForceToFlyHit = false;
			this.Paralyze = 1f;
			this.HitFrom = null;
			base.Recycle();
			XEventPool<XBeHitEventArgs>.Recycle(this);
		}

		// Token: 0x17003689 RID: 13961
		// (get) Token: 0x0600D02D RID: 53293 RVA: 0x003041BE File Offset: 0x003023BE
		// (set) Token: 0x0600D02E RID: 53294 RVA: 0x003041C6 File Offset: 0x003023C6
		public XHitData HitData { get; set; }

		// Token: 0x04005E1C RID: 24092
		public Vector3 HitDirection = Vector3.forward;

		// Token: 0x04005E1D RID: 24093
		public bool ForceToFlyHit = false;

		// Token: 0x04005E1E RID: 24094
		public float Paralyze = 1f;

		// Token: 0x04005E1F RID: 24095
		public XEntity HitFrom = null;
	}
}
