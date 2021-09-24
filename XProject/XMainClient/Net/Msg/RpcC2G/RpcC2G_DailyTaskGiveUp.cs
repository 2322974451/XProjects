using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_DailyTaskGiveUp : Rpc
	{

		public override uint GetRpcType()
		{
			return 10546U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DailyTaskGiveUpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DailyTaskGiveUpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DailyTaskGiveUp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DailyTaskGiveUp.OnTimeout(this.oArg);
		}

		public DailyTaskGiveUpArg oArg = new DailyTaskGiveUpArg();

		public DailyTaskGiveUpRes oRes = new DailyTaskGiveUpRes();
	}
}
