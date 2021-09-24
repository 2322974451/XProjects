using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ReqGuildBossInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 38917U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AskGuildBossInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AskGuildBossInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildBossInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildBossInfo.OnTimeout(this.oArg);
		}

		public AskGuildBossInfoArg oArg = new AskGuildBossInfoArg();

		public AskGuildBossInfoRes oRes = null;
	}
}
