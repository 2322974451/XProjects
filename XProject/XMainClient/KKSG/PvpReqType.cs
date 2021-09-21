using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200077B RID: 1915
	[ProtoContract(Name = "PvpReqType")]
	public enum PvpReqType
	{
		// Token: 0x040023D7 RID: 9175
		[ProtoEnum(Name = "PVP_REQ_IN_MATCH", Value = 1)]
		PVP_REQ_IN_MATCH = 1,
		// Token: 0x040023D8 RID: 9176
		[ProtoEnum(Name = "PVP_REQ_OUT_MATCH", Value = 2)]
		PVP_REQ_OUT_MATCH,
		// Token: 0x040023D9 RID: 9177
		[ProtoEnum(Name = "PVP_REQ_BASE_DATA", Value = 3)]
		PVP_REQ_BASE_DATA,
		// Token: 0x040023DA RID: 9178
		[ProtoEnum(Name = "PVP_REQ_HISTORY_REC", Value = 4)]
		PVP_REQ_HISTORY_REC,
		// Token: 0x040023DB RID: 9179
		[ProtoEnum(Name = "PVP_REQ_GET_WEEKREWARD", Value = 5)]
		PVP_REQ_GET_WEEKREWARD
	}
}
