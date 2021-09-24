using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ClickNewNotice : Rpc
	{

		public override uint GetRpcType()
		{
			return 50366U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ClickNewNoticeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ClickNewNoticeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ClickNewNotice.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ClickNewNotice.OnTimeout(this.oArg);
		}

		public ClickNewNoticeArg oArg = new ClickNewNoticeArg();

		public ClickNewNoticeRes oRes = null;
	}
}
