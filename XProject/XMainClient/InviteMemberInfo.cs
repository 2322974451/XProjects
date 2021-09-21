using System;

namespace XMainClient
{
	// Token: 0x02000C32 RID: 3122
	public class InviteMemberInfo
	{
		// Token: 0x0600B0CB RID: 45259 RVA: 0x0021CFC4 File Offset: 0x0021B1C4
		public override bool Equals(object obj)
		{
			InviteMemberInfo inviteMemberInfo = obj as InviteMemberInfo;
			bool flag = inviteMemberInfo != null;
			return flag && inviteMemberInfo.uid == this.uid;
		}

		// Token: 0x0600B0CC RID: 45260 RVA: 0x0021CFF8 File Offset: 0x0021B1F8
		public override int GetHashCode()
		{
			return (int)this.uid;
		}

		// Token: 0x04004401 RID: 17409
		public ulong uid;

		// Token: 0x04004402 RID: 17410
		public string name;

		// Token: 0x04004403 RID: 17411
		public uint ppt;

		// Token: 0x04004404 RID: 17412
		public uint level;

		// Token: 0x04004405 RID: 17413
		public uint vip;

		// Token: 0x04004406 RID: 17414
		public string guildname;

		// Token: 0x04004407 RID: 17415
		public uint degree;

		// Token: 0x04004408 RID: 17416
		public int sameGuild;

		// Token: 0x04004409 RID: 17417
		public uint profession = 1U;

		// Token: 0x0400440A RID: 17418
		public bool bSent;
	}
}
