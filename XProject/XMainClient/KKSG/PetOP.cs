using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000769 RID: 1897
	[ProtoContract(Name = "PetOP")]
	public enum PetOP
	{
		// Token: 0x04002381 RID: 9089
		[ProtoEnum(Name = "PetFellow", Value = 1)]
		PetFellow = 1,
		// Token: 0x04002382 RID: 9090
		[ProtoEnum(Name = "PetFight", Value = 2)]
		PetFight,
		// Token: 0x04002383 RID: 9091
		[ProtoEnum(Name = "PetFeed", Value = 3)]
		PetFeed,
		// Token: 0x04002384 RID: 9092
		[ProtoEnum(Name = "PetTouch", Value = 4)]
		PetTouch,
		// Token: 0x04002385 RID: 9093
		[ProtoEnum(Name = "PetBorn", Value = 5)]
		PetBorn,
		// Token: 0x04002386 RID: 9094
		[ProtoEnum(Name = "PetUpdate", Value = 6)]
		PetUpdate,
		// Token: 0x04002387 RID: 9095
		[ProtoEnum(Name = "PetRelease", Value = 7)]
		PetRelease,
		// Token: 0x04002388 RID: 9096
		[ProtoEnum(Name = "ExpandSeat", Value = 8)]
		ExpandSeat,
		// Token: 0x04002389 RID: 9097
		[ProtoEnum(Name = "PetExpTransfer", Value = 9)]
		PetExpTransfer,
		// Token: 0x0400238A RID: 9098
		[ProtoEnum(Name = "useskillbook", Value = 10)]
		useskillbook,
		// Token: 0x0400238B RID: 9099
		[ProtoEnum(Name = "SetPetPairRide", Value = 11)]
		SetPetPairRide,
		// Token: 0x0400238C RID: 9100
		[ProtoEnum(Name = "QueryPetPairRideInvite", Value = 12)]
		QueryPetPairRideInvite,
		// Token: 0x0400238D RID: 9101
		[ProtoEnum(Name = "OffPetPairRide", Value = 13)]
		OffPetPairRide,
		// Token: 0x0400238E RID: 9102
		[ProtoEnum(Name = "IgnorePetPairRideInvite", Value = 14)]
		IgnorePetPairRideInvite
	}
}
