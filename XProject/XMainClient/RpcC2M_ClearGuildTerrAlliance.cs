using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001435 RID: 5173
	internal class RpcC2M_ClearGuildTerrAlliance : Rpc
	{
		// Token: 0x0600E5DD RID: 58845 RVA: 0x0033D8C4 File Offset: 0x0033BAC4
		public override uint GetRpcType()
		{
			return 38312U;
		}

		// Token: 0x0600E5DE RID: 58846 RVA: 0x0033D8DB File Offset: 0x0033BADB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ClearGuildTerrAllianceArg>(stream, this.oArg);
		}

		// Token: 0x0600E5DF RID: 58847 RVA: 0x0033D8EB File Offset: 0x0033BAEB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ClearGuildTerrAllianceRes>(stream);
		}

		// Token: 0x0600E5E0 RID: 58848 RVA: 0x0033D8FA File Offset: 0x0033BAFA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ClearGuildTerrAlliance.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E5E1 RID: 58849 RVA: 0x0033D916 File Offset: 0x0033BB16
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ClearGuildTerrAlliance.OnTimeout(this.oArg);
		}

		// Token: 0x04006465 RID: 25701
		public ClearGuildTerrAllianceArg oArg = new ClearGuildTerrAllianceArg();

		// Token: 0x04006466 RID: 25702
		public ClearGuildTerrAllianceRes oRes = null;
	}
}
