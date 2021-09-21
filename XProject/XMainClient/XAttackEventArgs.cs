using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F5D RID: 3933
	internal class XAttackEventArgs : XEventArgs
	{
		// Token: 0x0600D021 RID: 53281 RVA: 0x00303FBC File Offset: 0x003021BC
		public XAttackEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Attack;
		}

		// Token: 0x0600D022 RID: 53282 RVA: 0x00304010 File Offset: 0x00302210
		public override void Recycle()
		{
			this.Identify = 0U;
			this.Target = null;
			this.Slot = -1;
			this.Demonstration = false;
			this.AffectCamera = XSingleton<XScene>.singleton.GameCamera;
			this.TimeScale = 1f;
			this.SyncSequence = 0U;
			base.Recycle();
			base.Token = (XSingleton<XCommon>.singleton.UniqueToken ^ (long)DateTime.Now.Millisecond);
			XEventPool<XAttackEventArgs>.Recycle(this);
		}

		// Token: 0x04005E0E RID: 24078
		public uint Identify;

		// Token: 0x04005E0F RID: 24079
		public XEntity Target = null;

		// Token: 0x04005E10 RID: 24080
		public int Slot = -1;

		// Token: 0x04005E11 RID: 24081
		public uint SyncSequence = 0U;

		// Token: 0x04005E12 RID: 24082
		public bool Demonstration = false;

		// Token: 0x04005E13 RID: 24083
		public XCameraEx AffectCamera = XSingleton<XScene>.singleton.GameCamera;

		// Token: 0x04005E14 RID: 24084
		public float TimeScale = 1f;
	}
}
