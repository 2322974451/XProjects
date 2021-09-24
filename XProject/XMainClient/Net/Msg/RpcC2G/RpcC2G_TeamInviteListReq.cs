using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_TeamInviteListReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 11403U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamInviteArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TeamInviteRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TeamInviteListReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TeamInviteListReq.OnTimeout(this.oArg);
		}

		public TeamInviteArg oArg = new TeamInviteArg();

		public TeamInviteRes oRes = new TeamInviteRes();
	}
}
