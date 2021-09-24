using System;

namespace XMainClient
{

	internal class XOnEntityCreatedArgs : XEventArgs
	{

		public XOnEntityCreatedArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnEntityCreated;
			this.entity = null;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.entity = null;
			XEventPool<XOnEntityCreatedArgs>.Recycle(this);
		}

		public XEntity entity;
	}
}
