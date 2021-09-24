using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BuyGoldAndFatigue : Rpc
	{

		public override uint GetRpcType()
		{
			return 31095U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyGoldAndFatigueArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyGoldAndFatigueRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyGoldAndFatigue.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyGoldAndFatigue.OnTimeout(this.oArg);
		}

		public BuyGoldAndFatigueArg oArg = new BuyGoldAndFatigueArg();

		public BuyGoldAndFatigueRes oRes = new BuyGoldAndFatigueRes();
	}
}
