using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PayFriendItem : Rpc
	{

		public override uint GetRpcType()
		{
			return 29289U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayFriendItemArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PayFriendItemRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PayFriendItem.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PayFriendItem.OnTimeout(this.oArg);
		}

		public PayFriendItemArg oArg = new PayFriendItemArg();

		public PayFriendItemRes oRes = null;
	}
}
