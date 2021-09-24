using System;
using KKSG;

namespace XMainClient
{

	internal class XTaskStatusChangeArgs : XEventArgs
	{

		public XTaskStatusChangeArgs()
		{
			this._eDefine = XEventDefine.XEvent_TaskStateChange;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XTaskStatusChangeArgs>.Recycle(this);
		}

		public TaskStatus status;

		public uint id;
	}
}
