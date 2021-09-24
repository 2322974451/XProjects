using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AllianceGuildTerr : Rpc
	{

		public override uint GetRpcType()
		{
			return 10041U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AllianceGuildTerrArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AllianceGuildTerrRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AllianceGuildTerr.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AllianceGuildTerr.OnTimeout(this.oArg);
		}

		public AllianceGuildTerrArg oArg = new AllianceGuildTerrArg();

		public AllianceGuildTerrRes oRes = null;
	}
}
