using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_Sweep : Rpc
	{

		public override uint GetRpcType()
		{
			return 6019U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SweepArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SweepRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_Sweep.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_Sweep.OnTimeout(this.oArg);
		}

		public SweepArg oArg = new SweepArg();

		public SweepRes oRes = new SweepRes();
	}
}
