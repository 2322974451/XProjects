using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_TryAlliance : Rpc
	{

		public override uint GetRpcType()
		{
			return 20216U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TryAllianceArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TryAlliance>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_TryAlliance.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_TryAlliance.OnTimeout(this.oArg);
		}

		public TryAllianceArg oArg = new TryAllianceArg();

		public TryAlliance oRes = null;
	}
}
