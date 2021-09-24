using System;

namespace XMainClient
{

	internal class XVirtualItemChangedEventArgs : XEventArgs
	{

		public XVirtualItemChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_VirtualItemChanged;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.e = ItemEnum.VIRTUAL_ITEM_MAX;
			this.newValue = 0UL;
			this.oldValue = 0UL;
			XEventPool<XVirtualItemChangedEventArgs>.Recycle(this);
		}

		public override XEventArgs Clone()
		{
			XVirtualItemChangedEventArgs @event = XEventPool<XVirtualItemChangedEventArgs>.GetEvent();
			@event.newValue = this.newValue;
			@event.oldValue = this.oldValue;
			@event.itemID = this.itemID;
			return @event;
		}

		public ItemEnum e = ItemEnum.VIRTUAL_ITEM_MAX;

		public ulong newValue;

		public ulong oldValue;

		public int itemID;
	}
}
