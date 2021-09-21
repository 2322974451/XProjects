using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011EA RID: 4586
	internal class RpcC2M_InvHistoryC2MReq : Rpc
	{
		// Token: 0x0600DC6D RID: 56429 RVA: 0x0033057C File Offset: 0x0032E77C
		public override uint GetRpcType()
		{
			return 29978U;
		}

		// Token: 0x0600DC6E RID: 56430 RVA: 0x00330593 File Offset: 0x0032E793
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InvHistoryArg>(stream, this.oArg);
		}

		// Token: 0x0600DC6F RID: 56431 RVA: 0x003305A3 File Offset: 0x0032E7A3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<InvHistoryRes>(stream);
		}

		// Token: 0x0600DC70 RID: 56432 RVA: 0x003305B2 File Offset: 0x0032E7B2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_InvHistoryC2MReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DC71 RID: 56433 RVA: 0x003305CE File Offset: 0x0032E7CE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_InvHistoryC2MReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006291 RID: 25233
		public InvHistoryArg oArg = new InvHistoryArg();

		// Token: 0x04006292 RID: 25234
		public InvHistoryRes oRes;
	}
}
