using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AceptGuildInherit : Rpc
	{

		public override uint GetRpcType()
		{
			return 35235U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AceptGuildInheritArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AceptGuildInheritRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AceptGuildInherit.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AceptGuildInherit.OnTimeout(this.oArg);
		}

		public AceptGuildInheritArg oArg = new AceptGuildInheritArg();

		public AceptGuildInheritRes oRes = null;
	}
}
