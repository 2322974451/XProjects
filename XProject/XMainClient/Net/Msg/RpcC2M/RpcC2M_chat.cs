using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_chat : Rpc
	{

		public override uint GetRpcType()
		{
			return 56705U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChatArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChatRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_chat.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_chat.OnTimeout(this.oArg);
		}

		public ChatArg oArg = new ChatArg();

		public ChatRes oRes = null;
	}
}
