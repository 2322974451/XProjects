using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ThanksForBonus : Rpc
	{

		public override uint GetRpcType()
		{
			return 42614U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ThanksForBonusArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ThanksForBonusRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ThanksForBonus.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ThanksForBonus.OnTimeout(this.oArg);
		}

		public ThanksForBonusArg oArg = new ThanksForBonusArg();

		public ThanksForBonusRes oRes = new ThanksForBonusRes();
	}
}
