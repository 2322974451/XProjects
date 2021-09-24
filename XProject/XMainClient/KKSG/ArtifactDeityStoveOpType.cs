using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArtifactDeityStoveOpType")]
	public enum ArtifactDeityStoveOpType
	{

		[ProtoEnum(Name = "ArtifactDeityStove_Recast", Value = 1)]
		ArtifactDeityStove_Recast = 1,

		[ProtoEnum(Name = "ArtifactDeityStove_Fuse", Value = 2)]
		ArtifactDeityStove_Fuse,

		[ProtoEnum(Name = "ArtifactDeityStove_Inscription", Value = 3)]
		ArtifactDeityStove_Inscription,

		[ProtoEnum(Name = "ArtifactDeityStove_Refine", Value = 4)]
		ArtifactDeityStove_Refine,

		[ProtoEnum(Name = "ArtifactDeityStove_RefineRetain", Value = 5)]
		ArtifactDeityStove_RefineRetain,

		[ProtoEnum(Name = "ArtifactDeityStove_RefineReplace", Value = 6)]
		ArtifactDeityStove_RefineReplace
	}
}
