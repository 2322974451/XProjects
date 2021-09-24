using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleState")]
	public enum RoleState
	{

		[ProtoEnum(Name = "Logoff", Value = 0)]
		Logoff,

		[ProtoEnum(Name = "LoadScene", Value = 1)]
		LoadScene,

		[ProtoEnum(Name = "InHall", Value = 2)]
		InHall,

		[ProtoEnum(Name = "InBattle", Value = 3)]
		InBattle
	}
}
