using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MailOpType")]
	public enum MailOpType
	{

		[ProtoEnum(Name = "MAIL_OP_ADD", Value = 1)]
		MAIL_OP_ADD = 1,

		[ProtoEnum(Name = "MAIL_OP_UPDATE", Value = 2)]
		MAIL_OP_UPDATE,

		[ProtoEnum(Name = "MAIL_OP_DELETE", Value = 3)]
		MAIL_OP_DELETE,

		[ProtoEnum(Name = "MAIL_OP_DELETE_ALL", Value = 4)]
		MAIL_OP_DELETE_ALL
	}
}
