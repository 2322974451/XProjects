using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AddFriendNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 5634U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AddFriendArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AddFriendRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AddFriendNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AddFriendNew.OnTimeout(this.oArg);
		}

		public AddFriendArg oArg = new AddFriendArg();

		public AddFriendRes oRes = null;
	}
}
