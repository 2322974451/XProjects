using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200115A RID: 4442
	internal class RpcC2G_GetMyWatchRecord : Rpc
	{
		// Token: 0x0600DA34 RID: 55860 RVA: 0x0032CD50 File Offset: 0x0032AF50
		public override uint GetRpcType()
		{
			return 22907U;
		}

		// Token: 0x0600DA35 RID: 55861 RVA: 0x0032CD67 File Offset: 0x0032AF67
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMyWatchRecordArg>(stream, this.oArg);
		}

		// Token: 0x0600DA36 RID: 55862 RVA: 0x0032CD77 File Offset: 0x0032AF77
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMyWatchRecordRes>(stream);
		}

		// Token: 0x0600DA37 RID: 55863 RVA: 0x0032CD86 File Offset: 0x0032AF86
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetMyWatchRecord.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA38 RID: 55864 RVA: 0x0032CDA2 File Offset: 0x0032AFA2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetMyWatchRecord.OnTimeout(this.oArg);
		}

		// Token: 0x0400622B RID: 25131
		public GetMyWatchRecordArg oArg = new GetMyWatchRecordArg();

		// Token: 0x0400622C RID: 25132
		public GetMyWatchRecordRes oRes = new GetMyWatchRecordRes();
	}
}
