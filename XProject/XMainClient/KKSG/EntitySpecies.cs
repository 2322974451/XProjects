using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200074D RID: 1869
	[ProtoContract(Name = "EntitySpecies")]
	public enum EntitySpecies
	{
		// Token: 0x0400225D RID: 8797
		[ProtoEnum(Name = "Species_Boss", Value = 1)]
		Species_Boss = 1,
		// Token: 0x0400225E RID: 8798
		[ProtoEnum(Name = "Species_Opposer", Value = 2)]
		Species_Opposer,
		// Token: 0x0400225F RID: 8799
		[ProtoEnum(Name = "Species_Puppet", Value = 3)]
		Species_Puppet,
		// Token: 0x04002260 RID: 8800
		[ProtoEnum(Name = "Species_Npc", Value = 7)]
		Species_Npc = 7,
		// Token: 0x04002261 RID: 8801
		[ProtoEnum(Name = "Species_Role", Value = 10)]
		Species_Role = 10,
		// Token: 0x04002262 RID: 8802
		[ProtoEnum(Name = "Species_Empty", Value = 8)]
		Species_Empty = 8,
		// Token: 0x04002263 RID: 8803
		[ProtoEnum(Name = "Species_Dummy", Value = 9)]
		Species_Dummy,
		// Token: 0x04002264 RID: 8804
		[ProtoEnum(Name = "Species_Substance", Value = 5)]
		Species_Substance = 5,
		// Token: 0x04002265 RID: 8805
		[ProtoEnum(Name = "Species_Affiliate", Value = 11)]
		Species_Affiliate = 11,
		// Token: 0x04002266 RID: 8806
		[ProtoEnum(Name = "Species_Elite", Value = 6)]
		Species_Elite = 6
	}
}
