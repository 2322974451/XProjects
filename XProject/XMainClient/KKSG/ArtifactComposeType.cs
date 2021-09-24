using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArtifactComposeType")]
	public enum ArtifactComposeType
	{

		[ProtoEnum(Name = "ArtifactCompose_Single", Value = 1)]
		ArtifactCompose_Single = 1,

		[ProtoEnum(Name = "ArtifactCompose_Multi", Value = 2)]
		ArtifactCompose_Multi
	}
}
