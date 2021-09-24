using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EntitySpecies")]
	public enum EntitySpecies
	{

		[ProtoEnum(Name = "Species_Boss", Value = 1)]
		Species_Boss = 1,

		[ProtoEnum(Name = "Species_Opposer", Value = 2)]
		Species_Opposer,

		[ProtoEnum(Name = "Species_Puppet", Value = 3)]
		Species_Puppet,

		[ProtoEnum(Name = "Species_Npc", Value = 7)]
		Species_Npc = 7,

		[ProtoEnum(Name = "Species_Role", Value = 10)]
		Species_Role = 10,

		[ProtoEnum(Name = "Species_Empty", Value = 8)]
		Species_Empty = 8,

		[ProtoEnum(Name = "Species_Dummy", Value = 9)]
		Species_Dummy,

		[ProtoEnum(Name = "Species_Substance", Value = 5)]
		Species_Substance = 5,

		[ProtoEnum(Name = "Species_Affiliate", Value = 11)]
		Species_Affiliate = 11,

		[ProtoEnum(Name = "Species_Elite", Value = 6)]
		Species_Elite = 6
	}
}
