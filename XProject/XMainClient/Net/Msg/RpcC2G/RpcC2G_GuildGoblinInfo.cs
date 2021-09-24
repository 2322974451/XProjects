using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GuildGoblinInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 59865U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildGoblinInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildGoblinInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GuildGoblinInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GuildGoblinInfo.OnTimeout(this.oArg);
		}

		public GuildGoblinInfoArg oArg = new GuildGoblinInfoArg();

		public GuildGoblinInfoRes oRes = new GuildGoblinInfoRes();
	}
}
