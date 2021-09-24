using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_VsPayReviveReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 54530U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<VsPayRevivePara>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<VsPayReviveRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_VsPayReviveReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_VsPayReviveReq.OnTimeout(this.oArg);
		}

		public VsPayRevivePara oArg = new VsPayRevivePara();

		public VsPayReviveRes oRes = null;
	}
}
