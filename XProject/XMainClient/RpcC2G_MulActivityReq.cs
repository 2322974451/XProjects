using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_MulActivityReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 22806U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MulActivityArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<MulActivityRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_MulActivityReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_MulActivityReq.OnTimeout(this.oArg);
		}

		public MulActivityArg oArg = new MulActivityArg();

		public MulActivityRes oRes = new MulActivityRes();
	}
}
