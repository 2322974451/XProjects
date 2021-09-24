using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BuySpriteEgg : Rpc
	{

		public override uint GetRpcType()
		{
			return 34552U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuySpriteEggArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuySpriteEggRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuySpriteEgg.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuySpriteEgg.OnTimeout(this.oArg);
		}

		public BuySpriteEggArg oArg = new BuySpriteEggArg();

		public BuySpriteEggRes oRes = null;
	}
}
