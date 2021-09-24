using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetGuildDonateInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 14656U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildDonateInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildDonateInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetGuildDonateInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetGuildDonateInfo.OnTimeout(this.oArg);
		}

		public GetGuildDonateInfoArg oArg = new GetGuildDonateInfoArg();

		public GetGuildDonateInfoRes oRes = null;
	}
}
