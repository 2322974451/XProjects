using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020007D6 RID: 2006
	[ProtoContract(Name = "PartnerOperType")]
	public enum PartnerOperType
	{
		// Token: 0x04002610 RID: 9744
		[ProtoEnum(Name = "POT_Normal", Value = 1)]
		POT_Normal = 1,
		// Token: 0x04002611 RID: 9745
		[ProtoEnum(Name = "POT_Liveness", Value = 2)]
		POT_Liveness,
		// Token: 0x04002612 RID: 9746
		[ProtoEnum(Name = "POT_Leave", Value = 3)]
		POT_Leave,
		// Token: 0x04002613 RID: 9747
		[ProtoEnum(Name = "POT_ApplyLeave", Value = 4)]
		POT_ApplyLeave,
		// Token: 0x04002614 RID: 9748
		[ProtoEnum(Name = "POT_CancelLeave", Value = 5)]
		POT_CancelLeave,
		// Token: 0x04002615 RID: 9749
		[ProtoEnum(Name = "POT_Dissolve", Value = 6)]
		POT_Dissolve
	}
}
