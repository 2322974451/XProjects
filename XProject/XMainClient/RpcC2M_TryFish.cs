using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_TryFish : Rpc
	{

		public override uint GetRpcType()
		{
			return 7028U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TryFishArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TryFishRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_TryFish.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_TryFish.OnTimeout(this.oArg);
		}

		public TryFishArg oArg = new TryFishArg();

		public TryFishRes oRes = null;
	}
}
