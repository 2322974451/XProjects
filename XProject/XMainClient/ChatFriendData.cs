using System;
using System.Collections.Generic;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	public class ChatFriendData : LoopItemData
	{

		public uint degreelevel
		{
			get
			{
				return (this.friendData != null) ? this.friendData.degreeAll : 0U;
			}
		}

		public int isOnline
		{
			get
			{
				return (this.online > 0U) ? 1 : 0;
			}
		}

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

		public uint viplevel;

		public uint profession;

		public string name;

		public uint powerpoint;

		public ulong roleid;

		public bool isfriend;

		public List<uint> setid = new List<uint>();

		public uint online;

		public DateTime msgtime = DateTime.Today;

		public bool hasOfflineRead = false;
	}
}
