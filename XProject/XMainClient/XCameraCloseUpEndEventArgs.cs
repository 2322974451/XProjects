using System;

namespace XMainClient
{
	// Token: 0x02000F51 RID: 3921
	internal class XCameraCloseUpEndEventArgs : XEventArgs
	{
		// Token: 0x0600D005 RID: 53253 RVA: 0x00303CE0 File Offset: 0x00301EE0
		public XCameraCloseUpEndEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraCloseUpEnd;
		}

		// Token: 0x0600D006 RID: 53254 RVA: 0x00303CF2 File Offset: 0x00301EF2
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XCameraCloseUpEndEventArgs>.Recycle(this);
		}
	}
}
