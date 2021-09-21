using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007C8 RID: 1992
	[ProtoContract(Name = "OutLookStateType")]
	public enum OutLookStateType
	{
		// Token: 0x040025BD RID: 9661
		[ProtoEnum(Name = "OutLook_Normal", Value = 0)]
		OutLook_Normal,
		// Token: 0x040025BE RID: 9662
		[ProtoEnum(Name = "OutLook_Sit", Value = 1)]
		OutLook_Sit,
		// Token: 0x040025BF RID: 9663
		[ProtoEnum(Name = "OutLook_Dance", Value = 2)]
		OutLook_Dance,
		// Token: 0x040025C0 RID: 9664
		[ProtoEnum(Name = "OutLook_RidePet", Value = 3)]
		OutLook_RidePet,
		// Token: 0x040025C1 RID: 9665
		[ProtoEnum(Name = "OutLook_Inherit", Value = 4)]
		OutLook_Inherit,
		// Token: 0x040025C2 RID: 9666
		[ProtoEnum(Name = "OutLook_Fish", Value = 5)]
		OutLook_Fish,
		// Token: 0x040025C3 RID: 9667
		[ProtoEnum(Name = "OutLook_RidePetCopilot", Value = 6)]
		OutLook_RidePetCopilot,
		// Token: 0x040025C4 RID: 9668
		[ProtoEnum(Name = "OutLook_Trans", Value = 7)]
		OutLook_Trans
	}
}
