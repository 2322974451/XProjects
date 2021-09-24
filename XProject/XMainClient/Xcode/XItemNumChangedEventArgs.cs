using System;

namespace XMainClient
{

	internal class XItemNumChangedEventArgs : XEventArgs
	{

		public XItemNumChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_ItemNumChanged;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.item = null;
			this.bNew = true;
			XEventPool<XItemNumChangedEventArgs>.Recycle(this);
		}

		public override XEventArgs Clone()
		{
			XItemNumChangedEventArgs @event = XEventPool<XItemNumChangedEventArgs>.GetEvent();
			@event.oldCount = this.oldCount;
			@event.item = this.item;
			@event.bNew = this.bNew;
			return @event;
		}

		public int oldCount;

		public XItem item;

		public bool bNew = true;
	}
}
