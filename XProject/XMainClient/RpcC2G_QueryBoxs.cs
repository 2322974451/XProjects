using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001654 RID: 5716
	internal class RpcC2G_QueryBoxs : Rpc
	{
		// Token: 0x0600EE9C RID: 61084 RVA: 0x0034A080 File Offset: 0x00348280
		public override uint GetRpcType()
		{
			return 12558U;
		}

		// Token: 0x0600EE9D RID: 61085 RVA: 0x0034A097 File Offset: 0x00348297
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryBoxsArg>(stream, this.oArg);
		}

		// Token: 0x0600EE9E RID: 61086 RVA: 0x0034A0A7 File Offset: 0x003482A7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryBoxsRes>(stream);
		}

		// Token: 0x0600EE9F RID: 61087 RVA: 0x0034A0B6 File Offset: 0x003482B6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryBoxs.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EEA0 RID: 61088 RVA: 0x0034A0D2 File Offset: 0x003482D2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryBoxs.OnTimeout(this.oArg);
		}

		// Token: 0x0400661D RID: 26141
		public QueryBoxsArg oArg = new QueryBoxsArg();

		// Token: 0x0400661E RID: 26142
		public QueryBoxsRes oRes = null;
	}
}
