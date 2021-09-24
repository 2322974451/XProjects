using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_FetchAchivementReward : Rpc
	{

		public override uint GetRpcType()
		{
			return 47094U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchAchiveArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchAchiveRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FetchAchivementReward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FetchAchivementReward.OnTimeout(this.oArg);
		}

		public FetchAchiveArg oArg = new FetchAchiveArg();

		public FetchAchiveRes oRes = new FetchAchiveRes();
	}
}
