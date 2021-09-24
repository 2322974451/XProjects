using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SmeltItem : Rpc
	{

		public override uint GetRpcType()
		{
			return 10028U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SmeltItemArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SmeltItemRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SmeltItem.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SmeltItem.OnTimeout(this.oArg);
		}

		public SmeltItemArg oArg = new SmeltItemArg();

		public SmeltItemRes oRes = new SmeltItemRes();
	}
}
