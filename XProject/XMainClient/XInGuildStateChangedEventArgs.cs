using System;

namespace XMainClient
{

	internal class XInGuildStateChangedEventArgs : XEventArgs
	{

		public XInGuildStateChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_InGuildStateChanged;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.bIsEnter = true;
			this.bRoleInit = false;
			XEventPool<XInGuildStateChangedEventArgs>.Recycle(this);
		}

		public bool bIsEnter = true;

		public bool bRoleInit = false;
	}
}
