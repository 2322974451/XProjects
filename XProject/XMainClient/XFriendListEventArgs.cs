using System;

namespace XMainClient
{

	internal class XFriendListEventArgs : XEventArgs
	{

		public XFriendListEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_FriendList;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XFriendListEventArgs>.Recycle(this);
		}
	}
}
