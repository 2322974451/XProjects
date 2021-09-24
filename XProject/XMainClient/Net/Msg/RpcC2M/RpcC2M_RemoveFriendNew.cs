using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_RemoveFriendNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 2841U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RemoveFriendArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RemoveFriendRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_RemoveFriendNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_RemoveFriendNew.OnTimeout(this.oArg);
		}

		public RemoveFriendArg oArg = new RemoveFriendArg();

		public RemoveFriendRes oRes = null;
	}
}
