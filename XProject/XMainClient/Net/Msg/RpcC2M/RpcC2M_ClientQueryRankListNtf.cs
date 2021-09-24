using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ClientQueryRankListNtf : Rpc
	{

		public override uint GetRpcType()
		{
			return 39913U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ClientQueryRankListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ClientQueryRankListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ClientQueryRankListNtf.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ClientQueryRankListNtf.OnTimeout(this.oArg);
		}

		public ClientQueryRankListArg oArg = new ClientQueryRankListArg();

		public ClientQueryRankListRes oRes;
	}
}
