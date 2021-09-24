using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PunishDataType")]
	public enum PunishDataType
	{

		[ProtoEnum(Name = "PUNISH_DATA_UPATE", Value = 1)]
		PUNISH_DATA_UPATE = 1,

		[ProtoEnum(Name = "PUNISH_DATA_DELETE", Value = 2)]
		PUNISH_DATA_DELETE
	}
}
