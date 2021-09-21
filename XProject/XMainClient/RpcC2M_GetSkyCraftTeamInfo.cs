using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014E7 RID: 5351
	internal class RpcC2M_GetSkyCraftTeamInfo : Rpc
	{
		// Token: 0x0600E8AB RID: 59563 RVA: 0x003418D8 File Offset: 0x0033FAD8
		public override uint GetRpcType()
		{
			return 25015U;
		}

		// Token: 0x0600E8AC RID: 59564 RVA: 0x003418EF File Offset: 0x0033FAEF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSkyCraftTeamInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E8AD RID: 59565 RVA: 0x003418FF File Offset: 0x0033FAFF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSkyCraftTeamInfoRes>(stream);
		}

		// Token: 0x0600E8AE RID: 59566 RVA: 0x0034190E File Offset: 0x0033FB0E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetSkyCraftTeamInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E8AF RID: 59567 RVA: 0x0034192A File Offset: 0x0033FB2A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetSkyCraftTeamInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040064EA RID: 25834
		public GetSkyCraftTeamInfoArg oArg = new GetSkyCraftTeamInfoArg();

		// Token: 0x040064EB RID: 25835
		public GetSkyCraftTeamInfoRes oRes = null;
	}
}
