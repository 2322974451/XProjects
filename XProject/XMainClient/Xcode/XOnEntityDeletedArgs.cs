using System;

namespace XMainClient
{

	internal class XOnEntityDeletedArgs : XEventArgs
	{

		public XOnEntityDeletedArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnEntityDeleted;
			this.Id = 0UL;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Id = 0UL;
			XEventPool<XOnEntityDeletedArgs>.Recycle(this);
		}

		public ulong Id;
	}
}
