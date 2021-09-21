using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014F0 RID: 5360
	internal class RpcC2G_GuildCampPartyReqExchange : Rpc
	{
		// Token: 0x0600E8D4 RID: 59604 RVA: 0x00341CAC File Offset: 0x0033FEAC
		public override uint GetRpcType()
		{
			return 51021U;
		}

		// Token: 0x0600E8D5 RID: 59605 RVA: 0x00341CC3 File Offset: 0x0033FEC3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCampPartyReqExchangeReq>(stream, this.oArg);
		}

		// Token: 0x0600E8D6 RID: 59606 RVA: 0x00341CD3 File Offset: 0x0033FED3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildCampPartyReqExchangeRes>(stream);
		}

		// Token: 0x0600E8D7 RID: 59607 RVA: 0x00341CE2 File Offset: 0x0033FEE2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GuildCampPartyReqExchange.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E8D8 RID: 59608 RVA: 0x00341CFE File Offset: 0x0033FEFE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GuildCampPartyReqExchange.OnTimeout(this.oArg);
		}

		// Token: 0x040064F3 RID: 25843
		public GuildCampPartyReqExchangeReq oArg = new GuildCampPartyReqExchangeReq();

		// Token: 0x040064F4 RID: 25844
		public GuildCampPartyReqExchangeRes oRes = null;
	}
}
