using System;

namespace XMainClient
{

	internal class XCameraMotionEndEventArgs : XEventArgs
	{

		public XCameraMotionEndEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraMotionEnd;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Target = null;
			this.CutSceneEnd = false;
			XEventPool<XCameraMotionEndEventArgs>.Recycle(this);
		}

		public XEntity Target = null;

		public bool CutSceneEnd = false;
	}
}
