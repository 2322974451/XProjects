using System;

namespace XMainClient
{

	internal class XLoadEquipEventArgs : XEventArgs
	{

		public XLoadEquipEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_LoadEquip;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.item = null;
			this.slot = 0;
			XEventPool<XLoadEquipEventArgs>.Recycle(this);
		}

		public XItem item;

		public int slot;
	}
}
