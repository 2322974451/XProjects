using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ChangeOutLookOp : Rpc
	{

		public override uint GetRpcType()
		{
			return 56978U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeOutLookOpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeOutLookOpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeOutLookOp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeOutLookOp.OnTimeout(this.oArg);
		}

		public ChangeOutLookOpArg oArg = new ChangeOutLookOpArg();

		public ChangeOutLookOpRes oRes = new ChangeOutLookOpRes();
	}
}
