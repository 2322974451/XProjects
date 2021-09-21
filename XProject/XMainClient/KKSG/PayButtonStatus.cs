using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000799 RID: 1945
	[ProtoContract(Name = "PayButtonStatus")]
	public enum PayButtonStatus
	{
		// Token: 0x04002496 RID: 9366
		[ProtoEnum(Name = "PAY_BUTTON_NONE", Value = 0)]
		PAY_BUTTON_NONE,
		// Token: 0x04002497 RID: 9367
		[ProtoEnum(Name = "PAY_BUTTON_OPEN", Value = 1)]
		PAY_BUTTON_OPEN,
		// Token: 0x04002498 RID: 9368
		[ProtoEnum(Name = "PAY_BUTTON_CLICK", Value = 2)]
		PAY_BUTTON_CLICK
	}
}
