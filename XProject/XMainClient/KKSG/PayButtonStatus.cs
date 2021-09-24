using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayButtonStatus")]
	public enum PayButtonStatus
	{

		[ProtoEnum(Name = "PAY_BUTTON_NONE", Value = 0)]
		PAY_BUTTON_NONE,

		[ProtoEnum(Name = "PAY_BUTTON_OPEN", Value = 1)]
		PAY_BUTTON_OPEN,

		[ProtoEnum(Name = "PAY_BUTTON_CLICK", Value = 2)]
		PAY_BUTTON_CLICK
	}
}
