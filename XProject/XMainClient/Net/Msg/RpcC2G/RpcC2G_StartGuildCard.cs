using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_StartGuildCard : Rpc
	{

		public override uint GetRpcType()
		{
			return 35743U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StartGuildCardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<StartGuildCardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_StartGuildCard.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_StartGuildCard.OnTimeout(this.oArg);
		}

		public StartGuildCardArg oArg = new StartGuildCardArg();

		public StartGuildCardRes oRes = new StartGuildCardRes();
	}
}
