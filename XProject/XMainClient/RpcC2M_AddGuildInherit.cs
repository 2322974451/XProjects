using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AddGuildInherit : Rpc
	{

		public override uint GetRpcType()
		{
			return 15845U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AddGuildInheritArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AddGuildInheritRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AddGuildInherit.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AddGuildInherit.OnTimeout(this.oArg);
		}

		public AddGuildInheritArg oArg = new AddGuildInheritArg();

		public AddGuildInheritRes oRes = null;
	}
}
