using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015D5 RID: 5589
	internal class RpcC2G_BackFlowBuyOp : Rpc
	{
		// Token: 0x0600EC7D RID: 60541 RVA: 0x00347298 File Offset: 0x00345498
		public override uint GetRpcType()
		{
			return 16261U;
		}

		// Token: 0x0600EC7E RID: 60542 RVA: 0x003472AF File Offset: 0x003454AF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BackFlowBuyOpArg>(stream, this.oArg);
		}

		// Token: 0x0600EC7F RID: 60543 RVA: 0x003472BF File Offset: 0x003454BF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BackFlowBuyOpRes>(stream);
		}

		// Token: 0x0600EC80 RID: 60544 RVA: 0x003472CE File Offset: 0x003454CE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BackFlowBuyOp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EC81 RID: 60545 RVA: 0x003472EA File Offset: 0x003454EA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BackFlowBuyOp.OnTimeout(this.oArg);
		}

		// Token: 0x040065AD RID: 26029
		public BackFlowBuyOpArg oArg = new BackFlowBuyOpArg();

		// Token: 0x040065AE RID: 26030
		public BackFlowBuyOpRes oRes = null;
	}
}
