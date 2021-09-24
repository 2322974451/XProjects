using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemEnum")]
	public enum ItemEnum
	{

		[ProtoEnum(Name = "Virtual_Max", Value = 50)]
		Virtual_Max = 50
	}
}
