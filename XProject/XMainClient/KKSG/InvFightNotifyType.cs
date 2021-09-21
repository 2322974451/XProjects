using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007D8 RID: 2008
	[ProtoContract(Name = "InvFightNotifyType")]
	public enum InvFightNotifyType
	{
		// Token: 0x0400261D RID: 9757
		[ProtoEnum(Name = "IFNT_REFUSE_ME", Value = 1)]
		IFNT_REFUSE_ME = 1,
		// Token: 0x0400261E RID: 9758
		[ProtoEnum(Name = "IFNT_INVITE_ME", Value = 2)]
		IFNT_INVITE_ME
	}
}
