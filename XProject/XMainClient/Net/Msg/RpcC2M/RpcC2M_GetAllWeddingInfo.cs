using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetAllWeddingInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 30155U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetAllWeddingInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetAllWeddingInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetAllWeddingInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetAllWeddingInfo.OnTimeout(this.oArg);
		}

		public GetAllWeddingInfoArg oArg = new GetAllWeddingInfoArg();

		public GetAllWeddingInfoRes oRes = null;
	}
}
