using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001514 RID: 5396
	internal class RpcC2G_ReportBadPlayer : Rpc
	{
		// Token: 0x0600E968 RID: 59752 RVA: 0x00342AB0 File Offset: 0x00340CB0
		public override uint GetRpcType()
		{
			return 32807U;
		}

		// Token: 0x0600E969 RID: 59753 RVA: 0x00342AC7 File Offset: 0x00340CC7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReportBadPlayerArg>(stream, this.oArg);
		}

		// Token: 0x0600E96A RID: 59754 RVA: 0x00342AD7 File Offset: 0x00340CD7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReportBadPlayerRes>(stream);
		}

		// Token: 0x0600E96B RID: 59755 RVA: 0x00342AE6 File Offset: 0x00340CE6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReportBadPlayer.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E96C RID: 59756 RVA: 0x00342B02 File Offset: 0x00340D02
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReportBadPlayer.OnTimeout(this.oArg);
		}

		// Token: 0x04006510 RID: 25872
		public ReportBadPlayerArg oArg = new ReportBadPlayerArg();

		// Token: 0x04006511 RID: 25873
		public ReportBadPlayerRes oRes = null;
	}
}
