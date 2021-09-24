using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_NpcFlReqC2M : Rpc
	{

		public override uint GetRpcType()
		{
			return 11607U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NpcFlArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<NpcFlRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_NpcFlReqC2M.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_NpcFlReqC2M.OnTimeout(this.oArg);
		}

		public NpcFlArg oArg = new NpcFlArg();

		public NpcFlRes oRes = null;
	}
}
