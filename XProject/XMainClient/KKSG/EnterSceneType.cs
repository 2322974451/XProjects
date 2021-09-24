using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EnterSceneType")]
	public enum EnterSceneType
	{

		[ProtoEnum(Name = "ENTER_SCENE_SELECT_ROLE", Value = 1)]
		ENTER_SCENE_SELECT_ROLE = 1,

		[ProtoEnum(Name = "ENTER_SCENE_SWITCH", Value = 2)]
		ENTER_SCENE_SWITCH
	}
}
