using System;

namespace XMainClient
{
	// Token: 0x02000F73 RID: 3955
	internal class XLeaveSceneArgs : XEventArgs
	{
		// Token: 0x0600D080 RID: 53376 RVA: 0x00304890 File Offset: 0x00302A90
		public XLeaveSceneArgs()
		{
			this._eDefine = XEventDefine.XEvent_LeaveScene;
		}

		// Token: 0x0600D081 RID: 53377 RVA: 0x003048A2 File Offset: 0x00302AA2
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XLeaveSceneArgs>.Recycle(this);
		}
	}
}
