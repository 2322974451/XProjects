using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginRewardState")]
	public enum LoginRewardState
	{

		[ProtoEnum(Name = "LOGINRS_CANNOT", Value = 1)]
		LOGINRS_CANNOT = 1,

		[ProtoEnum(Name = "LOGINRS_HAVEHOT", Value = 2)]
		LOGINRS_HAVEHOT,

		[ProtoEnum(Name = "LOGINRS_HAVE", Value = 3)]
		LOGINRS_HAVE
	}
}
