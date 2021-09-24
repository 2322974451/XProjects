using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetGuildBonusDetailInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 20027U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildBonusDetailInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildBonusDetailInfoResult>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildBonusDetailInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildBonusDetailInfo.OnTimeout(this.oArg);
		}

		public GetGuildBonusDetailInfoArg oArg = new GetGuildBonusDetailInfoArg();

		public GetGuildBonusDetailInfoResult oRes = new GetGuildBonusDetailInfoResult();
	}
}
