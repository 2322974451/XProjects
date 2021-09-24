using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AddBlackListNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 265U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AddBlackListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AddBlackListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AddBlackListNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AddBlackListNew.OnTimeout(this.oArg);
		}

		public AddBlackListArg oArg = new AddBlackListArg();

		public AddBlackListRes oRes = null;
	}
}
