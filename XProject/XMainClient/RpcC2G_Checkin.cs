using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001039 RID: 4153
	internal class RpcC2G_Checkin : Rpc
	{
		// Token: 0x0600D592 RID: 54674 RVA: 0x00324534 File Offset: 0x00322734
		public override uint GetRpcType()
		{
			return 56127U;
		}

		// Token: 0x0600D593 RID: 54675 RVA: 0x0032454B File Offset: 0x0032274B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CheckinArg>(stream, this.oArg);
		}

		// Token: 0x0600D594 RID: 54676 RVA: 0x0032455B File Offset: 0x0032275B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CheckinRes>(stream);
		}

		// Token: 0x0600D595 RID: 54677 RVA: 0x0032456A File Offset: 0x0032276A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_Checkin.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D596 RID: 54678 RVA: 0x00324586 File Offset: 0x00322786
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_Checkin.OnTimeout(this.oArg);
		}

		// Token: 0x04006129 RID: 24873
		public CheckinArg oArg = new CheckinArg();

		// Token: 0x0400612A RID: 24874
		public CheckinRes oRes = new CheckinRes();
	}
}
