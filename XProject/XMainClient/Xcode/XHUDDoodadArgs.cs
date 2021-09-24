using System;

namespace XMainClient
{

	internal class XHUDDoodadArgs : XEventArgs
	{

		public XHUDDoodadArgs()
		{
			this._eDefine = XEventDefine.XEvent_HUDDoodad;
		}

		public override void Recycle()
		{
			this.count = 0;
			this.itemid = 0;
			base.Recycle();
			XEventPool<XHUDDoodadArgs>.Recycle(this);
		}

		public int count { get; set; }

		public int itemid { get; set; }
	}
}
