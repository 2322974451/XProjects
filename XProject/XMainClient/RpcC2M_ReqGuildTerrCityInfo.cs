using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200140E RID: 5134
	internal class RpcC2M_ReqGuildTerrCityInfo : Rpc
	{
		// Token: 0x0600E53D RID: 58685 RVA: 0x0033CAC0 File Offset: 0x0033ACC0
		public override uint GetRpcType()
		{
			return 47229U;
		}

		// Token: 0x0600E53E RID: 58686 RVA: 0x0033CAD7 File Offset: 0x0033ACD7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildTerrCityInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E53F RID: 58687 RVA: 0x0033CAE7 File Offset: 0x0033ACE7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildTerrCityInfo>(stream);
		}

		// Token: 0x0600E540 RID: 58688 RVA: 0x0033CAF6 File Offset: 0x0033ACF6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildTerrCityInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E541 RID: 58689 RVA: 0x0033CB12 File Offset: 0x0033AD12
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildTerrCityInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006447 RID: 25671
		public ReqGuildTerrCityInfoArg oArg = new ReqGuildTerrCityInfoArg();

		// Token: 0x04006448 RID: 25672
		public ReqGuildTerrCityInfo oRes = null;
	}
}
