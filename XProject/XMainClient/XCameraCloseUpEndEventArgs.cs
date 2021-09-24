using System;

namespace XMainClient
{

	internal class XCameraCloseUpEndEventArgs : XEventArgs
	{

		public XCameraCloseUpEndEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraCloseUpEnd;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XCameraCloseUpEndEventArgs>.Recycle(this);
		}
	}
}
