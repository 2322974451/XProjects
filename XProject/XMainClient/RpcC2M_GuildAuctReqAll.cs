using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildAuctReqAll : Rpc
	{

		public override uint GetRpcType()
		{
			return 41964U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildAuctReqArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildAuctReqRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildAuctReqAll.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildAuctReqAll.OnTimeout(this.oArg);
		}

		public GuildAuctReqArg oArg = new GuildAuctReqArg();

		public GuildAuctReqRes oRes = null;
	}
}
