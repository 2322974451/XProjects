using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SetDesignationReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 7673U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SetDesignationReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SetDesignationRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SetDesignationReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SetDesignationReq.OnTimeout(this.oArg);
		}

		public SetDesignationReq oArg = new SetDesignationReq();

		public SetDesignationRes oRes = new SetDesignationRes();
	}
}
