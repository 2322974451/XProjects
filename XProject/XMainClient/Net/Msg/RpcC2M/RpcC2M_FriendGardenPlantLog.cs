using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_FriendGardenPlantLog : Rpc
	{

		public override uint GetRpcType()
		{
			return 33646U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FriendGardenPlantLogArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FriendGardenPlantLogRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FriendGardenPlantLog.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FriendGardenPlantLog.OnTimeout(this.oArg);
		}

		public FriendGardenPlantLogArg oArg = new FriendGardenPlantLogArg();

		public FriendGardenPlantLogRes oRes = null;
	}
}
