using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SceneFinishState")]
	public enum SceneFinishState
	{

		[ProtoEnum(Name = "SCENE_FINISH_NONE", Value = 0)]
		SCENE_FINISH_NONE,

		[ProtoEnum(Name = "SCENE_FINISH_START", Value = 1)]
		SCENE_FINISH_START,

		[ProtoEnum(Name = "SCENE_FINISH_PICK_ITEM", Value = 2)]
		SCENE_FINISH_PICK_ITEM,

		[ProtoEnum(Name = "SCENE_FINISH_SHOWRESULT", Value = 3)]
		SCENE_FINISH_SHOWRESULT,

		[ProtoEnum(Name = "SCENE_FINISH_DRAW_BOX", Value = 4)]
		SCENE_FINISH_DRAW_BOX,

		[ProtoEnum(Name = "SCENE_FINISH_END", Value = 5)]
		SCENE_FINISH_END
	}
}
