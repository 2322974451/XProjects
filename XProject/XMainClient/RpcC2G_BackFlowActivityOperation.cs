using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200166B RID: 5739
	internal class RpcC2G_BackFlowActivityOperation : Rpc
	{
		// Token: 0x0600EEF8 RID: 61176 RVA: 0x0034A7F4 File Offset: 0x003489F4
		public override uint GetRpcType()
		{
			return 61579U;
		}

		// Token: 0x0600EEF9 RID: 61177 RVA: 0x0034A80B File Offset: 0x00348A0B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BackFlowActivityOperationArg>(stream, this.oArg);
		}

		// Token: 0x0600EEFA RID: 61178 RVA: 0x0034A81B File Offset: 0x00348A1B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BackFlowActivityOperationRes>(stream);
		}

		// Token: 0x0600EEFB RID: 61179 RVA: 0x0034A82A File Offset: 0x00348A2A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BackFlowActivityOperation.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EEFC RID: 61180 RVA: 0x0034A846 File Offset: 0x00348A46
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BackFlowActivityOperation.OnTimeout(this.oArg);
		}

		// Token: 0x0400662E RID: 26158
		public BackFlowActivityOperationArg oArg = new BackFlowActivityOperationArg();

		// Token: 0x0400662F RID: 26159
		public BackFlowActivityOperationRes oRes = null;
	}
}
