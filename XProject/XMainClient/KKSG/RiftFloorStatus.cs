using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiftFloorStatus")]
	public enum RiftFloorStatus
	{

		[ProtoEnum(Name = "RiftFloor_NotPass", Value = 1)]
		RiftFloor_NotPass = 1,

		[ProtoEnum(Name = "RiftFloor_CanGetReward", Value = 2)]
		RiftFloor_CanGetReward,

		[ProtoEnum(Name = "RiftFloor_GotReward", Value = 3)]
		RiftFloor_GotReward,

		[ProtoEnum(Name = "RiftFloor_Complete", Value = 4)]
		RiftFloor_Complete,

		[ProtoEnum(Name = "RiftFloor_Max", Value = 5)]
		RiftFloor_Max
	}
}
