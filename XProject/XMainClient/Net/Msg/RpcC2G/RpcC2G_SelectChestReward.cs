using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SelectChestReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 40987U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SelectChestArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SelectChestRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SelectChestReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SelectChestReward.OnTimeout(this.oArg);
		}

		public SelectChestArg oArg = new SelectChestArg();

		public SelectChestRes oRes = null;
	}
}
