using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GuildCheckInBonusInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 47251U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCheckInBonusInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildCheckInBonusInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GuildCheckInBonusInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GuildCheckInBonusInfo.OnTimeout(this.oArg);
		}

		public GuildCheckInBonusInfoArg oArg = new GuildCheckInBonusInfoArg();

		public GuildCheckInBonusInfoRes oRes = new GuildCheckInBonusInfoRes();
	}
}
