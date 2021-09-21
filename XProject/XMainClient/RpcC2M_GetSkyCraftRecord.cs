using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014E3 RID: 5347
	internal class RpcC2M_GetSkyCraftRecord : Rpc
	{
		// Token: 0x0600E899 RID: 59545 RVA: 0x003417D8 File Offset: 0x0033F9D8
		public override uint GetRpcType()
		{
			return 39327U;
		}

		// Token: 0x0600E89A RID: 59546 RVA: 0x003417EF File Offset: 0x0033F9EF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSkyCraftRecordArg>(stream, this.oArg);
		}

		// Token: 0x0600E89B RID: 59547 RVA: 0x003417FF File Offset: 0x0033F9FF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSkyCraftRecordRes>(stream);
		}

		// Token: 0x0600E89C RID: 59548 RVA: 0x0034180E File Offset: 0x0033FA0E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetSkyCraftRecord.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E89D RID: 59549 RVA: 0x0034182A File Offset: 0x0033FA2A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetSkyCraftRecord.OnTimeout(this.oArg);
		}

		// Token: 0x040064E6 RID: 25830
		public GetSkyCraftRecordArg oArg = new GetSkyCraftRecordArg();

		// Token: 0x040064E7 RID: 25831
		public GetSkyCraftRecordRes oRes = null;
	}
}
