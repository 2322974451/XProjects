using System;

namespace XMainClient
{

	internal class XDragonGuildInfoChange : XEventArgs
	{

		public XDragonGuildInfoChange()
		{
			this._eDefine = XEventDefine.XEvent_DragonGuildInfoChange;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XDragonGuildInfoChange>.Recycle(this);
		}
	}
}
