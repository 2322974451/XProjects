using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetMarriagePrivilege : Rpc
	{

		public override uint GetRpcType()
		{
			return 15597U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMarriagePrivilegeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMarriagePrivilegeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMarriagePrivilege.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMarriagePrivilege.OnTimeout(this.oArg);
		}

		public GetMarriagePrivilegeArg oArg = new GetMarriagePrivilegeArg();

		public GetMarriagePrivilegeRes oRes = null;
	}
}
