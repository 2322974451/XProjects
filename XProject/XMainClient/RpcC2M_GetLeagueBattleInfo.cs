using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetLeagueBattleInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 29101U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLeagueBattleInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLeagueBattleInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetLeagueBattleInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetLeagueBattleInfo.OnTimeout(this.oArg);
		}

		public GetLeagueBattleInfoArg oArg = new GetLeagueBattleInfoArg();

		public GetLeagueBattleInfoRes oRes = null;
	}
}
