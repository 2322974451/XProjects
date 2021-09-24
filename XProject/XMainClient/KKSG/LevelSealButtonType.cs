using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LevelSealButtonType")]
	public enum LevelSealButtonType
	{

		[ProtoEnum(Name = "BUTTON_STATUS_NONE", Value = 0)]
		BUTTON_STATUS_NONE,

		[ProtoEnum(Name = "BUTTON_STATUS_LOCKED", Value = 1)]
		BUTTON_STATUS_LOCKED,

		[ProtoEnum(Name = "BUTTON_STATUS_UNLOCKED", Value = 2)]
		BUTTON_STATUS_UNLOCKED
	}
}
