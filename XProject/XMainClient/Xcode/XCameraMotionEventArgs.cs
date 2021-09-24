using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCameraMotionEventArgs : XEventArgs
	{

		public XCameraMotionEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraMotion;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Motion = null;
			this.Trigger = null;
			this.Target = null;
			XEventPool<XCameraMotionEventArgs>.Recycle(this);
		}

		public XEntity Target = null;

		public string Trigger = null;

		public XCameraMotionData Motion = null;
	}
}
