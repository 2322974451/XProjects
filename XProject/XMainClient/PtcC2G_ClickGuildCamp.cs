using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001370 RID: 4976
	internal class PtcC2G_ClickGuildCamp : Protocol
	{
		// Token: 0x0600E2B8 RID: 58040 RVA: 0x003397EC File Offset: 0x003379EC
		public override uint GetProtoType()
		{
			return 32895U;
		}

		// Token: 0x0600E2B9 RID: 58041 RVA: 0x00339803 File Offset: 0x00337A03
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ClickGuildCampArg>(stream, this.Data);
		}

		// Token: 0x0600E2BA RID: 58042 RVA: 0x00339813 File Offset: 0x00337A13
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ClickGuildCampArg>(stream);
		}

		// Token: 0x0600E2BB RID: 58043 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040063CC RID: 25548
		public ClickGuildCampArg Data = new ClickGuildCampArg();
	}
}
