using System;

namespace XMainClient
{

	internal class XEvent_HomeFeastingArgs : XEventArgs
	{

		public XEvent_HomeFeastingArgs()
		{
			this._eDefine = XEventDefine.XEvent_HomeFeasting;
			this.time = 0U;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.time = 0U;
			XEventPool<XEvent_HomeFeastingArgs>.Recycle(this);
		}

		public uint time = 0U;
	}
}
