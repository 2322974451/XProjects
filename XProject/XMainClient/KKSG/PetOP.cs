using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PetOP")]
	public enum PetOP
	{

		[ProtoEnum(Name = "PetFellow", Value = 1)]
		PetFellow = 1,

		[ProtoEnum(Name = "PetFight", Value = 2)]
		PetFight,

		[ProtoEnum(Name = "PetFeed", Value = 3)]
		PetFeed,

		[ProtoEnum(Name = "PetTouch", Value = 4)]
		PetTouch,

		[ProtoEnum(Name = "PetBorn", Value = 5)]
		PetBorn,

		[ProtoEnum(Name = "PetUpdate", Value = 6)]
		PetUpdate,

		[ProtoEnum(Name = "PetRelease", Value = 7)]
		PetRelease,

		[ProtoEnum(Name = "ExpandSeat", Value = 8)]
		ExpandSeat,

		[ProtoEnum(Name = "PetExpTransfer", Value = 9)]
		PetExpTransfer,

		[ProtoEnum(Name = "useskillbook", Value = 10)]
		useskillbook,

		[ProtoEnum(Name = "SetPetPairRide", Value = 11)]
		SetPetPairRide,

		[ProtoEnum(Name = "QueryPetPairRideInvite", Value = 12)]
		QueryPetPairRideInvite,

		[ProtoEnum(Name = "OffPetPairRide", Value = 13)]
		OffPetPairRide,

		[ProtoEnum(Name = "IgnorePetPairRideInvite", Value = 14)]
		IgnorePetPairRideInvite
	}
}
