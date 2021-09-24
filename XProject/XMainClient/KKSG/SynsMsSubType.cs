using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SynsMsSubType")]
	public enum SynsMsSubType
	{

		[ProtoEnum(Name = "SynsCreate", Value = 1)]
		SynsCreate = 1,

		[ProtoEnum(Name = "SynsDestory", Value = 2)]
		SynsDestory,

		[ProtoEnum(Name = "SynsAdd", Value = 3)]
		SynsAdd,

		[ProtoEnum(Name = "SynsDel", Value = 4)]
		SynsDel,

		[ProtoEnum(Name = "SynsLead", Value = 5)]
		SynsLead,

		[ProtoEnum(Name = "SynsLevel", Value = 6)]
		SynsLevel,

		[ProtoEnum(Name = "SynsIcon", Value = 7)]
		SynsIcon,

		[ProtoEnum(Name = "SynAddExp", Value = 8)]
		SynAddExp,

		[ProtoEnum(Name = "SynSetTime", Value = 9)]
		SynSetTime
	}
}
