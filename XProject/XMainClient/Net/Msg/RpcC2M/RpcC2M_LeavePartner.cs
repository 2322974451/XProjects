using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_LeavePartner : Rpc
	{

		public override uint GetRpcType()
		{
			return 63769U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeavePartnerArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LeavePartnerRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_LeavePartner.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_LeavePartner.OnTimeout(this.oArg);
		}

		public LeavePartnerArg oArg = new LeavePartnerArg();

		public LeavePartnerRes oRes = null;
	}
}
