using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XEquipChangeEventArgs : XEventArgs
	{

		public XEquipChangeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_EquipChange;
		}

		public override void Recycle()
		{
			this.EquipPart = null;
			this.ItemID = null;
			base.Recycle();
			XEventPool<XEquipChangeEventArgs>.Recycle(this);
		}

		public List<uint> EquipPart { get; set; }

		public List<uint> ItemID { get; set; }
	}
}
