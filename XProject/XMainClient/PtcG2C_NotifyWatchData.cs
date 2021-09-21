using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001192 RID: 4498
	internal class PtcG2C_NotifyWatchData : Protocol
	{
		// Token: 0x0600DB10 RID: 56080 RVA: 0x0032E6E0 File Offset: 0x0032C8E0
		public override uint GetProtoType()
		{
			return 16154U;
		}

		// Token: 0x0600DB11 RID: 56081 RVA: 0x0032E6F7 File Offset: 0x0032C8F7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OneLiveRecordInfo>(stream, this.Data);
		}

		// Token: 0x0600DB12 RID: 56082 RVA: 0x0032E707 File Offset: 0x0032C907
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OneLiveRecordInfo>(stream);
		}

		// Token: 0x0600DB13 RID: 56083 RVA: 0x0032E716 File Offset: 0x0032C916
		public override void Process()
		{
			Process_PtcG2C_NotifyWatchData.Process(this);
		}

		// Token: 0x04006252 RID: 25170
		public OneLiveRecordInfo Data = new OneLiveRecordInfo();
	}
}
