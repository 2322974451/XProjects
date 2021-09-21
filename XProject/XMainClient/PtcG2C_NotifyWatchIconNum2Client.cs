using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011B7 RID: 4535
	internal class PtcG2C_NotifyWatchIconNum2Client : Protocol
	{
		// Token: 0x0600DBA4 RID: 56228 RVA: 0x0032F530 File Offset: 0x0032D730
		public override uint GetProtoType()
		{
			return 48952U;
		}

		// Token: 0x0600DBA5 RID: 56229 RVA: 0x0032F547 File Offset: 0x0032D747
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IconWatchListNum>(stream, this.Data);
		}

		// Token: 0x0600DBA6 RID: 56230 RVA: 0x0032F557 File Offset: 0x0032D757
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IconWatchListNum>(stream);
		}

		// Token: 0x0600DBA7 RID: 56231 RVA: 0x0032F566 File Offset: 0x0032D766
		public override void Process()
		{
			Process_PtcG2C_NotifyWatchIconNum2Client.Process(this);
		}

		// Token: 0x0400626D RID: 25197
		public IconWatchListNum Data = new IconWatchListNum();
	}
}
