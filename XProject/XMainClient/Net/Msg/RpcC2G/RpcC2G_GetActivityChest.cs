using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetActivityChest : Rpc
	{

		public override uint GetRpcType()
		{
			return 34363U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetActivityChestArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetActivityChestRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetActivityChest.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetActivityChest.OnTimeout(this.oArg);
		}

		public GetActivityChestArg oArg = new GetActivityChestArg();

		public GetActivityChestRes oRes = new GetActivityChestRes();
	}
}
