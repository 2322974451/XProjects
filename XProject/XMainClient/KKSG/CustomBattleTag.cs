using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleTag")]
	public enum CustomBattleTag
	{

		[ProtoEnum(Name = "CustomBattle_Tag_Friend", Value = 1)]
		CustomBattle_Tag_Friend = 1,

		[ProtoEnum(Name = "CustomBattle_Tag_Guild", Value = 2)]
		CustomBattle_Tag_Guild,

		[ProtoEnum(Name = "CustomBattle_Tag_Cross", Value = 3)]
		CustomBattle_Tag_Cross,

		[ProtoEnum(Name = "CustomBattle_Tag_GM", Value = 4)]
		CustomBattle_Tag_GM
	}
}
