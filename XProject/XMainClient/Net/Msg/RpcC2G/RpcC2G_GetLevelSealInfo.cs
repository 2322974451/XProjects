using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetLevelSealInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 10497U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLevelSealInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLevelSealInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetLevelSealInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetLevelSealInfo.OnTimeout(this.oArg);
		}

		public GetLevelSealInfoArg oArg = new GetLevelSealInfoArg();

		public GetLevelSealInfoRes oRes = new GetLevelSealInfoRes();
	}
}
