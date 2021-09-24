using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GuildPartySummonSpirit : Rpc
	{

		public override uint GetRpcType()
		{
			return 42269U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildPartySummonSpiritArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildPartySummonSpiritRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GuildPartySummonSpirit.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GuildPartySummonSpirit.OnTimeout(this.oArg);
		}

		public GuildPartySummonSpiritArg oArg = new GuildPartySummonSpiritArg();

		public GuildPartySummonSpiritRes oRes = null;
	}
}
