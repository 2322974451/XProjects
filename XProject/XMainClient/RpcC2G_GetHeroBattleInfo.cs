using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetHeroBattleInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 65206U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetHeroBattleInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetHeroBattleInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetHeroBattleInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetHeroBattleInfo.OnTimeout(this.oArg);
		}

		public GetHeroBattleInfoArg oArg = new GetHeroBattleInfoArg();

		public GetHeroBattleInfoRes oRes = null;
	}
}
