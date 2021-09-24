using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_gmfjoinreq : Rpc
	{

		public override uint GetRpcType()
		{
			return 37651U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<gmfjoinarg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<gmfjoinres>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_gmfjoinreq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_gmfjoinreq.OnTimeout(this.oArg);
		}

		public gmfjoinarg oArg = new gmfjoinarg();

		public gmfjoinres oRes = null;
	}
}
