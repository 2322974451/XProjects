using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AuctDBDataOperate")]
	public enum AuctDBDataOperate
	{

		[ProtoEnum(Name = "AUCTDBDATA_INSERT", Value = 1)]
		AUCTDBDATA_INSERT = 1,

		[ProtoEnum(Name = "AUCTDBDATA_UPDATE", Value = 2)]
		AUCTDBDATA_UPDATE,

		[ProtoEnum(Name = "AUCTDBDATA_DELETE", Value = 3)]
		AUCTDBDATA_DELETE
	}
}
