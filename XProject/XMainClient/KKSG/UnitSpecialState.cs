using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UnitSpecialState")]
	public enum UnitSpecialState
	{

		[ProtoEnum(Name = "Unit_Puppet", Value = 1)]
		Unit_Puppet = 1,

		[ProtoEnum(Name = "Unit_Invisible", Value = 2)]
		Unit_Invisible
	}
}
