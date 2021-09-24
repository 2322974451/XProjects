using System;

namespace XMainClient
{

	internal class XCameraActionEventArgs : XEventArgs
	{

		public XCameraActionEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraAction;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.YRotate = 0f;
			this.XRotate = 0f;
			this.Dis = 0f;
			this.Finish = null;
			XEventPool<XCameraActionEventArgs>.Recycle(this);
		}

		public float Dis;

		public float YRotate;

		public float XRotate;

		public XCameraActionEventArgs.FinishHandler Finish;

		public delegate void FinishHandler();
	}
}
