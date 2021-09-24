using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_RandomFriendWaitListNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 65353U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RandomFriendWaitListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RandomFriendWaitListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_RandomFriendWaitListNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_RandomFriendWaitListNew.OnTimeout(this.oArg);
		}

		public RandomFriendWaitListArg oArg = new RandomFriendWaitListArg();

		public RandomFriendWaitListRes oRes = null;
	}
}
