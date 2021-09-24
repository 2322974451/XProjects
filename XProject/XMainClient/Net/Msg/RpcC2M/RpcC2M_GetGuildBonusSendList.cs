using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetGuildBonusSendList : Rpc
	{

		public override uint GetRpcType()
		{
			return 59719U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildBonusSendListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildBonusSendListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetGuildBonusSendList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetGuildBonusSendList.OnTimeout(this.oArg);
		}

		public GetGuildBonusSendListArg oArg = new GetGuildBonusSendListArg();

		public GetGuildBonusSendListRes oRes = null;
	}
}
