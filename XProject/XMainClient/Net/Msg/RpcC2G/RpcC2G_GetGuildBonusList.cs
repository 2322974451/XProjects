using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetGuildBonusList : Rpc
	{

		public override uint GetRpcType()
		{
			return 43440U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildBonusListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildBonusListResult>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildBonusList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildBonusList.OnTimeout(this.oArg);
		}

		public GetGuildBonusListArg oArg = new GetGuildBonusListArg();

		public GetGuildBonusListResult oRes = new GetGuildBonusListResult();
	}
}
