using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildZiCaiDonateHistory : Rpc
	{

		public override uint GetRpcType()
		{
			return 22824U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildZiCaiDonateHistory_C2M>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildZiCaiDonateHistory_M2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildZiCaiDonateHistory.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildZiCaiDonateHistory.OnTimeout(this.oArg);
		}

		public GuildZiCaiDonateHistory_C2M oArg = new GuildZiCaiDonateHistory_C2M();

		public GuildZiCaiDonateHistory_M2C oRes = null;
	}
}
