using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ChangeGuildCard : Rpc
	{

		public override uint GetRpcType()
		{
			return 55997U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeGuildCardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeGuildCardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeGuildCard.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeGuildCard.OnTimeout(this.oArg);
		}

		public ChangeGuildCardArg oArg = new ChangeGuildCardArg();

		public ChangeGuildCardRes oRes = new ChangeGuildCardRes();
	}
}
