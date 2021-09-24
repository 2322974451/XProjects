using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildApprovalNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 28348U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildApprovalArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildApprovalRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildApprovalNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildApprovalNew.OnTimeout(this.oArg);
		}

		public GuildApprovalArg oArg = new GuildApprovalArg();

		public GuildApprovalRes oRes = null;
	}
}
