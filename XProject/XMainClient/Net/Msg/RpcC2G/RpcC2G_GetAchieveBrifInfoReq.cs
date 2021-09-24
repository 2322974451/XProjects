using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetAchieveBrifInfoReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 25095U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetAchieveBrifInfoReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetAchieveBrifInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetAchieveBrifInfoReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetAchieveBrifInfoReq.OnTimeout(this.oArg);
		}

		public GetAchieveBrifInfoReq oArg = new GetAchieveBrifInfoReq();

		public GetAchieveBrifInfoRes oRes = new GetAchieveBrifInfoRes();
	}
}
