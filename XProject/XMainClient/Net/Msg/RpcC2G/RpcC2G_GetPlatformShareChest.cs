using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetPlatformShareChest : Rpc
	{

		public override uint GetRpcType()
		{
			return 7875U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPlatformShareChestArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPlatformShareChestRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetPlatformShareChest.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetPlatformShareChest.OnTimeout(this.oArg);
		}

		public GetPlatformShareChestArg oArg = new GetPlatformShareChestArg();

		public GetPlatformShareChestRes oRes = null;
	}
}
