using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_LeaveSkyTeam : Rpc
	{

		public override uint GetRpcType()
		{
			return 26181U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeaveSkyTeamArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeaveSkyTeamRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_LeaveSkyTeam.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_LeaveSkyTeam.OnTimeout(this.oArg);
		}

		public LeaveSkyTeamArg oArg = new LeaveSkyTeamArg();

		public LeaveSkyTeamRes oRes = null;
	}
}
