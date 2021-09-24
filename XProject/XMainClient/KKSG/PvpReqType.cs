using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PvpReqType")]
	public enum PvpReqType
	{

		[ProtoEnum(Name = "PVP_REQ_IN_MATCH", Value = 1)]
		PVP_REQ_IN_MATCH = 1,

		[ProtoEnum(Name = "PVP_REQ_OUT_MATCH", Value = 2)]
		PVP_REQ_OUT_MATCH,

		[ProtoEnum(Name = "PVP_REQ_BASE_DATA", Value = 3)]
		PVP_REQ_BASE_DATA,

		[ProtoEnum(Name = "PVP_REQ_HISTORY_REC", Value = 4)]
		PVP_REQ_HISTORY_REC,

		[ProtoEnum(Name = "PVP_REQ_GET_WEEKREWARD", Value = 5)]
		PVP_REQ_GET_WEEKREWARD
	}
}
