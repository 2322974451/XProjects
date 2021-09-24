using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildCampInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 4221U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCampInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildCampInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildCampInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildCampInfo.OnTimeout(this.oArg);
		}

		public GuildCampInfoArg oArg = new GuildCampInfoArg();

		public GuildCampInfoRes oRes = null;
	}
}
