using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_WorldBossGuildAddAttr : Rpc
	{

		public override uint GetRpcType()
		{
			return 9805U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldBossGuildAddAttrArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<WorldBossGuildAddAttrRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_WorldBossGuildAddAttr.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_WorldBossGuildAddAttr.OnTimeout(this.oArg);
		}

		public WorldBossGuildAddAttrArg oArg = new WorldBossGuildAddAttrArg();

		public WorldBossGuildAddAttrRes oRes = null;
	}
}
