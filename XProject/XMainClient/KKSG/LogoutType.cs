using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200078B RID: 1931
	[ProtoContract(Name = "LogoutType")]
	public enum LogoutType
	{
		// Token: 0x04002443 RID: 9283
		[ProtoEnum(Name = "LOGOUT_ACCOUNT_NORMAL", Value = 1)]
		LOGOUT_ACCOUNT_NORMAL = 1,
		// Token: 0x04002444 RID: 9284
		[ProtoEnum(Name = "LOGOUT_RELOGIN_KICK_ACCOUNT", Value = 2)]
		LOGOUT_RELOGIN_KICK_ACCOUNT,
		// Token: 0x04002445 RID: 9285
		[ProtoEnum(Name = "LOGOUT_IDIP_KICK_ACCOUNT", Value = 3)]
		LOGOUT_IDIP_KICK_ACCOUNT,
		// Token: 0x04002446 RID: 9286
		[ProtoEnum(Name = "LOGOUT_RETURN_SELECT_ROLE", Value = 4)]
		LOGOUT_RETURN_SELECT_ROLE,
		// Token: 0x04002447 RID: 9287
		[ProtoEnum(Name = "LOGOUT_CHANGEPROFESSION", Value = 5)]
		LOGOUT_CHANGEPROFESSION
	}
}
