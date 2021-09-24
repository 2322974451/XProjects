using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetGuildBonusLeft : Rpc
	{

		public override uint GetRpcType()
		{
			return 9967U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildBonusLeftArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildBonusLeftRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildBonusLeft.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildBonusLeft.OnTimeout(this.oArg);
		}

		public GetGuildBonusLeftArg oArg = new GetGuildBonusLeftArg();

		public GetGuildBonusLeftRes oRes = null;
	}
}
