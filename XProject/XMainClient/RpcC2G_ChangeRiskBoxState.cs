using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200125E RID: 4702
	internal class RpcC2G_ChangeRiskBoxState : Rpc
	{
		// Token: 0x0600DE4F RID: 56911 RVA: 0x00333110 File Offset: 0x00331310
		public override uint GetRpcType()
		{
			return 4472U;
		}

		// Token: 0x0600DE50 RID: 56912 RVA: 0x00333127 File Offset: 0x00331327
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeRiskBoxStateArg>(stream, this.oArg);
		}

		// Token: 0x0600DE51 RID: 56913 RVA: 0x00333137 File Offset: 0x00331337
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeRiskBoxStateRes>(stream);
		}

		// Token: 0x0600DE52 RID: 56914 RVA: 0x00333146 File Offset: 0x00331346
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeRiskBoxState.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DE53 RID: 56915 RVA: 0x00333162 File Offset: 0x00331362
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeRiskBoxState.OnTimeout(this.oArg);
		}

		// Token: 0x040062F0 RID: 25328
		public ChangeRiskBoxStateArg oArg = new ChangeRiskBoxStateArg();

		// Token: 0x040062F1 RID: 25329
		public ChangeRiskBoxStateRes oRes = new ChangeRiskBoxStateRes();
	}
}
