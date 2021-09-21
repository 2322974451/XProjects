using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B3F RID: 2879
	internal class RpcC2M_GuildAuctReqAll : Rpc
	{
		// Token: 0x0600A863 RID: 43107 RVA: 0x001E091C File Offset: 0x001DEB1C
		public override uint GetRpcType()
		{
			return 41964U;
		}

		// Token: 0x0600A864 RID: 43108 RVA: 0x001E0933 File Offset: 0x001DEB33
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildAuctReqArg>(stream, this.oArg);
		}

		// Token: 0x0600A865 RID: 43109 RVA: 0x001E0943 File Offset: 0x001DEB43
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildAuctReqRes>(stream);
		}

		// Token: 0x0600A866 RID: 43110 RVA: 0x001E0952 File Offset: 0x001DEB52
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildAuctReqAll.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600A867 RID: 43111 RVA: 0x001E096E File Offset: 0x001DEB6E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildAuctReqAll.OnTimeout(this.oArg);
		}

		// Token: 0x04003E6C RID: 15980
		public GuildAuctReqArg oArg = new GuildAuctReqArg();

		// Token: 0x04003E6D RID: 15981
		public GuildAuctReqRes oRes = null;
	}
}
