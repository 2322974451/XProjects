using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010FB RID: 4347
	internal class RpcC2G_GetAchieveRewardReq : Rpc
	{
		// Token: 0x0600D8A9 RID: 55465 RVA: 0x00329E14 File Offset: 0x00328014
		public override uint GetRpcType()
		{
			return 1577U;
		}

		// Token: 0x0600D8AA RID: 55466 RVA: 0x00329E2B File Offset: 0x0032802B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetAchieveRewardReq>(stream, this.oArg);
		}

		// Token: 0x0600D8AB RID: 55467 RVA: 0x00329E3B File Offset: 0x0032803B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetAchieveRewardRes>(stream);
		}

		// Token: 0x0600D8AC RID: 55468 RVA: 0x00329E4A File Offset: 0x0032804A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetAchieveRewardReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D8AD RID: 55469 RVA: 0x00329E66 File Offset: 0x00328066
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetAchieveRewardReq.OnTimeout(this.oArg);
		}

		// Token: 0x040061DF RID: 25055
		public GetAchieveRewardReq oArg = new GetAchieveRewardReq();

		// Token: 0x040061E0 RID: 25056
		public GetAchieveRewardRes oRes = new GetAchieveRewardRes();
	}
}
