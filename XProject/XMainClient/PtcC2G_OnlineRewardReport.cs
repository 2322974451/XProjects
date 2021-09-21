using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200109C RID: 4252
	internal class PtcC2G_OnlineRewardReport : Protocol
	{
		// Token: 0x0600D730 RID: 55088 RVA: 0x0032742C File Offset: 0x0032562C
		public override uint GetProtoType()
		{
			return 36178U;
		}

		// Token: 0x0600D731 RID: 55089 RVA: 0x00327443 File Offset: 0x00325643
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OnlineRewardReport>(stream, this.Data);
		}

		// Token: 0x0600D732 RID: 55090 RVA: 0x00327453 File Offset: 0x00325653
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OnlineRewardReport>(stream);
		}

		// Token: 0x0600D733 RID: 55091 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x0400619D RID: 24989
		public OnlineRewardReport Data = new OnlineRewardReport();
	}
}
