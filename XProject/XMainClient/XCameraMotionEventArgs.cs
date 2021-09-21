using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F4D RID: 3917
	internal class XCameraMotionEventArgs : XEventArgs
	{
		// Token: 0x0600CFFD RID: 53245 RVA: 0x00303BDF File Offset: 0x00301DDF
		public XCameraMotionEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraMotion;
		}

		// Token: 0x0600CFFE RID: 53246 RVA: 0x00303C06 File Offset: 0x00301E06
		public override void Recycle()
		{
			base.Recycle();
			this.Motion = null;
			this.Trigger = null;
			this.Target = null;
			XEventPool<XCameraMotionEventArgs>.Recycle(this);
		}

		// Token: 0x04005DF3 RID: 24051
		public XEntity Target = null;

		// Token: 0x04005DF4 RID: 24052
		public string Trigger = null;

		// Token: 0x04005DF5 RID: 24053
		public XCameraMotionData Motion = null;
	}
}
