using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetJadeSealAllInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 2424U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetJadeSealAllInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetJadeSealAllInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetJadeSealAllInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetJadeSealAllInfo.OnTimeout(this.oArg);
		}

		public GetJadeSealAllInfoArg oArg = new GetJadeSealAllInfoArg();

		public GetJadeSealAllInfoRes oRes = null;
	}
}
