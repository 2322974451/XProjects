using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001237 RID: 4663
	internal class RpcC2G_ItemFindBackInfo : Rpc
	{
		// Token: 0x0600DDA9 RID: 56745 RVA: 0x003322EC File Offset: 0x003304EC
		public override uint GetRpcType()
		{
			return 11755U;
		}

		// Token: 0x0600DDAA RID: 56746 RVA: 0x00332303 File Offset: 0x00330503
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemFindBackInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600DDAB RID: 56747 RVA: 0x00332313 File Offset: 0x00330513
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ItemFindBackInfoRes>(stream);
		}

		// Token: 0x0600DDAC RID: 56748 RVA: 0x00332322 File Offset: 0x00330522
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ItemFindBackInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DDAD RID: 56749 RVA: 0x0033233E File Offset: 0x0033053E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ItemFindBackInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040062CE RID: 25294
		public ItemFindBackInfoArg oArg = new ItemFindBackInfoArg();

		// Token: 0x040062CF RID: 25295
		public ItemFindBackInfoRes oRes = new ItemFindBackInfoRes();
	}
}
