using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013CE RID: 5070
	internal class RpcC2M_GetOtherMentorStatus : Rpc
	{
		// Token: 0x0600E430 RID: 58416 RVA: 0x0033B528 File Offset: 0x00339728
		public override uint GetRpcType()
		{
			return 4896U;
		}

		// Token: 0x0600E431 RID: 58417 RVA: 0x0033B53F File Offset: 0x0033973F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetOtherMentorStatusArg>(stream, this.oArg);
		}

		// Token: 0x0600E432 RID: 58418 RVA: 0x0033B54F File Offset: 0x0033974F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetOtherMentorStatusRes>(stream);
		}

		// Token: 0x0600E433 RID: 58419 RVA: 0x0033B55E File Offset: 0x0033975E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetOtherMentorStatus.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E434 RID: 58420 RVA: 0x0033B57A File Offset: 0x0033977A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetOtherMentorStatus.OnTimeout(this.oArg);
		}

		// Token: 0x04006411 RID: 25617
		public GetOtherMentorStatusArg oArg = new GetOtherMentorStatusArg();

		// Token: 0x04006412 RID: 25618
		public GetOtherMentorStatusRes oRes = null;
	}
}
