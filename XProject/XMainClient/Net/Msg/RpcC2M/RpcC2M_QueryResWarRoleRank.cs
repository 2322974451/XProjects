using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_QueryResWarRoleRank : Rpc
	{

		public override uint GetRpcType()
		{
			return 27001U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarRoleRankArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResWarRoleRankRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_QueryResWarRoleRank.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_QueryResWarRoleRank.OnTimeout(this.oArg);
		}

		public ResWarRoleRankArg oArg = new ResWarRoleRankArg();

		public ResWarRoleRankRes oRes = null;
	}
}
