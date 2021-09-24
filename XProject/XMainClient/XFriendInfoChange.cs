using System;
using KKSG;

namespace XMainClient
{

	internal class XFriendInfoChange : XEventArgs
	{

		public XFriendInfoChange()
		{
			this._eDefine = XEventDefine.XEvent_FriendInfoChange;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XFriendInfoChange>.Recycle(this);
		}

		public FriendOpType opType;
	}
}
