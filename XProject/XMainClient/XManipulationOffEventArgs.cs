using System;

namespace XMainClient
{

	internal class XManipulationOffEventArgs : XEventArgs
	{

		public XManipulationOffEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Manipulation_Off;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.DenyToken = 0L;
			XEventPool<XManipulationOffEventArgs>.Recycle(this);
		}

		public long DenyToken = 0L;
	}
}
