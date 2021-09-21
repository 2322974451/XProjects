using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000815 RID: 2069
	[ProtoContract(Name = "PetOtherOp")]
	public enum PetOtherOp
	{
		// Token: 0x04002767 RID: 10087
		[ProtoEnum(Name = "DoPetPairRide", Value = 1)]
		DoPetPairRide = 1,
		// Token: 0x04002768 RID: 10088
		[ProtoEnum(Name = "InvitePetPairRide", Value = 2)]
		InvitePetPairRide,
		// Token: 0x04002769 RID: 10089
		[ProtoEnum(Name = "AgreePetPairRide", Value = 3)]
		AgreePetPairRide
	}
}
