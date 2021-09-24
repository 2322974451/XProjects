using System;

namespace XMainClient
{

	internal class XJumpEventArgs : XActionArgs
	{

		public XJumpEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Jump;
		}

		public override void Recycle()
		{
			this.Gravity = 0f;
			this.Hvelocity = 0f;
			this.Vvelocity = 0f;
			base.Recycle();
			XEventPool<XJumpEventArgs>.Recycle(this);
		}

		public float Gravity { get; set; }

		public float Hvelocity { get; set; }

		public float Vvelocity { get; set; }
	}
}
