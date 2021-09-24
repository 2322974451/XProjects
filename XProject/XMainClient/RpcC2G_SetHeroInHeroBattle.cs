using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SetHeroInHeroBattle : Rpc
	{

		public override uint GetRpcType()
		{
			return 18341U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SetHeroInHeroBattleArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SetHeroInHeroBattleRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SetHeroInHeroBattle.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SetHeroInHeroBattle.OnTimeout(this.oArg);
		}

		public SetHeroInHeroBattleArg oArg = new SetHeroInHeroBattleArg();

		public SetHeroInHeroBattleRes oRes = null;
	}
}
