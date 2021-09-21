using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200077F RID: 1919
	[ProtoContract(Name = "EnterSceneType")]
	public enum EnterSceneType
	{
		// Token: 0x040023F1 RID: 9201
		[ProtoEnum(Name = "ENTER_SCENE_SELECT_ROLE", Value = 1)]
		ENTER_SCENE_SELECT_ROLE = 1,
		// Token: 0x040023F2 RID: 9202
		[ProtoEnum(Name = "ENTER_SCENE_SWITCH", Value = 2)]
		ENTER_SCENE_SWITCH
	}
}
