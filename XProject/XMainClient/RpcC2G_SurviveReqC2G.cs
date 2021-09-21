using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200161D RID: 5661
	internal class RpcC2G_SurviveReqC2G : Rpc
	{
		// Token: 0x0600EDAC RID: 60844 RVA: 0x00348B3C File Offset: 0x00346D3C
		public override uint GetRpcType()
		{
			return 19408U;
		}

		// Token: 0x0600EDAD RID: 60845 RVA: 0x00348B53 File Offset: 0x00346D53
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SurviveReqArg>(stream, this.oArg);
		}

		// Token: 0x0600EDAE RID: 60846 RVA: 0x00348B63 File Offset: 0x00346D63
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SurviveReqRes>(stream);
		}

		// Token: 0x0600EDAF RID: 60847 RVA: 0x00348B72 File Offset: 0x00346D72
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SurviveReqC2G.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EDB0 RID: 60848 RVA: 0x00348B8E File Offset: 0x00346D8E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SurviveReqC2G.OnTimeout(this.oArg);
		}

		// Token: 0x040065EA RID: 26090
		public SurviveReqArg oArg = new SurviveReqArg();

		// Token: 0x040065EB RID: 26091
		public SurviveReqRes oRes = null;
	}
}
