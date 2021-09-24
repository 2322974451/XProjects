using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetGuildIntegralInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 56762U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildIntegralInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildIntegralInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetGuildIntegralInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetGuildIntegralInfo.OnTimeout(this.oArg);
		}

		public GetGuildIntegralInfoArg oArg = new GetGuildIntegralInfoArg();

		public GetGuildIntegralInfoRes oRes = null;
	}
}
