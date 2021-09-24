using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2A_AudioText : Rpc
	{

		public override uint GetRpcType()
		{
			return 42254U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AudioTextArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AudioTextRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2A_AudioText.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2A_AudioText.OnTimeout(this.oArg);
		}

		public AudioTextArg oArg = new AudioTextArg();

		public AudioTextRes oRes = null;
	}
}
