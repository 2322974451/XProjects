using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_Checkin : Rpc
	{

		public override uint GetRpcType()
		{
			return 56127U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CheckinArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CheckinRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_Checkin.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_Checkin.OnTimeout(this.oArg);
		}

		public CheckinArg oArg = new CheckinArg();

		public CheckinRes oRes = new CheckinRes();
	}
}
