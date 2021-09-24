using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_TryDance : Rpc
	{

		public override uint GetRpcType()
		{
			return 54323U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TryDanceArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TryDanceRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_TryDance.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_TryDance.OnTimeout(this.oArg);
		}

		public TryDanceArg oArg = new TryDanceArg();

		public TryDanceRes oRes = null;
	}
}
