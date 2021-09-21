using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012ED RID: 4845
	internal class PtcM2C_NoticeGuildLadderStart : Protocol
	{
		// Token: 0x0600E09F RID: 57503 RVA: 0x003365C4 File Offset: 0x003347C4
		public override uint GetProtoType()
		{
			return 49782U;
		}

		// Token: 0x0600E0A0 RID: 57504 RVA: 0x003365DB File Offset: 0x003347DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildLadderStart>(stream, this.Data);
		}

		// Token: 0x0600E0A1 RID: 57505 RVA: 0x003365EB File Offset: 0x003347EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildLadderStart>(stream);
		}

		// Token: 0x0600E0A2 RID: 57506 RVA: 0x003365FA File Offset: 0x003347FA
		public override void Process()
		{
			Process_PtcM2C_NoticeGuildLadderStart.Process(this);
		}

		// Token: 0x04006364 RID: 25444
		public NoticeGuildLadderStart Data = new NoticeGuildLadderStart();
	}
}
