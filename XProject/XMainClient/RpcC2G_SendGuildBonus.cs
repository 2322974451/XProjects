using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SendGuildBonus : Rpc
	{

		public override uint GetRpcType()
		{
			return 61243U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SendGuildBonusArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SendGuildBonusRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SendGuildBonus.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SendGuildBonus.OnTimeout(this.oArg);
		}

		public SendGuildBonusArg oArg = new SendGuildBonusArg();

		public SendGuildBonusRes oRes = new SendGuildBonusRes();
	}
}
