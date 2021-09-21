using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001688 RID: 5768
	internal class RpcC2M_GetDanceIds : Rpc
	{
		// Token: 0x0600EF71 RID: 61297 RVA: 0x0034B528 File Offset: 0x00349728
		public override uint GetRpcType()
		{
			return 44768U;
		}

		// Token: 0x0600EF72 RID: 61298 RVA: 0x0034B53F File Offset: 0x0034973F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDanceIdsArg>(stream, this.oArg);
		}

		// Token: 0x0600EF73 RID: 61299 RVA: 0x0034B54F File Offset: 0x0034974F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDanceIdsRes>(stream);
		}

		// Token: 0x0600EF74 RID: 61300 RVA: 0x0034B55E File Offset: 0x0034975E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDanceIds.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EF75 RID: 61301 RVA: 0x0034B57A File Offset: 0x0034977A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDanceIds.OnTimeout(this.oArg);
		}

		// Token: 0x0400664D RID: 26189
		public GetDanceIdsArg oArg = new GetDanceIdsArg();

		// Token: 0x0400664E RID: 26190
		public GetDanceIdsRes oRes = null;
	}
}
