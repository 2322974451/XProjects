using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeaveSceneType")]
	public enum LeaveSceneType
	{

		[ProtoEnum(Name = "LEAVE_SCENE_LOGOUT", Value = 1)]
		LEAVE_SCENE_LOGOUT = 1,

		[ProtoEnum(Name = "LEAVE_SCENE_SWITCH", Value = 2)]
		LEAVE_SCENE_SWITCH
	}
}
