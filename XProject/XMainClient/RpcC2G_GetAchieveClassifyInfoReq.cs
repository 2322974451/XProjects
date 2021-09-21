using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010F7 RID: 4343
	internal class RpcC2G_GetAchieveClassifyInfoReq : Rpc
	{
		// Token: 0x0600D897 RID: 55447 RVA: 0x00329CB8 File Offset: 0x00327EB8
		public override uint GetRpcType()
		{
			return 14056U;
		}

		// Token: 0x0600D898 RID: 55448 RVA: 0x00329CCF File Offset: 0x00327ECF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetAchieveClassifyInfoReq>(stream, this.oArg);
		}

		// Token: 0x0600D899 RID: 55449 RVA: 0x00329CDF File Offset: 0x00327EDF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetAchieveClassifyInfoRes>(stream);
		}

		// Token: 0x0600D89A RID: 55450 RVA: 0x00329CEE File Offset: 0x00327EEE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetAchieveClassifyInfoReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D89B RID: 55451 RVA: 0x00329D0A File Offset: 0x00327F0A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetAchieveClassifyInfoReq.OnTimeout(this.oArg);
		}

		// Token: 0x040061DB RID: 25051
		public GetAchieveClassifyInfoReq oArg = new GetAchieveClassifyInfoReq();

		// Token: 0x040061DC RID: 25052
		public GetAchieveClassifyInfoRes oRes = new GetAchieveClassifyInfoRes();
	}
}
