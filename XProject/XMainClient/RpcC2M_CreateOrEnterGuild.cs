using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_CreateOrEnterGuild : Rpc
	{

		public override uint GetRpcType()
		{
			return 13871U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CreateOrJoinGuild>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CreateOrJoinGuildRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CreateOrEnterGuild.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CreateOrEnterGuild.OnTimeout(this.oArg);
		}

		public CreateOrJoinGuild oArg = new CreateOrJoinGuild();

		public CreateOrJoinGuildRes oRes = null;
	}
}
