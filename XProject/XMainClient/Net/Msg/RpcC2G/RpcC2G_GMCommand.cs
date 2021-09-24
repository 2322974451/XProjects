using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GMCommand : Rpc
	{

		public override uint GetRpcType()
		{
			return 3248U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GMCmdArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GMCmdRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GMCommand.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GMCommand.OnTimeout(this.oArg);
		}

		public GMCmdArg oArg = new GMCmdArg();

		public GMCmdRes oRes = new GMCmdRes();
	}
}
