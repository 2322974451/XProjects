using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BossRushReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 44074U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BossRushArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BossRushRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BossRushReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BossRushReq.OnTimeout(this.oArg);
		}

		public BossRushArg oArg = new BossRushArg();

		public BossRushRes oRes = new BossRushRes();
	}
}
