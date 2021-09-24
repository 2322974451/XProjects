using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_DailyTaskAskHelp : Rpc
	{

		public override uint GetRpcType()
		{
			return 9236U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DailyTaskAskHelpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DailyTaskAskHelpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DailyTaskAskHelp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DailyTaskAskHelp.OnTimeout(this.oArg);
		}

		public DailyTaskAskHelpArg oArg = new DailyTaskAskHelpArg();

		public DailyTaskAskHelpRes oRes = new DailyTaskAskHelpRes();
	}
}
