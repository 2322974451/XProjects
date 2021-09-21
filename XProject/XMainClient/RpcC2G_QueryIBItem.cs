using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001247 RID: 4679
	internal class RpcC2G_QueryIBItem : Rpc
	{
		// Token: 0x0600DDEF RID: 56815 RVA: 0x003329BC File Offset: 0x00330BBC
		public override uint GetRpcType()
		{
			return 23880U;
		}

		// Token: 0x0600DDF0 RID: 56816 RVA: 0x003329D3 File Offset: 0x00330BD3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IBQueryItemReq>(stream, this.oArg);
		}

		// Token: 0x0600DDF1 RID: 56817 RVA: 0x003329E3 File Offset: 0x00330BE3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<IBQueryItemRes>(stream);
		}

		// Token: 0x0600DDF2 RID: 56818 RVA: 0x003329F2 File Offset: 0x00330BF2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryIBItem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DDF3 RID: 56819 RVA: 0x00332A0E File Offset: 0x00330C0E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryIBItem.OnTimeout(this.oArg);
		}

		// Token: 0x040062DD RID: 25309
		public IBQueryItemReq oArg = new IBQueryItemReq();

		// Token: 0x040062DE RID: 25310
		public IBQueryItemRes oRes = new IBQueryItemRes();
	}
}
