using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_FetchTeamListC2M : Rpc
	{

		public override uint GetRpcType()
		{
			return 3930U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchTeamListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchTeamListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchTeamListC2M.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchTeamListC2M.OnTimeout(this.oArg);
		}

		public FetchTeamListArg oArg = new FetchTeamListArg();

		public FetchTeamListRes oRes = null;
	}
}
