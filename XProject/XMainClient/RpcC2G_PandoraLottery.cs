using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PandoraLottery : Rpc
	{

		public override uint GetRpcType()
		{
			return 12575U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PandoraLotteryArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PandoraLotteryRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PandoraLottery.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PandoraLottery.OnTimeout(this.oArg);
		}

		public PandoraLotteryArg oArg = new PandoraLotteryArg();

		public PandoraLotteryRes oRes = null;
	}
}
