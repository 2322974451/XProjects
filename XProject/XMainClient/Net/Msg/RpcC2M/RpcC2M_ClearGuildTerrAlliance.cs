using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ClearGuildTerrAlliance : Rpc
	{

		public override uint GetRpcType()
		{
			return 38312U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ClearGuildTerrAllianceArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ClearGuildTerrAllianceRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ClearGuildTerrAlliance.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ClearGuildTerrAlliance.OnTimeout(this.oArg);
		}

		public ClearGuildTerrAllianceArg oArg = new ClearGuildTerrAllianceArg();

		public ClearGuildTerrAllianceRes oRes = null;
	}
}
