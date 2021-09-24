using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_EmblemLevelUp : Rpc
	{

		public override uint GetRpcType()
		{
			return 9893U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EmblemLevelUpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EmblemLevelUpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EmblemLevelUp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EmblemLevelUp.OnTimeout(this.oArg);
		}

		public EmblemLevelUpArg oArg = new EmblemLevelUpArg();

		public EmblemLevelUpRes oRes = new EmblemLevelUpRes();
	}
}
