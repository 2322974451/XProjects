using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PlayDiceOver : Rpc
	{

		public override uint GetRpcType()
		{
			return 15035U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlayDiceOverArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PlayDiceOverRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PlayDiceOver.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PlayDiceOver.OnTimeout(this.oArg);
		}

		public PlayDiceOverArg oArg = new PlayDiceOverArg();

		public PlayDiceOverRes oRes = new PlayDiceOverRes();
	}
}
