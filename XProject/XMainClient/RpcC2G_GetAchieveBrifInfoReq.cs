using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010F5 RID: 4341
	internal class RpcC2G_GetAchieveBrifInfoReq : Rpc
	{
		// Token: 0x0600D88E RID: 55438 RVA: 0x00329BE0 File Offset: 0x00327DE0
		public override uint GetRpcType()
		{
			return 25095U;
		}

		// Token: 0x0600D88F RID: 55439 RVA: 0x00329BF7 File Offset: 0x00327DF7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetAchieveBrifInfoReq>(stream, this.oArg);
		}

		// Token: 0x0600D890 RID: 55440 RVA: 0x00329C07 File Offset: 0x00327E07
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetAchieveBrifInfoRes>(stream);
		}

		// Token: 0x0600D891 RID: 55441 RVA: 0x00329C16 File Offset: 0x00327E16
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetAchieveBrifInfoReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D892 RID: 55442 RVA: 0x00329C32 File Offset: 0x00327E32
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetAchieveBrifInfoReq.OnTimeout(this.oArg);
		}

		// Token: 0x040061D9 RID: 25049
		public GetAchieveBrifInfoReq oArg = new GetAchieveBrifInfoReq();

		// Token: 0x040061DA RID: 25050
		public GetAchieveBrifInfoRes oRes = new GetAchieveBrifInfoRes();
	}
}
