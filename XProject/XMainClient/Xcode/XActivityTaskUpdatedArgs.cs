using System;

namespace XMainClient
{

	internal class XActivityTaskUpdatedArgs : XEventArgs
	{

		public XActivityTaskUpdatedArgs()
		{
			this._eDefine = XEventDefine.XEvent_ActivityTaskUpdate;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.xActID = 0U;
			this.xTaskID = 0U;
			this.xProgress = 0U;
			this.xState = 0U;
			XEventPool<XActivityTaskUpdatedArgs>.Recycle(this);
		}

		public uint xActID;

		public uint xTaskID;

		public uint xProgress;

		public uint xState;
	}
}
