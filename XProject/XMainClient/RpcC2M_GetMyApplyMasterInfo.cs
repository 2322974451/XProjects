using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013D4 RID: 5076
	internal class RpcC2M_GetMyApplyMasterInfo : Rpc
	{
		// Token: 0x0600E44B RID: 58443 RVA: 0x0033B840 File Offset: 0x00339A40
		public override uint GetRpcType()
		{
			return 61902U;
		}

		// Token: 0x0600E44C RID: 58444 RVA: 0x0033B857 File Offset: 0x00339A57
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMyApplyMasterInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E44D RID: 58445 RVA: 0x0033B867 File Offset: 0x00339A67
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMyApplyMasterInfoRes>(stream);
		}

		// Token: 0x0600E44E RID: 58446 RVA: 0x0033B876 File Offset: 0x00339A76
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMyApplyMasterInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E44F RID: 58447 RVA: 0x0033B892 File Offset: 0x00339A92
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMyApplyMasterInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006417 RID: 25623
		public GetMyApplyMasterInfoArg oArg = new GetMyApplyMasterInfoArg();

		// Token: 0x04006418 RID: 25624
		public GetMyApplyMasterInfoRes oRes = null;
	}
}
