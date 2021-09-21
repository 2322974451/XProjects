using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013C2 RID: 5058
	internal class RpcC2G_QueryQQFriendsVipInfo : Rpc
	{
		// Token: 0x0600E404 RID: 58372 RVA: 0x0033B1F8 File Offset: 0x003393F8
		public override uint GetRpcType()
		{
			return 11531U;
		}

		// Token: 0x0600E405 RID: 58373 RVA: 0x0033B20F File Offset: 0x0033940F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryQQFriendsVipInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E406 RID: 58374 RVA: 0x0033B21F File Offset: 0x0033941F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryQQFriendsVipInfoRes>(stream);
		}

		// Token: 0x0600E407 RID: 58375 RVA: 0x0033B22E File Offset: 0x0033942E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryQQFriendsVipInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E408 RID: 58376 RVA: 0x0033B24A File Offset: 0x0033944A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryQQFriendsVipInfo.OnTimeout(this.oArg);
		}

		// Token: 0x0400640A RID: 25610
		public QueryQQFriendsVipInfoArg oArg = new QueryQQFriendsVipInfoArg();

		// Token: 0x0400640B RID: 25611
		public QueryQQFriendsVipInfoRes oRes = null;
	}
}
