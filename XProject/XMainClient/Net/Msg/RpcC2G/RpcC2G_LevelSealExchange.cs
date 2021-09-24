using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_LevelSealExchange : Rpc
	{

		public override uint GetRpcType()
		{
			return 65467U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LevelSealExchangeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LevelSealExchangeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_LevelSealExchange.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_LevelSealExchange.OnTimeout(this.oArg);
		}

		public LevelSealExchangeArg oArg = new LevelSealExchangeArg();

		public LevelSealExchangeRes oRes = new LevelSealExchangeRes();
	}
}
