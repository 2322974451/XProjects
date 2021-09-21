using System;

namespace XMainClient
{
	// Token: 0x02000F4F RID: 3919
	internal class XCameraActionEventArgs : XEventArgs
	{
		// Token: 0x0600D001 RID: 53249 RVA: 0x00303C6B File Offset: 0x00301E6B
		public XCameraActionEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraAction;
		}

		// Token: 0x0600D002 RID: 53250 RVA: 0x00303C7D File Offset: 0x00301E7D
		public override void Recycle()
		{
			base.Recycle();
			this.YRotate = 0f;
			this.XRotate = 0f;
			this.Dis = 0f;
			this.Finish = null;
			XEventPool<XCameraActionEventArgs>.Recycle(this);
		}

		// Token: 0x04005DF8 RID: 24056
		public float Dis;

		// Token: 0x04005DF9 RID: 24057
		public float YRotate;

		// Token: 0x04005DFA RID: 24058
		public float XRotate;

		// Token: 0x04005DFB RID: 24059
		public XCameraActionEventArgs.FinishHandler Finish;

		// Token: 0x020019F4 RID: 6644
		// (Invoke) Token: 0x060110EA RID: 69866
		public delegate void FinishHandler();
	}
}
