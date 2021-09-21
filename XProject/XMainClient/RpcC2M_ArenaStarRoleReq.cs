using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014D1 RID: 5329
	internal class RpcC2M_ArenaStarRoleReq : Rpc
	{
		// Token: 0x0600E850 RID: 59472 RVA: 0x003412C8 File Offset: 0x0033F4C8
		public override uint GetRpcType()
		{
			return 53598U;
		}

		// Token: 0x0600E851 RID: 59473 RVA: 0x003412DF File Offset: 0x0033F4DF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ArenaStarReqArg>(stream, this.oArg);
		}

		// Token: 0x0600E852 RID: 59474 RVA: 0x003412EF File Offset: 0x0033F4EF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ArenaStarReqRes>(stream);
		}

		// Token: 0x0600E853 RID: 59475 RVA: 0x003412FE File Offset: 0x0033F4FE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ArenaStarRoleReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E854 RID: 59476 RVA: 0x0034131A File Offset: 0x0033F51A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ArenaStarRoleReq.OnTimeout(this.oArg);
		}

		// Token: 0x040064D8 RID: 25816
		public ArenaStarReqArg oArg = new ArenaStarReqArg();

		// Token: 0x040064D9 RID: 25817
		public ArenaStarReqRes oRes = null;
	}
}
