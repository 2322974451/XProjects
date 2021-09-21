using System;

namespace XMainClient
{
	// Token: 0x02000F4E RID: 3918
	internal class XCameraMotionEndEventArgs : XEventArgs
	{
		// Token: 0x0600CFFF RID: 53247 RVA: 0x00303C2C File Offset: 0x00301E2C
		public XCameraMotionEndEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraMotionEnd;
		}

		// Token: 0x0600D000 RID: 53248 RVA: 0x00303C4C File Offset: 0x00301E4C
		public override void Recycle()
		{
			base.Recycle();
			this.Target = null;
			this.CutSceneEnd = false;
			XEventPool<XCameraMotionEndEventArgs>.Recycle(this);
		}

		// Token: 0x04005DF6 RID: 24054
		public XEntity Target = null;

		// Token: 0x04005DF7 RID: 24055
		public bool CutSceneEnd = false;
	}
}
