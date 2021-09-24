using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_UseSupplement : Rpc
	{

		public override uint GetRpcType()
		{
			return 20068U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UseSupplementReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<UseSupplementRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_UseSupplement.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_UseSupplement.OnTimeout(this.oArg);
		}

		public UseSupplementReq oArg = new UseSupplementReq();

		public UseSupplementRes oRes = new UseSupplementRes();
	}
}
