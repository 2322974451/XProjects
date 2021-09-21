using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200078A RID: 1930
	[ProtoContract(Name = "ReadAccountDataType")]
	public enum ReadAccountDataType
	{
		// Token: 0x0400243F RID: 9279
		[ProtoEnum(Name = "READ_ACCOUNT_DATA_LOGIN", Value = 1)]
		READ_ACCOUNT_DATA_LOGIN = 1,
		// Token: 0x04002440 RID: 9280
		[ProtoEnum(Name = "READ_ACCOUNT_DATA_RETURN_SELECT_ROLE", Value = 2)]
		READ_ACCOUNT_DATA_RETURN_SELECT_ROLE,
		// Token: 0x04002441 RID: 9281
		[ProtoEnum(Name = "READ_ACCOUNT_DATA_IDIP", Value = 3)]
		READ_ACCOUNT_DATA_IDIP
	}
}
