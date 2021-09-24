using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_DoAddFriendNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 23397U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DoAddFriendArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DoAddFriendRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DoAddFriendNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DoAddFriendNew.OnTimeout(this.oArg);
		}

		public DoAddFriendArg oArg = new DoAddFriendArg();

		public DoAddFriendRes oRes = null;
	}
}
