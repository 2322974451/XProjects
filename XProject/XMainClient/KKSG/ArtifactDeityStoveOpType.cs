using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200081E RID: 2078
	[ProtoContract(Name = "ArtifactDeityStoveOpType")]
	public enum ArtifactDeityStoveOpType
	{
		// Token: 0x040027A1 RID: 10145
		[ProtoEnum(Name = "ArtifactDeityStove_Recast", Value = 1)]
		ArtifactDeityStove_Recast = 1,
		// Token: 0x040027A2 RID: 10146
		[ProtoEnum(Name = "ArtifactDeityStove_Fuse", Value = 2)]
		ArtifactDeityStove_Fuse,
		// Token: 0x040027A3 RID: 10147
		[ProtoEnum(Name = "ArtifactDeityStove_Inscription", Value = 3)]
		ArtifactDeityStove_Inscription,
		// Token: 0x040027A4 RID: 10148
		[ProtoEnum(Name = "ArtifactDeityStove_Refine", Value = 4)]
		ArtifactDeityStove_Refine,
		// Token: 0x040027A5 RID: 10149
		[ProtoEnum(Name = "ArtifactDeityStove_RefineRetain", Value = 5)]
		ArtifactDeityStove_RefineRetain,
		// Token: 0x040027A6 RID: 10150
		[ProtoEnum(Name = "ArtifactDeityStove_RefineReplace", Value = 6)]
		ArtifactDeityStove_RefineReplace
	}
}
