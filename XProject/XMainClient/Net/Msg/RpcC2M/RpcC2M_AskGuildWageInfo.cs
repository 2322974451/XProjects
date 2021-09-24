using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AskGuildWageInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 17779U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AskGuildWageInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AskGuildWageInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskGuildWageInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskGuildWageInfo.OnTimeout(this.oArg);
		}

		public AskGuildWageInfoArg oArg = new AskGuildWageInfoArg();

		public AskGuildWageInfoRes oRes = null;
	}
}
