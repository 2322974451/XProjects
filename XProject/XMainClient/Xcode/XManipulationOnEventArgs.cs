using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XManipulationOnEventArgs : XEventArgs
	{

		public XManipulationOnEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Manipulation_On;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.data = null;
			XEventPool<XManipulationOnEventArgs>.Recycle(this);
		}

		public XManipulationData data = null;
	}
}
