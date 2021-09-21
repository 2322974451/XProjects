using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013D6 RID: 5078
	internal class RpcC2M_MentorMyBeAppliedMsg : Rpc
	{
		// Token: 0x0600E454 RID: 58452 RVA: 0x0033B94C File Offset: 0x00339B4C
		public override uint GetRpcType()
		{
			return 45205U;
		}

		// Token: 0x0600E455 RID: 58453 RVA: 0x0033B963 File Offset: 0x00339B63
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MentorMyBeAppliedMsgArg>(stream, this.oArg);
		}

		// Token: 0x0600E456 RID: 58454 RVA: 0x0033B973 File Offset: 0x00339B73
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<MentorMyBeAppliedMsgRes>(stream);
		}

		// Token: 0x0600E457 RID: 58455 RVA: 0x0033B982 File Offset: 0x00339B82
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_MentorMyBeAppliedMsg.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E458 RID: 58456 RVA: 0x0033B99E File Offset: 0x00339B9E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_MentorMyBeAppliedMsg.OnTimeout(this.oArg);
		}

		// Token: 0x04006419 RID: 25625
		public MentorMyBeAppliedMsgArg oArg = new MentorMyBeAppliedMsgArg();

		// Token: 0x0400641A RID: 25626
		public MentorMyBeAppliedMsgRes oRes = null;
	}
}
