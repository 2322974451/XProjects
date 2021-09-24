using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ActivatePreShow : Rpc
	{

		public override uint GetRpcType()
		{
			return 22466U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ActivatePreShowArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ActivatePreShowRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ActivatePreShow.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ActivatePreShow.OnTimeout(this.oArg);
		}

		public ActivatePreShowArg oArg = new ActivatePreShowArg();

		public ActivatePreShowRes oRes = null;
	}
}
