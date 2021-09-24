using System;

namespace XMainClient
{

	public class InviteMemberInfo
	{

		public override bool Equals(object obj)
		{
			InviteMemberInfo inviteMemberInfo = obj as InviteMemberInfo;
			bool flag = inviteMemberInfo != null;
			return flag && inviteMemberInfo.uid == this.uid;
		}

		public override int GetHashCode()
		{
			return (int)this.uid;
		}

		public ulong uid;

		public string name;

		public uint ppt;

		public uint level;

		public uint vip;

		public string guildname;

		public uint degree;

		public int sameGuild;

		public uint profession = 1U;

		public bool bSent;
	}
}
