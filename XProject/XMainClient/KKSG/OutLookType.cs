using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007A2 RID: 1954
	[ProtoContract(Name = "OutLookType")]
	public enum OutLookType
	{
		// Token: 0x040024D0 RID: 9424
		[ProtoEnum(Name = "OutLook_Fashion", Value = 0)]
		OutLook_Fashion,
		// Token: 0x040024D1 RID: 9425
		[ProtoEnum(Name = "OutLook_Equip", Value = 1)]
		OutLook_Equip
	}
}
