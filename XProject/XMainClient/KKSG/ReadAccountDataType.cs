using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReadAccountDataType")]
	public enum ReadAccountDataType
	{

		[ProtoEnum(Name = "READ_ACCOUNT_DATA_LOGIN", Value = 1)]
		READ_ACCOUNT_DATA_LOGIN = 1,

		[ProtoEnum(Name = "READ_ACCOUNT_DATA_RETURN_SELECT_ROLE", Value = 2)]
		READ_ACCOUNT_DATA_RETURN_SELECT_ROLE,

		[ProtoEnum(Name = "READ_ACCOUNT_DATA_IDIP", Value = 3)]
		READ_ACCOUNT_DATA_IDIP
	}
}
