using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_RecAlliance : Rpc
	{

		public override uint GetRpcType()
		{
			return 31937U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RecAllianceArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RecAllianceRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_RecAlliance.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_RecAlliance.OnTimeout(this.oArg);
		}

		public RecAllianceArg oArg = new RecAllianceArg();

		public RecAllianceRes oRes = null;
	}
}
