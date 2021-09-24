using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class GroupMemberPool
	{

		public static GroupMember Create()
		{
			return new GroupMember();
		}

		public static GroupMember Get()
		{
			return GroupMemberPool.members.Get();
		}

		public static void Release(GroupMember group)
		{
			GroupMemberPool.members.Release(group);
		}

		private static ObjectPool<GroupMember> members = new ObjectPool<GroupMember>(new ObjectPool<GroupMember>.CreateObj(GroupMemberPool.Create), null, null);
	}
}
