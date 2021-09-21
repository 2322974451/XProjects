using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200075B RID: 1883
	[ProtoContract(Name = "LoginType")]
	public enum LoginType
	{
		// Token: 0x04002304 RID: 8964
		[ProtoEnum(Name = "LOGIN_PASSWORD", Value = 0)]
		LOGIN_PASSWORD,
		// Token: 0x04002305 RID: 8965
		[ProtoEnum(Name = "LOGIN_SNDA_PF", Value = 1)]
		LOGIN_SNDA_PF,
		// Token: 0x04002306 RID: 8966
		[ProtoEnum(Name = "LOGIN_QQ_PF", Value = 2)]
		LOGIN_QQ_PF,
		// Token: 0x04002307 RID: 8967
		[ProtoEnum(Name = "LGOIN_WECHAT_PF", Value = 3)]
		LGOIN_WECHAT_PF,
		// Token: 0x04002308 RID: 8968
		[ProtoEnum(Name = "LOGIN_IOS_GUEST", Value = 4)]
		LOGIN_IOS_GUEST,
		// Token: 0x04002309 RID: 8969
		[ProtoEnum(Name = "LOGIN_IOS_AUDIT", Value = 5)]
		LOGIN_IOS_AUDIT
	}
}
