using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200160F RID: 5647
	internal class RpcC2M_NpcFlReqC2M : Rpc
	{
		// Token: 0x0600ED71 RID: 60785 RVA: 0x00348548 File Offset: 0x00346748
		public override uint GetRpcType()
		{
			return 11607U;
		}

		// Token: 0x0600ED72 RID: 60786 RVA: 0x0034855F File Offset: 0x0034675F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NpcFlArg>(stream, this.oArg);
		}

		// Token: 0x0600ED73 RID: 60787 RVA: 0x0034856F File Offset: 0x0034676F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<NpcFlRes>(stream);
		}

		// Token: 0x0600ED74 RID: 60788 RVA: 0x0034857E File Offset: 0x0034677E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_NpcFlReqC2M.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED75 RID: 60789 RVA: 0x0034859A File Offset: 0x0034679A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_NpcFlReqC2M.OnTimeout(this.oArg);
		}

		// Token: 0x040065DE RID: 26078
		public NpcFlArg oArg = new NpcFlArg();

		// Token: 0x040065DF RID: 26079
		public NpcFlRes oRes = null;
	}
}
