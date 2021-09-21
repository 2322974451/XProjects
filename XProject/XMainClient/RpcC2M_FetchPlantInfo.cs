using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012D8 RID: 4824
	internal class RpcC2M_FetchPlantInfo : Rpc
	{
		// Token: 0x0600E042 RID: 57410 RVA: 0x00335BE4 File Offset: 0x00333DE4
		public override uint GetRpcType()
		{
			return 19949U;
		}

		// Token: 0x0600E043 RID: 57411 RVA: 0x00335BFB File Offset: 0x00333DFB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchPlantInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E044 RID: 57412 RVA: 0x00335C0B File Offset: 0x00333E0B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchPlantInfoRes>(stream);
		}

		// Token: 0x0600E045 RID: 57413 RVA: 0x00335C1A File Offset: 0x00333E1A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchPlantInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E046 RID: 57414 RVA: 0x00335C36 File Offset: 0x00333E36
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchPlantInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006350 RID: 25424
		public FetchPlantInfoArg oArg = new FetchPlantInfoArg();

		// Token: 0x04006351 RID: 25425
		public FetchPlantInfoRes oRes = null;
	}
}
