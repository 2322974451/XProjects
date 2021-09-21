using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007BA RID: 1978
	[ProtoContract(Name = "RoleEventType")]
	public enum RoleEventType
	{
		// Token: 0x04002565 RID: 9573
		[ProtoEnum(Name = "OnSendFriendGift", Value = 1)]
		OnSendFriendGift = 1
	}
}
