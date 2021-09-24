using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ChangeWatchRole : Rpc
	{

		public override uint GetRpcType()
		{
			return 35369U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeWatchRoleArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeWatchRoleRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeWatchRole.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeWatchRole.OnTimeout(this.oArg);
		}

		public ChangeWatchRoleArg oArg = new ChangeWatchRoleArg();

		public ChangeWatchRoleRes oRes = new ChangeWatchRoleRes();
	}
}
