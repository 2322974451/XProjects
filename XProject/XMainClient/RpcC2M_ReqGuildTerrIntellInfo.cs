using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014AE RID: 5294
	internal class RpcC2M_ReqGuildTerrIntellInfo : Rpc
	{
		// Token: 0x0600E7C3 RID: 59331 RVA: 0x003407E4 File Offset: 0x0033E9E4
		public override uint GetRpcType()
		{
			return 43276U;
		}

		// Token: 0x0600E7C4 RID: 59332 RVA: 0x003407FB File Offset: 0x0033E9FB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildTerrIntellInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E7C5 RID: 59333 RVA: 0x0034080B File Offset: 0x0033EA0B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildTerrIntellInfoRes>(stream);
		}

		// Token: 0x0600E7C6 RID: 59334 RVA: 0x0034081A File Offset: 0x0033EA1A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildTerrIntellInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E7C7 RID: 59335 RVA: 0x00340836 File Offset: 0x0033EA36
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildTerrIntellInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040064BE RID: 25790
		public ReqGuildTerrIntellInfoArg oArg = new ReqGuildTerrIntellInfoArg();

		// Token: 0x040064BF RID: 25791
		public ReqGuildTerrIntellInfoRes oRes = null;
	}
}
