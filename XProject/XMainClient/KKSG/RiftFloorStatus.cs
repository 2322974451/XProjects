using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000832 RID: 2098
	[ProtoContract(Name = "RiftFloorStatus")]
	public enum RiftFloorStatus
	{
		// Token: 0x04002810 RID: 10256
		[ProtoEnum(Name = "RiftFloor_NotPass", Value = 1)]
		RiftFloor_NotPass = 1,
		// Token: 0x04002811 RID: 10257
		[ProtoEnum(Name = "RiftFloor_CanGetReward", Value = 2)]
		RiftFloor_CanGetReward,
		// Token: 0x04002812 RID: 10258
		[ProtoEnum(Name = "RiftFloor_GotReward", Value = 3)]
		RiftFloor_GotReward,
		// Token: 0x04002813 RID: 10259
		[ProtoEnum(Name = "RiftFloor_Complete", Value = 4)]
		RiftFloor_Complete,
		// Token: 0x04002814 RID: 10260
		[ProtoEnum(Name = "RiftFloor_Max", Value = 5)]
		RiftFloor_Max
	}
}
