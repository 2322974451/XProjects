using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetRiskMapInfos : Rpc
	{

		public override uint GetRpcType()
		{
			return 11628U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetRiskMapInfosArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetRiskMapInfosRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetRiskMapInfos.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetRiskMapInfos.OnTimeout(this.oArg);
		}

		public GetRiskMapInfosArg oArg = new GetRiskMapInfosArg();

		public GetRiskMapInfosRes oRes = new GetRiskMapInfosRes();
	}
}
