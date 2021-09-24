using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildZiCaiDonate : Rpc
	{

		public override uint GetRpcType()
		{
			return 1738U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildZiCaiDonate_C2M>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildZiCaiDonate_M2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildZiCaiDonate.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildZiCaiDonate.OnTimeout(this.oArg);
		}

		public GuildZiCaiDonate_C2M oArg = new GuildZiCaiDonate_C2M();

		public GuildZiCaiDonate_M2C oRes = null;
	}
}
