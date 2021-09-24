using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "InvFightNotifyType")]
	public enum InvFightNotifyType
	{

		[ProtoEnum(Name = "IFNT_REFUSE_ME", Value = 1)]
		IFNT_REFUSE_ME = 1,

		[ProtoEnum(Name = "IFNT_INVITE_ME", Value = 2)]
		IFNT_INVITE_ME
	}
}
