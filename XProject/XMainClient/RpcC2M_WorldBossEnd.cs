using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_WorldBossEnd : Rpc
	{

		public override uint GetRpcType()
		{
			return 53655U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldBossEndArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<WorldBossEndRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_WorldBossEnd.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_WorldBossEnd.OnTimeout(this.oArg);
		}

		public WorldBossEndArg oArg = new WorldBossEndArg();

		public WorldBossEndRes oRes = null;
	}
}
