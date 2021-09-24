using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ServerFlag")]
	public enum ServerFlag
	{

		[ProtoEnum(Name = "ServerFlag_Maintain", Value = 0)]
		ServerFlag_Maintain,

		[ProtoEnum(Name = "ServerFlag_New", Value = 1)]
		ServerFlag_New,

		[ProtoEnum(Name = "ServerFlag_Hot", Value = 2)]
		ServerFlag_Hot,

		[ProtoEnum(Name = "ServerFlag_Full", Value = 3)]
		ServerFlag_Full,

		[ProtoEnum(Name = "ServerFlag_Recommend", Value = 4)]
		ServerFlag_Recommend,

		[ProtoEnum(Name = "ServerFlag_Dummy", Value = 5)]
		ServerFlag_Dummy,

		[ProtoEnum(Name = "ServerFlag_Smooth", Value = 7)]
		ServerFlag_Smooth = 7
	}
}
