using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetCompeteDragonInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 65362U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetCompeteDragonInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetCompeteDragonInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetCompeteDragonInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetCompeteDragonInfo.OnTimeout(this.oArg);
		}

		public GetCompeteDragonInfoArg oArg = new GetCompeteDragonInfoArg();

		public GetCompeteDragonInfoRes oRes = null;
	}
}
