using System;

namespace XMainClient
{

	internal class XUnloadEquipEventArgs : XEventArgs
	{

		public XUnloadEquipEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_UnloadEquip;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.slot = 0;
			this.item = null;
			XEventPool<XUnloadEquipEventArgs>.Recycle(this);
		}

		public int slot;

		public XItem item;

		public ItemType type;
	}
}
