using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_OpenSceneChest : Rpc
	{

		public override uint GetRpcType()
		{
			return 27401U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OpenSceneChestArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<OpenSceneChestRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_OpenSceneChest.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_OpenSceneChest.OnTimeout(this.oArg);
		}

		public OpenSceneChestArg oArg = new OpenSceneChestArg();

		public OpenSceneChestRes oRes = new OpenSceneChestRes();
	}
}
