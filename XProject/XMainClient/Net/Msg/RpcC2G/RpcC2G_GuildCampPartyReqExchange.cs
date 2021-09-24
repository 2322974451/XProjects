using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GuildCampPartyReqExchange : Rpc
	{

		public override uint GetRpcType()
		{
			return 51021U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCampPartyReqExchangeReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildCampPartyReqExchangeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GuildCampPartyReqExchange.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GuildCampPartyReqExchange.OnTimeout(this.oArg);
		}

		public GuildCampPartyReqExchangeReq oArg = new GuildCampPartyReqExchangeReq();

		public GuildCampPartyReqExchangeRes oRes = null;
	}
}
