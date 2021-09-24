using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SetRoleConfig : Rpc
	{

		public override uint GetRpcType()
		{
			return 35306U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SetRoleConfigReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SetRoleConfigRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SetRoleConfig.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SetRoleConfig.OnTimeout(this.oArg);
		}

		public SetRoleConfigReq oArg = new SetRoleConfigReq();

		public SetRoleConfigRes oRes = new SetRoleConfigRes();
	}
}
