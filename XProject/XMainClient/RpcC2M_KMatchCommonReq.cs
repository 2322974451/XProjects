using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_KMatchCommonReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 57822U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<KMatchCommonArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<KMatchCommonRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_KMatchCommonReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_KMatchCommonReq.OnTimeout(this.oArg);
		}

		public KMatchCommonArg oArg = new KMatchCommonArg();

		public KMatchCommonRes oRes = null;
	}
}
