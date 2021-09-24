using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildCheckinNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 5584U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCheckinArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildCheckinRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildCheckinNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildCheckinNew.OnTimeout(this.oArg);
		}

		public GuildCheckinArg oArg = new GuildCheckinArg();

		public GuildCheckinRes oRes = null;
	}
}
