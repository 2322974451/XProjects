using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetGuildCampPartyExchangeInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 44443U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildCampPartyExchangeInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildCampPartyExchangeInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildCampPartyExchangeInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildCampPartyExchangeInfo.OnTimeout(this.oArg);
		}

		public GetGuildCampPartyExchangeInfoArg oArg = new GetGuildCampPartyExchangeInfoArg();

		public GetGuildCampPartyExchangeInfoRes oRes = null;
	}
}
