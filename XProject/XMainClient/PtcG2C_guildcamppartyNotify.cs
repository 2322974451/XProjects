using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014F2 RID: 5362
	internal class PtcG2C_guildcamppartyNotify : Protocol
	{
		// Token: 0x0600E8DD RID: 59613 RVA: 0x00341DA4 File Offset: 0x0033FFA4
		public override uint GetProtoType()
		{
			return 23338U;
		}

		// Token: 0x0600E8DE RID: 59614 RVA: 0x00341DBB File Offset: 0x0033FFBB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<guildcamppartyNotifyNtf>(stream, this.Data);
		}

		// Token: 0x0600E8DF RID: 59615 RVA: 0x00341DCB File Offset: 0x0033FFCB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<guildcamppartyNotifyNtf>(stream);
		}

		// Token: 0x0600E8E0 RID: 59616 RVA: 0x00341DDA File Offset: 0x0033FFDA
		public override void Process()
		{
			Process_PtcG2C_guildcamppartyNotify.Process(this);
		}

		// Token: 0x040064F5 RID: 25845
		public guildcamppartyNotifyNtf Data = new guildcamppartyNotifyNtf();
	}
}
