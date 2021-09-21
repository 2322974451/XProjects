using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001340 RID: 4928
	internal class RpcC2M_ReqPlatFriendRankList : Rpc
	{
		// Token: 0x0600E1F3 RID: 57843 RVA: 0x00338568 File Offset: 0x00336768
		public override uint GetRpcType()
		{
			return 43806U;
		}

		// Token: 0x0600E1F4 RID: 57844 RVA: 0x0033857F File Offset: 0x0033677F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqPlatFriendRankListArg>(stream, this.oArg);
		}

		// Token: 0x0600E1F5 RID: 57845 RVA: 0x0033858F File Offset: 0x0033678F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqPlatFriendRankListRes>(stream);
		}

		// Token: 0x0600E1F6 RID: 57846 RVA: 0x0033859E File Offset: 0x0033679E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqPlatFriendRankList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E1F7 RID: 57847 RVA: 0x003385BA File Offset: 0x003367BA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqPlatFriendRankList.OnTimeout(this.oArg);
		}

		// Token: 0x040063A5 RID: 25509
		public ReqPlatFriendRankListArg oArg = new ReqPlatFriendRankListArg();

		// Token: 0x040063A6 RID: 25510
		public ReqPlatFriendRankListRes oRes = null;
	}
}
