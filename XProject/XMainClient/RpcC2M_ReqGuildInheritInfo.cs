using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ReqGuildInheritInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 7131U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildInheritInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildInheritInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildInheritInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildInheritInfo.OnTimeout(this.oArg);
		}

		public ReqGuildInheritInfoArg oArg = new ReqGuildInheritInfoArg();

		public ReqGuildInheritInfoRes oRes = null;
	}
}
