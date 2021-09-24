using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_DelGuildInherit : Rpc
	{

		public override uint GetRpcType()
		{
			return 3671U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DelGuildInheritArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DelGuildInheritRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DelGuildInherit.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DelGuildInherit.OnTimeout(this.oArg);
		}

		public DelGuildInheritArg oArg = new DelGuildInheritArg();

		public DelGuildInheritRes oRes = null;
	}
}
