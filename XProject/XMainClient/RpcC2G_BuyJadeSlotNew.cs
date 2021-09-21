using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016A9 RID: 5801
	internal class RpcC2G_BuyJadeSlotNew : Rpc
	{
		// Token: 0x0600EFFC RID: 61436 RVA: 0x0034C1E4 File Offset: 0x0034A3E4
		public override uint GetRpcType()
		{
			return 37588U;
		}

		// Token: 0x0600EFFD RID: 61437 RVA: 0x0034C1FB File Offset: 0x0034A3FB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyJadeSlotNewArg>(stream, this.oArg);
		}

		// Token: 0x0600EFFE RID: 61438 RVA: 0x0034C20B File Offset: 0x0034A40B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyJadeSlotNewRes>(stream);
		}

		// Token: 0x0600EFFF RID: 61439 RVA: 0x0034C21A File Offset: 0x0034A41A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyJadeSlotNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600F000 RID: 61440 RVA: 0x0034C236 File Offset: 0x0034A436
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyJadeSlotNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006669 RID: 26217
		public BuyJadeSlotNewArg oArg = new BuyJadeSlotNewArg();

		// Token: 0x0400666A RID: 26218
		public BuyJadeSlotNewRes oRes = null;
	}
}
