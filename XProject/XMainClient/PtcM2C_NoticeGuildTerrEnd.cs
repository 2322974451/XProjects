using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014AC RID: 5292
	internal class PtcM2C_NoticeGuildTerrEnd : Protocol
	{
		// Token: 0x0600E7BC RID: 59324 RVA: 0x00340764 File Offset: 0x0033E964
		public override uint GetProtoType()
		{
			return 2103U;
		}

		// Token: 0x0600E7BD RID: 59325 RVA: 0x0034077B File Offset: 0x0033E97B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildTerrEnd>(stream, this.Data);
		}

		// Token: 0x0600E7BE RID: 59326 RVA: 0x0034078B File Offset: 0x0033E98B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildTerrEnd>(stream);
		}

		// Token: 0x0600E7BF RID: 59327 RVA: 0x0034079A File Offset: 0x0033E99A
		public override void Process()
		{
			Process_PtcM2C_NoticeGuildTerrEnd.Process(this);
		}

		// Token: 0x040064BD RID: 25789
		public NoticeGuildTerrEnd Data = new NoticeGuildTerrEnd();
	}
}
