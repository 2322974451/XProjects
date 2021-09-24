using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LogoutType")]
	public enum LogoutType
	{

		[ProtoEnum(Name = "LOGOUT_ACCOUNT_NORMAL", Value = 1)]
		LOGOUT_ACCOUNT_NORMAL = 1,

		[ProtoEnum(Name = "LOGOUT_RELOGIN_KICK_ACCOUNT", Value = 2)]
		LOGOUT_RELOGIN_KICK_ACCOUNT,

		[ProtoEnum(Name = "LOGOUT_IDIP_KICK_ACCOUNT", Value = 3)]
		LOGOUT_IDIP_KICK_ACCOUNT,

		[ProtoEnum(Name = "LOGOUT_RETURN_SELECT_ROLE", Value = 4)]
		LOGOUT_RETURN_SELECT_ROLE,

		[ProtoEnum(Name = "LOGOUT_CHANGEPROFESSION", Value = 5)]
		LOGOUT_CHANGEPROFESSION
	}
}
