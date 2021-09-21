using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011C0 RID: 4544
	internal class RpcC2G_QueryPowerPoint : Rpc
	{
		// Token: 0x0600DBC5 RID: 56261 RVA: 0x0032F77C File Offset: 0x0032D97C
		public override uint GetRpcType()
		{
			return 44381U;
		}

		// Token: 0x0600DBC6 RID: 56262 RVA: 0x0032F793 File Offset: 0x0032D993
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryPowerPointArg>(stream, this.oArg);
		}

		// Token: 0x0600DBC7 RID: 56263 RVA: 0x0032F7A3 File Offset: 0x0032D9A3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryPowerPointRes>(stream);
		}

		// Token: 0x0600DBC8 RID: 56264 RVA: 0x0032F7B2 File Offset: 0x0032D9B2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryPowerPoint.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DBC9 RID: 56265 RVA: 0x0032F7CE File Offset: 0x0032D9CE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryPowerPoint.OnTimeout(this.oArg);
		}

		// Token: 0x04006272 RID: 25202
		public QueryPowerPointArg oArg = new QueryPowerPointArg();

		// Token: 0x04006273 RID: 25203
		public QueryPowerPointRes oRes = new QueryPowerPointRes();
	}
}
