using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetDailyTaskAskHelp : Rpc
	{

		public override uint GetRpcType()
		{
			return 46394U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDailyTaskAskHelpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDailyTaskAskHelpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDailyTaskAskHelp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDailyTaskAskHelp.OnTimeout(this.oArg);
		}

		public GetDailyTaskAskHelpArg oArg = new GetDailyTaskAskHelpArg();

		public GetDailyTaskAskHelpRes oRes = null;
	}
}
