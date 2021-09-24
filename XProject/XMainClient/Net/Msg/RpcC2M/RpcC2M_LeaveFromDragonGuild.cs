using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_LeaveFromDragonGuild : Rpc
	{

		public override uint GetRpcType()
		{
			return 9882U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeaveDragonGuildArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeaveDragonGuildRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_LeaveFromDragonGuild.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_LeaveFromDragonGuild.OnTimeout(this.oArg);
		}

		public LeaveDragonGuildArg oArg = new LeaveDragonGuildArg();

		public LeaveDragonGuildRes oRes = null;
	}
}
