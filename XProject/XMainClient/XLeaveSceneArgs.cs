using System;

namespace XMainClient
{

	internal class XLeaveSceneArgs : XEventArgs
	{

		public XLeaveSceneArgs()
		{
			this._eDefine = XEventDefine.XEvent_LeaveScene;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XLeaveSceneArgs>.Recycle(this);
		}
	}
}
