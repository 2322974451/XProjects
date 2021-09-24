using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_EndGuildCard : Rpc
	{

		public override uint GetRpcType()
		{
			return 13212U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EndGuildCardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EndGuildCardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EndGuildCard.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EndGuildCard.OnTimeout(this.oArg);
		}

		public EndGuildCardArg oArg = new EndGuildCardArg();

		public EndGuildCardRes oRes = new EndGuildCardRes();
	}
}
