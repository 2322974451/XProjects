using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_FetchPlatNotice : Rpc
	{

		public override uint GetRpcType()
		{
			return 60271U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchPlatNoticeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchPlatNoticeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchPlatNotice.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchPlatNotice.OnTimeout(this.oArg);
		}

		public FetchPlatNoticeArg oArg = new FetchPlatNoticeArg();

		public FetchPlatNoticeRes oRes = null;
	}
}
