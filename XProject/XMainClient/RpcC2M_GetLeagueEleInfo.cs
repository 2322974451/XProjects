using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetLeagueEleInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 40678U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLeagueEleInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLeagueEleInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetLeagueEleInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetLeagueEleInfo.OnTimeout(this.oArg);
		}

		public GetLeagueEleInfoArg oArg = new GetLeagueEleInfoArg();

		public GetLeagueEleInfoRes oRes = null;
	}
}
