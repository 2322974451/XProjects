using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012DA RID: 4826
	internal class RpcC2M_StartPlant : Rpc
	{
		// Token: 0x0600E04B RID: 57419 RVA: 0x00335CD4 File Offset: 0x00333ED4
		public override uint GetRpcType()
		{
			return 2834U;
		}

		// Token: 0x0600E04C RID: 57420 RVA: 0x00335CEB File Offset: 0x00333EEB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StartPlantArg>(stream, this.oArg);
		}

		// Token: 0x0600E04D RID: 57421 RVA: 0x00335CFB File Offset: 0x00333EFB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<StartPlantRes>(stream);
		}

		// Token: 0x0600E04E RID: 57422 RVA: 0x00335D0A File Offset: 0x00333F0A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_StartPlant.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E04F RID: 57423 RVA: 0x00335D26 File Offset: 0x00333F26
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_StartPlant.OnTimeout(this.oArg);
		}

		// Token: 0x04006352 RID: 25426
		public StartPlantArg oArg = new StartPlantArg();

		// Token: 0x04006353 RID: 25427
		public StartPlantRes oRes = null;
	}
}
