using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SynsMsType")]
	public enum SynsMsType
	{

		[ProtoEnum(Name = "SynsGuild", Value = 1)]
		SynsGuild = 1,

		[ProtoEnum(Name = "SynsTeam", Value = 2)]
		SynsTeam
	}
}
