using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000A15 RID: 2581
	internal class RpcC2G_GetAncientTimesAward : Rpc
	{
		// Token: 0x06009E10 RID: 40464 RVA: 0x0019DE30 File Offset: 0x0019C030
		public override uint GetRpcType()
		{
			return 40517U;
		}

		// Token: 0x06009E11 RID: 40465 RVA: 0x0019DE47 File Offset: 0x0019C047
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AncientTimesArg>(stream, this.oArg);
		}

		// Token: 0x06009E12 RID: 40466 RVA: 0x0019DE57 File Offset: 0x0019C057
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AncientTimesRes>(stream);
		}

		// Token: 0x06009E13 RID: 40467 RVA: 0x0019DE66 File Offset: 0x0019C066
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetAncientTimesAward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x06009E14 RID: 40468 RVA: 0x0019DE82 File Offset: 0x0019C082
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetAncientTimesAward.OnTimeout(this.oArg);
		}

		// Token: 0x040037FF RID: 14335
		public AncientTimesArg oArg = new AncientTimesArg();

		// Token: 0x04003800 RID: 14336
		public AncientTimesRes oRes = null;
	}
}
