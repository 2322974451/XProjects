using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014B2 RID: 5298
	internal class PtcM2C_NoticeGuildTerrBigIcon : Protocol
	{
		// Token: 0x0600E7D3 RID: 59347 RVA: 0x00340928 File Offset: 0x0033EB28
		public override uint GetProtoType()
		{
			return 13723U;
		}

		// Token: 0x0600E7D4 RID: 59348 RVA: 0x0034093F File Offset: 0x0033EB3F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildTerrBigIcon>(stream, this.Data);
		}

		// Token: 0x0600E7D5 RID: 59349 RVA: 0x0034094F File Offset: 0x0033EB4F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildTerrBigIcon>(stream);
		}

		// Token: 0x0600E7D6 RID: 59350 RVA: 0x0034095E File Offset: 0x0033EB5E
		public override void Process()
		{
			Process_PtcM2C_NoticeGuildTerrBigIcon.Process(this);
		}

		// Token: 0x040064C1 RID: 25793
		public NoticeGuildTerrBigIcon Data = new NoticeGuildTerrBigIcon();
	}
}
