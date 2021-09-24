using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BuyTeamSceneCount : Rpc
	{

		public override uint GetRpcType()
		{
			return 9226U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyTeamSceneCountP>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyTeamSceneCountRet>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyTeamSceneCount.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyTeamSceneCount.OnTimeout(this.oArg);
		}

		public BuyTeamSceneCountP oArg = new BuyTeamSceneCountP();

		public BuyTeamSceneCountRet oRes = new BuyTeamSceneCountRet();
	}
}
