using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetMobaBattleInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 64051U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMobaBattleInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMobaBattleInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMobaBattleInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMobaBattleInfo.OnTimeout(this.oArg);
		}

		public GetMobaBattleInfoArg oArg = new GetMobaBattleInfoArg();

		public GetMobaBattleInfoRes oRes = null;
	}
}
