using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BD6 RID: 3030
	public class GroupMemberPool
	{
		// Token: 0x0600AD0A RID: 44298 RVA: 0x0020098C File Offset: 0x001FEB8C
		public static GroupMember Create()
		{
			return new GroupMember();
		}

		// Token: 0x0600AD0B RID: 44299 RVA: 0x002009A4 File Offset: 0x001FEBA4
		public static GroupMember Get()
		{
			return GroupMemberPool.members.Get();
		}

		// Token: 0x0600AD0C RID: 44300 RVA: 0x002009C0 File Offset: 0x001FEBC0
		public static void Release(GroupMember group)
		{
			GroupMemberPool.members.Release(group);
		}

		// Token: 0x04004114 RID: 16660
		private static ObjectPool<GroupMember> members = new ObjectPool<GroupMember>(new ObjectPool<GroupMember>.CreateObj(GroupMemberPool.Create), null, null);
	}
}
