using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001412 RID: 5138
	internal class RpcC2M_ReqGuildTerrAllianceInfo : Rpc
	{
		// Token: 0x0600E54F RID: 58703 RVA: 0x0033CC38 File Offset: 0x0033AE38
		public override uint GetRpcType()
		{
			return 63044U;
		}

		// Token: 0x0600E550 RID: 58704 RVA: 0x0033CC4F File Offset: 0x0033AE4F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildTerrAllianceInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E551 RID: 58705 RVA: 0x0033CC5F File Offset: 0x0033AE5F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildTerrAllianceInfoRes>(stream);
		}

		// Token: 0x0600E552 RID: 58706 RVA: 0x0033CC6E File Offset: 0x0033AE6E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildTerrAllianceInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E553 RID: 58707 RVA: 0x0033CC8A File Offset: 0x0033AE8A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildTerrAllianceInfo.OnTimeout(this.oArg);
		}

		// Token: 0x0400644B RID: 25675
		public ReqGuildTerrAllianceInfoArg oArg = new ReqGuildTerrAllianceInfoArg();

		// Token: 0x0400644C RID: 25676
		public ReqGuildTerrAllianceInfoRes oRes = null;
	}
}
