using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015AD RID: 5549
	internal class RpcC2G_WeddingOperator : Rpc
	{
		// Token: 0x0600EBDA RID: 60378 RVA: 0x003464DC File Offset: 0x003446DC
		public override uint GetRpcType()
		{
			return 38050U;
		}

		// Token: 0x0600EBDB RID: 60379 RVA: 0x003464F3 File Offset: 0x003446F3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingOperatorArg>(stream, this.oArg);
		}

		// Token: 0x0600EBDC RID: 60380 RVA: 0x00346503 File Offset: 0x00344703
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<WeddingOperatorRes>(stream);
		}

		// Token: 0x0600EBDD RID: 60381 RVA: 0x00346512 File Offset: 0x00344712
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_WeddingOperator.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EBDE RID: 60382 RVA: 0x0034652E File Offset: 0x0034472E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_WeddingOperator.OnTimeout(this.oArg);
		}

		// Token: 0x0400658F RID: 25999
		public WeddingOperatorArg oArg = new WeddingOperatorArg();

		// Token: 0x04006590 RID: 26000
		public WeddingOperatorRes oRes = null;
	}
}
