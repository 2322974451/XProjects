using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000765 RID: 1893
	[ProtoContract(Name = "SceneFinishState")]
	public enum SceneFinishState
	{
		// Token: 0x04002362 RID: 9058
		[ProtoEnum(Name = "SCENE_FINISH_NONE", Value = 0)]
		SCENE_FINISH_NONE,
		// Token: 0x04002363 RID: 9059
		[ProtoEnum(Name = "SCENE_FINISH_START", Value = 1)]
		SCENE_FINISH_START,
		// Token: 0x04002364 RID: 9060
		[ProtoEnum(Name = "SCENE_FINISH_PICK_ITEM", Value = 2)]
		SCENE_FINISH_PICK_ITEM,
		// Token: 0x04002365 RID: 9061
		[ProtoEnum(Name = "SCENE_FINISH_SHOWRESULT", Value = 3)]
		SCENE_FINISH_SHOWRESULT,
		// Token: 0x04002366 RID: 9062
		[ProtoEnum(Name = "SCENE_FINISH_DRAW_BOX", Value = 4)]
		SCENE_FINISH_DRAW_BOX,
		// Token: 0x04002367 RID: 9063
		[ProtoEnum(Name = "SCENE_FINISH_END", Value = 5)]
		SCENE_FINISH_END
	}
}
