using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_TaskOperate : Rpc
	{

		public override uint GetRpcType()
		{
			return 20029U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TaskOPArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TaskOPRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TaskOperate.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TaskOperate.OnTimeout(this.oArg);
		}

		public TaskOPArg oArg = new TaskOPArg();

		public TaskOPRes oRes = null;
	}
}
