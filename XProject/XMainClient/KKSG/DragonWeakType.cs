using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200081F RID: 2079
	[ProtoContract(Name = "DragonWeakType")]
	public enum DragonWeakType
	{
		// Token: 0x040027A8 RID: 10152
		[ProtoEnum(Name = "DragonWeakType_Null", Value = 1)]
		DragonWeakType_Null = 1,
		// Token: 0x040027A9 RID: 10153
		[ProtoEnum(Name = "DragonWeakType_Pass", Value = 2)]
		DragonWeakType_Pass,
		// Token: 0x040027AA RID: 10154
		[ProtoEnum(Name = "DragonWeakType_NotPass", Value = 3)]
		DragonWeakType_NotPass,
		// Token: 0x040027AB RID: 10155
		[ProtoEnum(Name = "DragonWeakType_Max", Value = 4)]
		DragonWeakType_Max
	}
}
