using System;

namespace XMainClient
{
	// Token: 0x02000F96 RID: 3990
	internal class XFriendListEventArgs : XEventArgs
	{
		// Token: 0x0600D0CA RID: 53450 RVA: 0x003050D5 File Offset: 0x003032D5
		public XFriendListEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_FriendList;
		}

		// Token: 0x0600D0CB RID: 53451 RVA: 0x003050E7 File Offset: 0x003032E7
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XFriendListEventArgs>.Recycle(this);
		}
	}
}
