using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_LeaveFromGuild : Rpc
	{

		public override uint GetRpcType()
		{
			return 2565U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeaveGuildArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeaveGuildRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_LeaveFromGuild.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_LeaveFromGuild.OnTimeout(this.oArg);
		}

		public LeaveGuildArg oArg = new LeaveGuildArg();

		public LeaveGuildRes oRes = null;
	}
}
