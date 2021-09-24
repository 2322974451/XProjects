using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleDataReadType")]
	public enum RoleDataReadType
	{

		[ProtoEnum(Name = "ROLE_DATA_READ_SELECT_ROLE", Value = 1)]
		ROLE_DATA_READ_SELECT_ROLE = 1,

		[ProtoEnum(Name = "ROLE_DATA_READ_IDIP", Value = 2)]
		ROLE_DATA_READ_IDIP
	}
}
