using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GuildCampExchangeOperate : Rpc
	{

		public override uint GetRpcType()
		{
			return 31811U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCampExchangeOperateArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildCampExchangeOperateRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GuildCampExchangeOperate.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GuildCampExchangeOperate.OnTimeout(this.oArg);
		}

		public GuildCampExchangeOperateArg oArg = new GuildCampExchangeOperateArg();

		public GuildCampExchangeOperateRes oRes = null;
	}
}
