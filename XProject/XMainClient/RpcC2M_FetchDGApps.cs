using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_FetchDGApps : Rpc
	{

		public override uint GetRpcType()
		{
			return 48732U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchDGAppArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchDGAppRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchDGApps.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchDGApps.OnTimeout(this.oArg);
		}

		public FetchDGAppArg oArg = new FetchDGAppArg();

		public FetchDGAppRes oRes = null;
	}
}
