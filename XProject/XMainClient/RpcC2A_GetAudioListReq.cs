using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2A_GetAudioListReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 49666U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetAudioListReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetAudioListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2A_GetAudioListReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2A_GetAudioListReq.OnTimeout(this.oArg);
		}

		public GetAudioListReq oArg = new GetAudioListReq();

		public GetAudioListRes oRes = new GetAudioListRes();
	}
}
