using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OutLookStateType")]
	public enum OutLookStateType
	{

		[ProtoEnum(Name = "OutLook_Normal", Value = 0)]
		OutLook_Normal,

		[ProtoEnum(Name = "OutLook_Sit", Value = 1)]
		OutLook_Sit,

		[ProtoEnum(Name = "OutLook_Dance", Value = 2)]
		OutLook_Dance,

		[ProtoEnum(Name = "OutLook_RidePet", Value = 3)]
		OutLook_RidePet,

		[ProtoEnum(Name = "OutLook_Inherit", Value = 4)]
		OutLook_Inherit,

		[ProtoEnum(Name = "OutLook_Fish", Value = 5)]
		OutLook_Fish,

		[ProtoEnum(Name = "OutLook_RidePetCopilot", Value = 6)]
		OutLook_RidePetCopilot,

		[ProtoEnum(Name = "OutLook_Trans", Value = 7)]
		OutLook_Trans
	}
}
