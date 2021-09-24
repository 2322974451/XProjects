using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OutLookType")]
	public enum OutLookType
	{

		[ProtoEnum(Name = "OutLook_Fashion", Value = 0)]
		OutLook_Fashion,

		[ProtoEnum(Name = "OutLook_Equip", Value = 1)]
		OutLook_Equip
	}
}
