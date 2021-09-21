using System;

namespace ProtoBuf
{
	// Token: 0x02000850 RID: 2128
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
	public sealed class ProtoPartialIgnoreAttribute : ProtoIgnoreAttribute
	{
		// Token: 0x06008298 RID: 33432 RVA: 0x000FAB68 File Offset: 0x000F8D68
		public ProtoPartialIgnoreAttribute(string memberName)
		{
			bool flag = Helpers.IsNullOrEmpty(memberName);
			if (flag)
			{
				throw new ArgumentNullException("memberName");
			}
			this.memberName = memberName;
		}

		// Token: 0x1700294E RID: 10574
		// (get) Token: 0x06008299 RID: 33433 RVA: 0x000FAB9C File Offset: 0x000F8D9C
		public string MemberName
		{
			get
			{
				return this.memberName;
			}
		}

		// Token: 0x04002888 RID: 10376
		private readonly string memberName;
	}
}
