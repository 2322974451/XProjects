using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetGuildPartyReceiveInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 58154U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildPartyReceiveInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildPartyReceiveInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildPartyReceiveInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildPartyReceiveInfo.OnTimeout(this.oArg);
		}

		public GetGuildPartyReceiveInfoArg oArg = new GetGuildPartyReceiveInfoArg();

		public GetGuildPartyReceiveInfoRes oRes = null;
	}
}
