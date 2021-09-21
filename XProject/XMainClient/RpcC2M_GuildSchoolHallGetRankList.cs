using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001690 RID: 5776
	internal class RpcC2M_GuildSchoolHallGetRankList : Rpc
	{
		// Token: 0x0600EF95 RID: 61333 RVA: 0x0034B890 File Offset: 0x00349A90
		public override uint GetRpcType()
		{
			return 34511U;
		}

		// Token: 0x0600EF96 RID: 61334 RVA: 0x0034B8A7 File Offset: 0x00349AA7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildSchoolHallGetRankList_C2M>(stream, this.oArg);
		}

		// Token: 0x0600EF97 RID: 61335 RVA: 0x0034B8B7 File Offset: 0x00349AB7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildSchoolHallGetRankList_M2C>(stream);
		}

		// Token: 0x0600EF98 RID: 61336 RVA: 0x0034B8C6 File Offset: 0x00349AC6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildSchoolHallGetRankList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EF99 RID: 61337 RVA: 0x0034B8E2 File Offset: 0x00349AE2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildSchoolHallGetRankList.OnTimeout(this.oArg);
		}

		// Token: 0x04006655 RID: 26197
		public GuildSchoolHallGetRankList_C2M oArg = new GuildSchoolHallGetRankList_C2M();

		// Token: 0x04006656 RID: 26198
		public GuildSchoolHallGetRankList_M2C oRes = null;
	}
}
