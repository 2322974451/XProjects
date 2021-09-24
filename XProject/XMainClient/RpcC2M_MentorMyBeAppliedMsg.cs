using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_MentorMyBeAppliedMsg : Rpc
	{

		public override uint GetRpcType()
		{
			return 45205U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MentorMyBeAppliedMsgArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<MentorMyBeAppliedMsgRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_MentorMyBeAppliedMsg.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_MentorMyBeAppliedMsg.OnTimeout(this.oArg);
		}

		public MentorMyBeAppliedMsgArg oArg = new MentorMyBeAppliedMsgArg();

		public MentorMyBeAppliedMsgRes oRes = null;
	}
}
