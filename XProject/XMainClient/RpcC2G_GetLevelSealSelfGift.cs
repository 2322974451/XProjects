using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200132D RID: 4909
	internal class RpcC2G_GetLevelSealSelfGift : Rpc
	{
		// Token: 0x0600E1A1 RID: 57761 RVA: 0x00337D9C File Offset: 0x00335F9C
		public override uint GetRpcType()
		{
			return 61903U;
		}

		// Token: 0x0600E1A2 RID: 57762 RVA: 0x00337DB3 File Offset: 0x00335FB3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLevelSealSealGiftArg>(stream, this.oArg);
		}

		// Token: 0x0600E1A3 RID: 57763 RVA: 0x00337DC3 File Offset: 0x00335FC3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLevelSealSelfGiftRes>(stream);
		}

		// Token: 0x0600E1A4 RID: 57764 RVA: 0x00337DD2 File Offset: 0x00335FD2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetLevelSealSelfGift.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E1A5 RID: 57765 RVA: 0x00337DEE File Offset: 0x00335FEE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetLevelSealSelfGift.OnTimeout(this.oArg);
		}

		// Token: 0x04006394 RID: 25492
		public GetLevelSealSealGiftArg oArg = new GetLevelSealSealGiftArg();

		// Token: 0x04006395 RID: 25493
		public GetLevelSealSelfGiftRes oRes = new GetLevelSealSelfGiftRes();
	}
}
