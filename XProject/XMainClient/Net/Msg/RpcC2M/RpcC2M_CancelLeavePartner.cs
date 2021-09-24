using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_CancelLeavePartner : Rpc
	{

		public override uint GetRpcType()
		{
			return 27794U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CancelLeavePartnerArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CancelLeavePartnerRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CancelLeavePartner.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CancelLeavePartner.OnTimeout(this.oArg);
		}

		public CancelLeavePartnerArg oArg = new CancelLeavePartnerArg();

		public CancelLeavePartnerRes oRes = null;
	}
}
