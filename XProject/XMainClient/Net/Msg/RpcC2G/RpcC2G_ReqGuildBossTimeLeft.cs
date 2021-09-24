using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ReqGuildBossTimeLeft : Rpc
	{

		public override uint GetRpcType()
		{
			return 24494U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<getguildbosstimeleftArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<getguildbosstimeleftRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReqGuildBossTimeLeft.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReqGuildBossTimeLeft.OnTimeout(this.oArg);
		}

		public getguildbosstimeleftArg oArg = new getguildbosstimeleftArg();

		public getguildbosstimeleftRes oRes = new getguildbosstimeleftRes();
	}
}
