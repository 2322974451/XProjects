using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_AskForCheckInBonus : Rpc
	{

		public override uint GetRpcType()
		{
			return 32843U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AskForCheckInBonusArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AskForCheckInBonusRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_AskForCheckInBonus.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_AskForCheckInBonus.OnTimeout(this.oArg);
		}

		public AskForCheckInBonusArg oArg = new AskForCheckInBonusArg();

		public AskForCheckInBonusRes oRes = new AskForCheckInBonusRes();
	}
}
