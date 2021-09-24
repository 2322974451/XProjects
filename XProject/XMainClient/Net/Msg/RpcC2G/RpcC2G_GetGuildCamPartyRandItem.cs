using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetGuildCamPartyRandItem : Rpc
	{

		public override uint GetRpcType()
		{
			return 53025U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildCamPartyRandItemArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildCamPartyRandItemRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildCamPartyRandItem.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildCamPartyRandItem.OnTimeout(this.oArg);
		}

		public GetGuildCamPartyRandItemArg oArg = new GetGuildCamPartyRandItemArg();

		public GetGuildCamPartyRandItemRes oRes = null;
	}
}
