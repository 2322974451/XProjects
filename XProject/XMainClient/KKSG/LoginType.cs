using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginType")]
	public enum LoginType
	{

		[ProtoEnum(Name = "LOGIN_PASSWORD", Value = 0)]
		LOGIN_PASSWORD,

		[ProtoEnum(Name = "LOGIN_SNDA_PF", Value = 1)]
		LOGIN_SNDA_PF,

		[ProtoEnum(Name = "LOGIN_QQ_PF", Value = 2)]
		LOGIN_QQ_PF,

		[ProtoEnum(Name = "LGOIN_WECHAT_PF", Value = 3)]
		LGOIN_WECHAT_PF,

		[ProtoEnum(Name = "LOGIN_IOS_GUEST", Value = 4)]
		LOGIN_IOS_GUEST,

		[ProtoEnum(Name = "LOGIN_IOS_AUDIT", Value = 5)]
		LOGIN_IOS_AUDIT
	}
}
