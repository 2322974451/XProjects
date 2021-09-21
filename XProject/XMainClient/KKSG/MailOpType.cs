using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200078C RID: 1932
	[ProtoContract(Name = "MailOpType")]
	public enum MailOpType
	{
		// Token: 0x04002449 RID: 9289
		[ProtoEnum(Name = "MAIL_OP_ADD", Value = 1)]
		MAIL_OP_ADD = 1,
		// Token: 0x0400244A RID: 9290
		[ProtoEnum(Name = "MAIL_OP_UPDATE", Value = 2)]
		MAIL_OP_UPDATE,
		// Token: 0x0400244B RID: 9291
		[ProtoEnum(Name = "MAIL_OP_DELETE", Value = 3)]
		MAIL_OP_DELETE,
		// Token: 0x0400244C RID: 9292
		[ProtoEnum(Name = "MAIL_OP_DELETE_ALL", Value = 4)]
		MAIL_OP_DELETE_ALL
	}
}
