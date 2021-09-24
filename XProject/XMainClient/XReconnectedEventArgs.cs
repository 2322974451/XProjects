using System;
using KKSG;

namespace XMainClient
{

	internal class XReconnectedEventArgs : XEventArgs
	{

		public XReconnectedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnReconnected;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XReconnectedEventArgs>.Recycle(this);
		}

		public RoleAllInfo PlayerInfo = null;

		public UnitAppearance PlayUnit = null;
	}
}
