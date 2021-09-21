using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001108 RID: 4360
	internal class RpcC2G_GetAchievePointRewardReq : Rpc
	{
		// Token: 0x0600D8DE RID: 55518 RVA: 0x0032A280 File Offset: 0x00328480
		public override uint GetRpcType()
		{
			return 13722U;
		}

		// Token: 0x0600D8DF RID: 55519 RVA: 0x0032A297 File Offset: 0x00328497
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetAchievePointRewardReq>(stream, this.oArg);
		}

		// Token: 0x0600D8E0 RID: 55520 RVA: 0x0032A2A7 File Offset: 0x003284A7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetAchievePointRewardRes>(stream);
		}

		// Token: 0x0600D8E1 RID: 55521 RVA: 0x0032A2B6 File Offset: 0x003284B6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetAchievePointRewardReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D8E2 RID: 55522 RVA: 0x0032A2D2 File Offset: 0x003284D2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetAchievePointRewardReq.OnTimeout(this.oArg);
		}

		// Token: 0x040061E8 RID: 25064
		public GetAchievePointRewardReq oArg = new GetAchievePointRewardReq();

		// Token: 0x040061E9 RID: 25065
		public GetAchievePointRewardRes oRes = new GetAchievePointRewardRes();
	}
}
