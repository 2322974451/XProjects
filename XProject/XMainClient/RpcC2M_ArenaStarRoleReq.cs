using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ArenaStarRoleReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 53598U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ArenaStarReqArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ArenaStarReqRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ArenaStarRoleReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ArenaStarRoleReq.OnTimeout(this.oArg);
		}

		public ArenaStarReqArg oArg = new ArenaStarReqArg();

		public ArenaStarReqRes oRes = null;
	}
}
