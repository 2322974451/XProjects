using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_TitleLevelUp : Rpc
	{

		public override uint GetRpcType()
		{
			return 24381U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TitleLevelUpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TitleLevelUpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TitleLevelUp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TitleLevelUp.OnTimeout(this.oArg);
		}

		public TitleLevelUpArg oArg = new TitleLevelUpArg();

		public TitleLevelUpRes oRes = new TitleLevelUpRes();
	}
}
