using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PlayDiceRequest : Rpc
	{

		public override uint GetRpcType()
		{
			return 51246U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlayDiceRequestArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PlayDiceRequestRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PlayDiceRequest.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PlayDiceRequest.OnTimeout(this.oArg);
		}

		public PlayDiceRequestArg oArg = new PlayDiceRequestArg();

		public PlayDiceRequestRes oRes = new PlayDiceRequestRes();
	}
}
