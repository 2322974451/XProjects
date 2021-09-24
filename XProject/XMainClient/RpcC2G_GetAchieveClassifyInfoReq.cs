using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetAchieveClassifyInfoReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 14056U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetAchieveClassifyInfoReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetAchieveClassifyInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetAchieveClassifyInfoReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetAchieveClassifyInfoReq.OnTimeout(this.oArg);
		}

		public GetAchieveClassifyInfoReq oArg = new GetAchieveClassifyInfoReq();

		public GetAchieveClassifyInfoRes oRes = new GetAchieveClassifyInfoRes();
	}
}
