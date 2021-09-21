using System;

namespace ProtoBuf
{
	// Token: 0x02000854 RID: 2132
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
	public sealed class ProtoPartialMemberAttribute : ProtoMemberAttribute
	{
		// Token: 0x060082B9 RID: 33465 RVA: 0x000FAFFC File Offset: 0x000F91FC
		public ProtoPartialMemberAttribute(int tag, string memberName) : base(tag)
		{
			bool flag = Helpers.IsNullOrEmpty(memberName);
			if (flag)
			{
				throw new ArgumentNullException("memberName");
			}
			this.memberName = memberName;
		}

		// Token: 0x1700295D RID: 10589
		// (get) Token: 0x060082BA RID: 33466 RVA: 0x000FB030 File Offset: 0x000F9230
		public string MemberName
		{
			get
			{
				return this.memberName;
			}
		}

		// Token: 0x0400289A RID: 10394
		private readonly string memberName;
	}
}
