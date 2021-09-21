using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001624 RID: 5668
	internal class RpcC2G_TakeDragonGuildChest : Rpc
	{
		// Token: 0x0600EDCC RID: 60876 RVA: 0x00348DC8 File Offset: 0x00346FC8
		public override uint GetRpcType()
		{
			return 38031U;
		}

		// Token: 0x0600EDCD RID: 60877 RVA: 0x00348DDF File Offset: 0x00346FDF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TakePartnerChestArg>(stream, this.oArg);
		}

		// Token: 0x0600EDCE RID: 60878 RVA: 0x00348DEF File Offset: 0x00346FEF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TakePartnerChestRes>(stream);
		}

		// Token: 0x0600EDCF RID: 60879 RVA: 0x00348DFE File Offset: 0x00346FFE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TakeDragonGuildChest.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EDD0 RID: 60880 RVA: 0x00348E1A File Offset: 0x0034701A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TakeDragonGuildChest.OnTimeout(this.oArg);
		}

		// Token: 0x040065F1 RID: 26097
		public TakePartnerChestArg oArg = new TakePartnerChestArg();

		// Token: 0x040065F2 RID: 26098
		public TakePartnerChestRes oRes = null;
	}
}
