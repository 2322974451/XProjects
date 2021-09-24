using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCameraShakeEventArgs : XEventArgs
	{

		public XCameraShakeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_CameraShake;
		}

		public override void Recycle()
		{
			this.Effect = null;
			this.TimeScale = 1f;
			base.Recycle();
			XEventPool<XCameraShakeEventArgs>.Recycle(this);
		}

		public XCameraEffectData Effect { get; set; }

		public float TimeScale = 1f;
	}
}
