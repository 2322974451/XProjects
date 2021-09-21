using System;
using System.Collections.Generic;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E27 RID: 3623
	public class ChatFriendData : LoopItemData
	{
		// Token: 0x17003422 RID: 13346
		// (get) Token: 0x0600C2A3 RID: 49827 RVA: 0x0029E214 File Offset: 0x0029C414
		public uint degreelevel
		{
			get
			{
				return (this.friendData != null) ? this.friendData.degreeAll : 0U;
			}
		}

		// Token: 0x17003423 RID: 13347
		// (get) Token: 0x0600C2A4 RID: 49828 RVA: 0x0029E23C File Offset: 0x0029C43C
		public int isOnline
		{
			get
			{
				return (this.online > 0U) ? 1 : 0;
			}
		}

		// Token: 0x17003424 RID: 13348
		// (get) Token: 0x0600C2A5 RID: 49829 RVA: 0x0029E25C File Offset: 0x0029C45C
		public XFriendData friendData
		{
			get
			{
				List<XFriendData> friendData = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.friendData;
				for (int i = 0; i < friendData.Count; i++)
				{
					bool flag = friendData[i].roleid == this.roleid;
					if (flag)
					{
						return friendData[i];
					}
				}
				return null;
			}
		}

		// Token: 0x04005388 RID: 21384
		public uint viplevel;

		// Token: 0x04005389 RID: 21385
		public uint profession;

		// Token: 0x0400538A RID: 21386
		public string name;

		// Token: 0x0400538B RID: 21387
		public uint powerpoint;

		// Token: 0x0400538C RID: 21388
		public ulong roleid;

		// Token: 0x0400538D RID: 21389
		public bool isfriend;

		// Token: 0x0400538E RID: 21390
		public List<uint> setid = new List<uint>();

		// Token: 0x0400538F RID: 21391
		public uint online;

		// Token: 0x04005390 RID: 21392
		public DateTime msgtime = DateTime.Today;

		// Token: 0x04005391 RID: 21393
		public bool hasOfflineRead = false;
	}
}
