using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SelectChargeBackRole : Rpc
	{

		public override uint GetRpcType()
		{
			return 38792U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SelectChargeBackRoleArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SelectChargeBackRoleRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SelectChargeBackRole.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SelectChargeBackRole.OnTimeout(this.oArg);
		}

		public SelectChargeBackRoleArg oArg = new SelectChargeBackRoleArg();

		public SelectChargeBackRoleRes oRes = null;
	}
}
