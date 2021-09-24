using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DBOperType")]
	public enum DBOperType
	{

		[ProtoEnum(Name = "DBOper_Insert", Value = 1)]
		DBOper_Insert = 1,

		[ProtoEnum(Name = "DBOper_Update", Value = 2)]
		DBOper_Update,

		[ProtoEnum(Name = "DBOper_Del", Value = 3)]
		DBOper_Del,

		[ProtoEnum(Name = "DBOper_DelAll", Value = 4)]
		DBOper_DelAll,

		[ProtoEnum(Name = "DBOper_ReplaceId", Value = 5)]
		DBOper_ReplaceId
	}
}
