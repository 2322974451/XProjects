using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200137B RID: 4987
	internal class RpcC2G_ItemBuffOp : Rpc
	{
		// Token: 0x0600E2E2 RID: 58082 RVA: 0x00339AC8 File Offset: 0x00337CC8
		public override uint GetRpcType()
		{
			return 50404U;
		}

		// Token: 0x0600E2E3 RID: 58083 RVA: 0x00339ADF File Offset: 0x00337CDF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemBuffOpArg>(stream, this.oArg);
		}

		// Token: 0x0600E2E4 RID: 58084 RVA: 0x00339AEF File Offset: 0x00337CEF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ItemBuffOpRes>(stream);
		}

		// Token: 0x0600E2E5 RID: 58085 RVA: 0x00339AFE File Offset: 0x00337CFE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ItemBuffOp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E2E6 RID: 58086 RVA: 0x00339B1A File Offset: 0x00337D1A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ItemBuffOp.OnTimeout(this.oArg);
		}

		// Token: 0x040063D3 RID: 25555
		public ItemBuffOpArg oArg = new ItemBuffOpArg();

		// Token: 0x040063D4 RID: 25556
		public ItemBuffOpRes oRes = new ItemBuffOpRes();
	}
}
