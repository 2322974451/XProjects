using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BuyHeroInHeroBattle : Rpc
	{

		public override uint GetRpcType()
		{
			return 7735U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyHeroInHeroBattleArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyHeroInHeroBattleRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyHeroInHeroBattle.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyHeroInHeroBattle.OnTimeout(this.oArg);
		}

		public BuyHeroInHeroBattleArg oArg = new BuyHeroInHeroBattleArg();

		public BuyHeroInHeroBattleRes oRes = null;
	}
}
