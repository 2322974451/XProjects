using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AskGuildArenaTeamInfoNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 2181U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AskGuildArenaTeamInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AskGuildArenaTeamInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskGuildArenaTeamInfoNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskGuildArenaTeamInfoNew.OnTimeout(this.oArg);
		}

		public AskGuildArenaTeamInfoArg oArg = new AskGuildArenaTeamInfoArg();

		public AskGuildArenaTeamInfoRes oRes = null;
	}
}
