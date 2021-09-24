using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AskGuildMembers : Rpc
	{

		public override uint GetRpcType()
		{
			return 57958U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildMemberArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildMemberRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskGuildMembers.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskGuildMembers.OnTimeout(this.oArg);
		}

		public GuildMemberArg oArg = new GuildMemberArg();

		public GuildMemberRes oRes = null;
	}
}
