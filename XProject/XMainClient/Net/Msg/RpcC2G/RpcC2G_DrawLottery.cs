using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_DrawLottery : Rpc
	{

		public override uint GetRpcType()
		{
			return 27802U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DrawLotteryArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DrawLotteryRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DrawLottery.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DrawLottery.OnTimeout(this.oArg);
		}

		public DrawLotteryArg oArg = new DrawLotteryArg();

		public DrawLotteryRes oRes = new DrawLotteryRes();
	}
}
