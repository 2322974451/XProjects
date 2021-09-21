using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013E4 RID: 5092
	internal class RpcC2G_TakePartnerChest : Rpc
	{
		// Token: 0x0600E490 RID: 58512 RVA: 0x0033BE24 File Offset: 0x0033A024
		public override uint GetRpcType()
		{
			return 42982U;
		}

		// Token: 0x0600E491 RID: 58513 RVA: 0x0033BE3B File Offset: 0x0033A03B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TakePartnerChestArg>(stream, this.oArg);
		}

		// Token: 0x0600E492 RID: 58514 RVA: 0x0033BE4B File Offset: 0x0033A04B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TakePartnerChestRes>(stream);
		}

		// Token: 0x0600E493 RID: 58515 RVA: 0x0033BE5A File Offset: 0x0033A05A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TakePartnerChest.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E494 RID: 58516 RVA: 0x0033BE76 File Offset: 0x0033A076
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TakePartnerChest.OnTimeout(this.oArg);
		}

		// Token: 0x04006425 RID: 25637
		public TakePartnerChestArg oArg = new TakePartnerChestArg();

		// Token: 0x04006426 RID: 25638
		public TakePartnerChestRes oRes = null;
	}
}
