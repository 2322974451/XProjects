using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000781 RID: 1921
	[ProtoContract(Name = "LeaveSceneType")]
	public enum LeaveSceneType
	{
		// Token: 0x040023F7 RID: 9207
		[ProtoEnum(Name = "LEAVE_SCENE_LOGOUT", Value = 1)]
		LEAVE_SCENE_LOGOUT = 1,
		// Token: 0x040023F8 RID: 9208
		[ProtoEnum(Name = "LEAVE_SCENE_SWITCH", Value = 2)]
		LEAVE_SCENE_SWITCH
	}
}
