using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2N_SelectRoleNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 217U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SelectRoleNewArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SelectRoleNewRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2N_SelectRoleNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2N_SelectRoleNew.OnTimeout(this.oArg);
		}

		public SelectRoleNewArg oArg = new SelectRoleNewArg();

		public SelectRoleNewRes oRes = new SelectRoleNewRes();
	}
}
