using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_LotteryDraw : Rpc
	{

		public override uint GetRpcType()
		{
			return 47060U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LotteryDrawReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LotteryDrawRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_LotteryDraw.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_LotteryDraw.OnTimeout(this.oArg);
		}

		public LotteryDrawReq oArg = new LotteryDrawReq();

		public LotteryDrawRes oRes = null;
	}
}
