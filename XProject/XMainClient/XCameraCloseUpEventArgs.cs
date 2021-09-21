using System;

namespace XMainClient
{
	// Token: 0x02000F50 RID: 3920
	internal class XCameraCloseUpEventArgs : XEventArgs
	{
		// Token: 0x0600D003 RID: 53251 RVA: 0x00303CB6 File Offset: 0x00301EB6
		public XCameraCloseUpEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraCloseUp;
		}

		// Token: 0x0600D004 RID: 53252 RVA: 0x00303CC8 File Offset: 0x00301EC8
		public override void Recycle()
		{
			base.Recycle();
			this.Target = null;
			XEventPool<XCameraCloseUpEventArgs>.Recycle(this);
		}

		// Token: 0x04005DFC RID: 24060
		public XEntity Target;
	}
}
