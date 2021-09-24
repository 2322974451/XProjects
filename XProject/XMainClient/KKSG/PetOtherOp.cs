using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PetOtherOp")]
	public enum PetOtherOp
	{

		[ProtoEnum(Name = "DoPetPairRide", Value = 1)]
		DoPetPairRide = 1,

		[ProtoEnum(Name = "InvitePetPairRide", Value = 2)]
		InvitePetPairRide,

		[ProtoEnum(Name = "AgreePetPairRide", Value = 3)]
		AgreePetPairRide
	}
}
