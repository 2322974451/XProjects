using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XAddItemEventArgs : XEventArgs
	{

		public XAddItemEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AddItem;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.items.Clear();
			this.bNew = true;
			XEventPool<XAddItemEventArgs>.Recycle(this);
		}

		public override XEventArgs Clone()
		{
			XAddItemEventArgs @event = XEventPool<XAddItemEventArgs>.GetEvent();
			@event.bNew = this.bNew;
			for (int i = 0; i < this.items.Count; i++)
			{
				@event.items.Add(this.items[i]);
			}
			return @event;
		}

		public bool bNew = true;

		public List<XItem> items = new List<XItem>();
	}
}
