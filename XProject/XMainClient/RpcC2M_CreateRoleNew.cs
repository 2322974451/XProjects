using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_CreateRoleNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 13034U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CreateRoleNewArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CreateRoleNewRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CreateRoleNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CreateRoleNew.OnTimeout(this.oArg);
		}

		public CreateRoleNewArg oArg = new CreateRoleNewArg();

		public CreateRoleNewRes oRes = null;
	}
}
