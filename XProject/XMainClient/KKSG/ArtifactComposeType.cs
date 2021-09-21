using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000816 RID: 2070
	[ProtoContract(Name = "ArtifactComposeType")]
	public enum ArtifactComposeType
	{
		// Token: 0x0400276B RID: 10091
		[ProtoEnum(Name = "ArtifactCompose_Single", Value = 1)]
		ArtifactCompose_Single = 1,
		// Token: 0x0400276C RID: 10092
		[ProtoEnum(Name = "ArtifactCompose_Multi", Value = 2)]
		ArtifactCompose_Multi
	}
}
