using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildHallUpdateBuff : Rpc
	{

		public override uint GetRpcType()
		{
			return 24892U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildHallUpdateBuff_C2M>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildHallUpdateBuff_M2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildHallUpdateBuff.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildHallUpdateBuff.OnTimeout(this.oArg);
		}

		public GuildHallUpdateBuff_C2M oArg = new GuildHallUpdateBuff_C2M();

		public GuildHallUpdateBuff_M2C oRes = null;
	}
}
