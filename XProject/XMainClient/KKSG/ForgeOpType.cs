using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ForgeOpType")]
	public enum ForgeOpType
	{

		[ProtoEnum(Name = "Forge_Equip", Value = 1)]
		Forge_Equip = 1,

		[ProtoEnum(Name = "Forge_Replace", Value = 2)]
		Forge_Replace,

		[ProtoEnum(Name = "Forge_Retain", Value = 3)]
		Forge_Retain
	}
}
