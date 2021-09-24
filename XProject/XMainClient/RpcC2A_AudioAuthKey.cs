using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2A_AudioAuthKey : Rpc
	{

		public override uint GetRpcType()
		{
			return 19391U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AudioAuthKeyArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AudioAuthKeyRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2A_AudioAuthKey.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2A_AudioAuthKey.OnTimeout(this.oArg);
		}

		public AudioAuthKeyArg oArg = new AudioAuthKeyArg();

		public AudioAuthKeyRes oRes = null;
	}
}
