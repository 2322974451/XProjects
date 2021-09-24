using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildArenaSimpleDeployNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 42310U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildArenaSimpleDeployArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildArenaSimpleDeployRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildArenaSimpleDeployNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildArenaSimpleDeployNew.OnTimeout(this.oArg);
		}

		public GuildArenaSimpleDeployArg oArg = new GuildArenaSimpleDeployArg();

		public GuildArenaSimpleDeployRes oRes = null;
	}
}
