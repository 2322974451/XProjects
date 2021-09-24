using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleScale")]
	public enum CustomBattleScale
	{

		[ProtoEnum(Name = "CustomBattle_Scale_Friend", Value = 1)]
		CustomBattle_Scale_Friend = 1,

		[ProtoEnum(Name = "CustomBattle_Scale_Guild", Value = 2)]
		CustomBattle_Scale_Guild,

		[ProtoEnum(Name = "CustomBattle_Scale_Server", Value = 3)]
		CustomBattle_Scale_Server,

		[ProtoEnum(Name = "CustomBattle_Scale_All", Value = 4)]
		CustomBattle_Scale_All
	}
}
