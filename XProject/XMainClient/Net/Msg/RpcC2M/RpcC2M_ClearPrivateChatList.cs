using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ClearPrivateChatList : Rpc
	{

		public override uint GetRpcType()
		{
			return 27304U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ClearPrivateChatListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ClearPrivateChatListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ClearPrivateChatList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ClearPrivateChatList.OnTimeout(this.oArg);
		}

		public ClearPrivateChatListArg oArg = new ClearPrivateChatListArg();

		public ClearPrivateChatListRes oRes = null;
	}
}
