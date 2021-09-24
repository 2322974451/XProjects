using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AskGuildBriefInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 53355U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBriefArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildBriefRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskGuildBriefInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskGuildBriefInfo.OnTimeout(this.oArg);
		}

		public GuildBriefArg oArg = new GuildBriefArg();

		public GuildBriefRes oRes = null;
	}
}
