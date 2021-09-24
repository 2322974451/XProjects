using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_FetchGuildHistoryNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 26284U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildHistoryArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildHistoryRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchGuildHistoryNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchGuildHistoryNew.OnTimeout(this.oArg);
		}

		public GuildHistoryArg oArg = new GuildHistoryArg();

		public GuildHistoryRes oRes = null;
	}
}
