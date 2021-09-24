using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2A_UpLoadAudioReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 3069U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpLoadAudioReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<UpLoadAudioRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2A_UpLoadAudioReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2A_UpLoadAudioReq.OnTimeout(this.oArg);
		}

		public UpLoadAudioReq oArg = new UpLoadAudioReq();

		public UpLoadAudioRes oRes = new UpLoadAudioRes();
	}
}
