using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_FriendGiftOpNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 35639U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FriendGiftOpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FriendGiftOpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FriendGiftOpNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FriendGiftOpNew.OnTimeout(this.oArg);
		}

		public FriendGiftOpArg oArg = new FriendGiftOpArg();

		public FriendGiftOpRes oRes = null;
	}
}
