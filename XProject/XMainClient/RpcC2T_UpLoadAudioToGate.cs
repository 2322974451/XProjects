using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2T_UpLoadAudioToGate : Rpc
	{

		public override uint GetRpcType()
		{
			return 23176U;
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
			Process_RpcC2T_UpLoadAudioToGate.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2T_UpLoadAudioToGate.OnTimeout(this.oArg);
		}

		public UpLoadAudioReq oArg = new UpLoadAudioReq();

		public UpLoadAudioRes oRes = null;
	}
}
