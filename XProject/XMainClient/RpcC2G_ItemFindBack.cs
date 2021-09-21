using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001239 RID: 4665
	internal class RpcC2G_ItemFindBack : Rpc
	{
		// Token: 0x0600DDB2 RID: 56754 RVA: 0x003323B8 File Offset: 0x003305B8
		public override uint GetRpcType()
		{
			return 60242U;
		}

		// Token: 0x0600DDB3 RID: 56755 RVA: 0x003323CF File Offset: 0x003305CF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemFindBackArg>(stream, this.oArg);
		}

		// Token: 0x0600DDB4 RID: 56756 RVA: 0x003323DF File Offset: 0x003305DF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ItemFindBackRes>(stream);
		}

		// Token: 0x0600DDB5 RID: 56757 RVA: 0x003323EE File Offset: 0x003305EE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ItemFindBack.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DDB6 RID: 56758 RVA: 0x0033240A File Offset: 0x0033060A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ItemFindBack.OnTimeout(this.oArg);
		}

		// Token: 0x040062D0 RID: 25296
		public ItemFindBackArg oArg = new ItemFindBackArg();

		// Token: 0x040062D1 RID: 25297
		public ItemFindBackRes oRes = new ItemFindBackRes();
	}
}
