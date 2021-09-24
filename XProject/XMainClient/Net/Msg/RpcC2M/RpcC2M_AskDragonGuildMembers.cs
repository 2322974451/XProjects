using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AskDragonGuildMembers : Rpc
	{

		public override uint GetRpcType()
		{
			return 26644U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildMemberArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGuildMemberRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskDragonGuildMembers.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskDragonGuildMembers.OnTimeout(this.oArg);
		}

		public DragonGuildMemberArg oArg = new DragonGuildMemberArg();

		public DragonGuildMemberRes oRes = null;
	}
}
