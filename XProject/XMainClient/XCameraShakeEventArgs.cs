using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F4B RID: 3915
	internal class XCameraShakeEventArgs : XEventArgs
	{
		// Token: 0x0600CFF7 RID: 53239 RVA: 0x00303B5C File Offset: 0x00301D5C
		public XCameraShakeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraShake;
		}

		// Token: 0x0600CFF8 RID: 53240 RVA: 0x00303B79 File Offset: 0x00301D79
		public override void Recycle()
		{
			this.Effect = null;
			this.TimeScale = 1f;
			base.Recycle();
			XEventPool<XCameraShakeEventArgs>.Recycle(this);
		}

		// Token: 0x17003683 RID: 13955
		// (get) Token: 0x0600CFF9 RID: 53241 RVA: 0x00303B9D File Offset: 0x00301D9D
		// (set) Token: 0x0600CFFA RID: 53242 RVA: 0x00303BA5 File Offset: 0x00301DA5
		public XCameraEffectData Effect { get; set; }

		// Token: 0x04005DF1 RID: 24049
		public float TimeScale = 1f;
	}
}
