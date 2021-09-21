using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200143B RID: 5179
	internal class RpcC2G_QueryClientIp : Rpc
	{
		// Token: 0x0600E5F4 RID: 58868 RVA: 0x0033DABC File Offset: 0x0033BCBC
		public override uint GetRpcType()
		{
			return 24918U;
		}

		// Token: 0x0600E5F5 RID: 58869 RVA: 0x0033DAD3 File Offset: 0x0033BCD3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryClientIpArg>(stream, this.oArg);
		}

		// Token: 0x0600E5F6 RID: 58870 RVA: 0x0033DAE3 File Offset: 0x0033BCE3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryClientIpRes>(stream);
		}

		// Token: 0x0600E5F7 RID: 58871 RVA: 0x0033DAF2 File Offset: 0x0033BCF2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryClientIp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E5F8 RID: 58872 RVA: 0x0033DB0E File Offset: 0x0033BD0E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryClientIp.OnTimeout(this.oArg);
		}

		// Token: 0x04006469 RID: 25705
		public QueryClientIpArg oArg = new QueryClientIpArg();

		// Token: 0x0400646A RID: 25706
		public QueryClientIpRes oRes = null;
	}
}
