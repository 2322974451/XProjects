using System;

namespace XMainClient
{

	internal class XCameraCloseUpEventArgs : XEventArgs
	{

		public XCameraCloseUpEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraCloseUp;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Target = null;
			XEventPool<XCameraCloseUpEventArgs>.Recycle(this);
		}

		public XEntity Target;
	}
}
