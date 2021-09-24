using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SkyCityAllInfoReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 29365U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SkyCityRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SkyCityAllInfoReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SkyCityAllInfoReq.OnTimeout(this.oArg);
		}

		public SkyCityArg oArg = new SkyCityArg();

		public SkyCityRes oRes = new SkyCityRes();
	}
}
