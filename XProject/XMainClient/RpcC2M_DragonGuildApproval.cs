using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_DragonGuildApproval : Rpc
	{

		public override uint GetRpcType()
		{
			return 4753U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildApprovalArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGuildApprovalRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DragonGuildApproval.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DragonGuildApproval.OnTimeout(this.oArg);
		}

		public DragonGuildApprovalArg oArg = new DragonGuildApprovalArg();

		public DragonGuildApprovalRes oRes = null;
	}
}
