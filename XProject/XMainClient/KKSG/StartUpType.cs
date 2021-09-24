using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StartUpType")]
	public enum StartUpType
	{

		[ProtoEnum(Name = "StartUp_Normal", Value = 1)]
		StartUp_Normal = 1,

		[ProtoEnum(Name = "StartUp_QQ", Value = 2)]
		StartUp_QQ,

		[ProtoEnum(Name = "StartUp_WX", Value = 3)]
		StartUp_WX
	}
}
