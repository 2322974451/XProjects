using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000F8F RID: 3983
	internal class XFriendInfoChange : XEventArgs
	{
		// Token: 0x0600D0BC RID: 53436 RVA: 0x00304FAD File Offset: 0x003031AD
		public XFriendInfoChange()
		{
			this._eDefine = XEventDefine.XEvent_FriendInfoChange;
		}

		// Token: 0x0600D0BD RID: 53437 RVA: 0x00304FBF File Offset: 0x003031BF
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XFriendInfoChange>.Recycle(this);
		}

		// Token: 0x04005E76 RID: 24182
		public FriendOpType opType;
	}
}
