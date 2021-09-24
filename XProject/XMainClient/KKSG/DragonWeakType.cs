using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonWeakType")]
	public enum DragonWeakType
	{

		[ProtoEnum(Name = "DragonWeakType_Null", Value = 1)]
		DragonWeakType_Null = 1,

		[ProtoEnum(Name = "DragonWeakType_Pass", Value = 2)]
		DragonWeakType_Pass,

		[ProtoEnum(Name = "DragonWeakType_NotPass", Value = 3)]
		DragonWeakType_NotPass,

		[ProtoEnum(Name = "DragonWeakType_Max", Value = 4)]
		DragonWeakType_Max
	}
}
