using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XRemoveItemEventArgs : XEventArgs
	{

		public XRemoveItemEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_RemoveItem;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.uids.Clear();
			this.types.Clear();
			this.ids.Clear();
			XEventPool<XRemoveItemEventArgs>.Recycle(this);
		}

		public override XEventArgs Clone()
		{
			XRemoveItemEventArgs @event = XEventPool<XRemoveItemEventArgs>.GetEvent();
			for (int i = 0; i < this.uids.Count; i++)
			{
				@event.uids.Add(this.uids[i]);
				@event.types.Add(this.types[i]);
				@event.ids.Add(this.ids[i]);
			}
			return @event;
		}

		public List<ulong> uids = new List<ulong>();

		public List<ItemType> types = new List<ItemType>();

		public List<int> ids = new List<int>();
	}
}
