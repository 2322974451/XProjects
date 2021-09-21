using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200106E RID: 4206
	internal class RpcC2I_QueryGateIP : Rpc
	{
		// Token: 0x0600D66F RID: 54895 RVA: 0x00326128 File Offset: 0x00324328
		public override uint GetRpcType()
		{
			return 9179U;
		}

		// Token: 0x0600D670 RID: 54896 RVA: 0x0032613F File Offset: 0x0032433F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryGateArg>(stream, this.oArg);
		}

		// Token: 0x0600D671 RID: 54897 RVA: 0x0032614F File Offset: 0x0032434F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryGateRes>(stream);
		}

		// Token: 0x0600D672 RID: 54898 RVA: 0x0032615E File Offset: 0x0032435E
		public override void Process()
		{
			base.Process();
			Process_RpcC2I_QueryGateIP.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D673 RID: 54899 RVA: 0x0032617A File Offset: 0x0032437A
		public override void OnTimeout(object args)
		{
			Process_RpcC2I_QueryGateIP.OnTimeout(this.oArg);
		}

		// Token: 0x04006177 RID: 24951
		public QueryGateArg oArg = new QueryGateArg();

		// Token: 0x04006178 RID: 24952
		public QueryGateRes oRes = new QueryGateRes();
	}
}
