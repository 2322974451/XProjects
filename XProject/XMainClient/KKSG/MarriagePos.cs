using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MarriagePos")]
	public enum MarriagePos
	{

		[ProtoEnum(Name = "MarriagePos_Null", Value = 1)]
		MarriagePos_Null = 1,

		[ProtoEnum(Name = "MarriagePos_Husband", Value = 2)]
		MarriagePos_Husband,

		[ProtoEnum(Name = "MarriagePos_Wife", Value = 3)]
		MarriagePos_Wife,

		[ProtoEnum(Name = "Marriage_Max", Value = 4)]
		Marriage_Max
	}
}
