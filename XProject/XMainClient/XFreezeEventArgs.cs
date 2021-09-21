using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F6B RID: 3947
	internal class XFreezeEventArgs : XActionArgs
	{
		// Token: 0x0600D058 RID: 53336 RVA: 0x003045B3 File Offset: 0x003027B3
		public XFreezeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Freeze;
		}

		// Token: 0x0600D059 RID: 53337 RVA: 0x003045E1 File Offset: 0x003027E1
		public override void Recycle()
		{
			this.HitData = null;
			this.Duration = 0f;
			this.Dir = Vector3.zero;
			this.Present = false;
			base.Recycle();
			XEventPool<XFreezeEventArgs>.Recycle(this);
		}

		// Token: 0x17003693 RID: 13971
		// (get) Token: 0x0600D05A RID: 53338 RVA: 0x00304617 File Offset: 0x00302817
		// (set) Token: 0x0600D05B RID: 53339 RVA: 0x0030461F File Offset: 0x0030281F
		public XHitData HitData { get; set; }

		// Token: 0x04005E36 RID: 24118
		public float Duration = 0f;

		// Token: 0x04005E37 RID: 24119
		public bool Present = false;

		// Token: 0x04005E38 RID: 24120
		public Vector3 Dir = Vector3.zero;
	}
}
