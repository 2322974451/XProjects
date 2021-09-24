using System;

namespace XMainClient
{

	internal class XFallEventArgs : XActionArgs
	{

		public XFallEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Fall;
		}

		public override void Recycle()
		{
			this.HVelocity = 0f;
			this.Gravity = 0f;
			base.Recycle();
			XEventPool<XFallEventArgs>.Recycle(this);
		}

		public float HVelocity { get; set; }

		public float Gravity { get; set; }
	}
}
