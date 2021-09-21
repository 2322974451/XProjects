using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012BE RID: 4798
	internal class RpcC2M_GetOtherGuildBriefNew : Rpc
	{
		// Token: 0x0600DFD9 RID: 57305 RVA: 0x00335328 File Offset: 0x00333528
		public override uint GetRpcType()
		{
			return 16797U;
		}

		// Token: 0x0600DFDA RID: 57306 RVA: 0x0033533F File Offset: 0x0033353F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetOtherGuildBriefArg>(stream, this.oArg);
		}

		// Token: 0x0600DFDB RID: 57307 RVA: 0x0033534F File Offset: 0x0033354F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetOtherGuildBriefRes>(stream);
		}

		// Token: 0x0600DFDC RID: 57308 RVA: 0x0033535E File Offset: 0x0033355E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetOtherGuildBriefNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DFDD RID: 57309 RVA: 0x0033537A File Offset: 0x0033357A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetOtherGuildBriefNew.OnTimeout(this.oArg);
		}

		// Token: 0x0400633C RID: 25404
		public GetOtherGuildBriefArg oArg = new GetOtherGuildBriefArg();

		// Token: 0x0400633D RID: 25405
		public GetOtherGuildBriefRes oRes = null;
	}
}
