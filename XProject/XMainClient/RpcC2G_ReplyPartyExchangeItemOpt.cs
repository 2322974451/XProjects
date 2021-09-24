using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ReplyPartyExchangeItemOpt : Rpc
	{

		public override uint GetRpcType()
		{
			return 13740U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReplyPartyExchangeItemOptArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReplyPartyExchangeItemOptRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReplyPartyExchangeItemOpt.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReplyPartyExchangeItemOpt.OnTimeout(this.oArg);
		}

		public ReplyPartyExchangeItemOptArg oArg = new ReplyPartyExchangeItemOptArg();

		public ReplyPartyExchangeItemOptRes oRes = null;
	}
}
