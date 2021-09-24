using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_DERankReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 16406U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DERankArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DERankRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DERankReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DERankReq.OnTimeout(this.oArg);
		}

		public DERankArg oArg = new DERankArg();

		public DERankRes oRes = null;
	}
}
