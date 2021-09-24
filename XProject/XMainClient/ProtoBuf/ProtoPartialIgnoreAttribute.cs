using System;

namespace ProtoBuf
{

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
	public sealed class ProtoPartialIgnoreAttribute : ProtoIgnoreAttribute
	{

		public ProtoPartialIgnoreAttribute(string memberName)
		{
			bool flag = Helpers.IsNullOrEmpty(memberName);
			if (flag)
			{
				throw new ArgumentNullException("memberName");
			}
			this.memberName = memberName;
		}

		public string MemberName
		{
			get
			{
				return this.memberName;
			}
		}

		private readonly string memberName;
	}
}
