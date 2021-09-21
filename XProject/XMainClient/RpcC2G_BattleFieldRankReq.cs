using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015EF RID: 5615
	internal class RpcC2G_BattleFieldRankReq : Rpc
	{
		// Token: 0x0600ECE9 RID: 60649 RVA: 0x00347B5C File Offset: 0x00345D5C
		public override uint GetRpcType()
		{
			return 4893U;
		}

		// Token: 0x0600ECEA RID: 60650 RVA: 0x00347B73 File Offset: 0x00345D73
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleFieldRankArg>(stream, this.oArg);
		}

		// Token: 0x0600ECEB RID: 60651 RVA: 0x00347B83 File Offset: 0x00345D83
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BattleFieldRankRes>(stream);
		}

		// Token: 0x0600ECEC RID: 60652 RVA: 0x00347B92 File Offset: 0x00345D92
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BattleFieldRankReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ECED RID: 60653 RVA: 0x00347BAE File Offset: 0x00345DAE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BattleFieldRankReq.OnTimeout(this.oArg);
		}

		// Token: 0x040065C2 RID: 26050
		public BattleFieldRankArg oArg = new BattleFieldRankArg();

		// Token: 0x040065C3 RID: 26051
		public BattleFieldRankRes oRes = null;
	}
}
