using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_TeamRequestC2M : Rpc
	{

		public override uint GetRpcType()
		{
			return 30954U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamOPArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TeamOPRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_TeamRequestC2M.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_TeamRequestC2M.OnTimeout(this.oArg);
		}

		public TeamOPArg oArg = new TeamOPArg();

		public TeamOPRes oRes;
	}
}
