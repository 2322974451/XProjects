using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012E8 RID: 4840
	internal class RpcC2G_GmfReadyReq : Rpc
	{
		// Token: 0x0600E08A RID: 57482 RVA: 0x003363AC File Offset: 0x003345AC
		public override uint GetRpcType()
		{
			return 12219U;
		}

		// Token: 0x0600E08B RID: 57483 RVA: 0x003363C3 File Offset: 0x003345C3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfReadyArg>(stream, this.oArg);
		}

		// Token: 0x0600E08C RID: 57484 RVA: 0x003363D3 File Offset: 0x003345D3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GmfReadyRes>(stream);
		}

		// Token: 0x0600E08D RID: 57485 RVA: 0x003363E2 File Offset: 0x003345E2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GmfReadyReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E08E RID: 57486 RVA: 0x003363FE File Offset: 0x003345FE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GmfReadyReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006360 RID: 25440
		public GmfReadyArg oArg = new GmfReadyArg();

		// Token: 0x04006361 RID: 25441
		public GmfReadyRes oRes = new GmfReadyRes();
	}
}
