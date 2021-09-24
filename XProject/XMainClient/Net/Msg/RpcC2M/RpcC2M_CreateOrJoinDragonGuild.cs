using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_CreateOrJoinDragonGuild : Rpc
	{

		public override uint GetRpcType()
		{
			return 8623U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CreateOrJoinDragonGuildArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CreateOrJoinDragonGuildRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CreateOrJoinDragonGuild.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CreateOrJoinDragonGuild.OnTimeout(this.oArg);
		}

		public CreateOrJoinDragonGuildArg oArg = new CreateOrJoinDragonGuildArg();

		public CreateOrJoinDragonGuildRes oRes = null;
	}
}
