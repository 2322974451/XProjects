using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildFatigueOPNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 10226U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildFatigueArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildFatigueRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildFatigueOPNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildFatigueOPNew.OnTimeout(this.oArg);
		}

		public GuildFatigueArg oArg = new GuildFatigueArg();

		public GuildFatigueRes oRes = null;
	}
}
