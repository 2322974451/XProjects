using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_SendGift2PlatFriend : Rpc
	{

		public override uint GetRpcType()
		{
			return 57764U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SendGift2PlatFriendArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SendGift2PlatFriendRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_SendGift2PlatFriend.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_SendGift2PlatFriend.OnTimeout(this.oArg);
		}

		public SendGift2PlatFriendArg oArg = new SendGift2PlatFriendArg();

		public SendGift2PlatFriendRes oRes = null;
	}
}
