using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200109D RID: 4253
	internal class PtcC2G_NextDayRewardReport : Protocol
	{
		// Token: 0x0600D735 RID: 55093 RVA: 0x00327478 File Offset: 0x00325678
		public override uint GetProtoType()
		{
			return 1059U;
		}

		// Token: 0x0600D736 RID: 55094 RVA: 0x0032748F File Offset: 0x0032568F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NextDayRewardReport>(stream, this.Data);
		}

		// Token: 0x0600D737 RID: 55095 RVA: 0x0032749F File Offset: 0x0032569F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NextDayRewardReport>(stream);
		}

		// Token: 0x0600D738 RID: 55096 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x0400619E RID: 24990
		public NextDayRewardReport Data = new NextDayRewardReport();
	}
}
