using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007EB RID: 2027
	[ProtoContract(Name = "LBEleRoomState")]
	public enum LBEleRoomState
	{
		// Token: 0x0400267E RID: 9854
		[ProtoEnum(Name = "LBEleRoomState_Idle", Value = 1)]
		LBEleRoomState_Idle = 1,
		// Token: 0x0400267F RID: 9855
		[ProtoEnum(Name = "LBEleRoomState_Fighting", Value = 2)]
		LBEleRoomState_Fighting,
		// Token: 0x04002680 RID: 9856
		[ProtoEnum(Name = "LBEleRoomState_Finish", Value = 3)]
		LBEleRoomState_Finish
	}
}
