using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001634 RID: 5684
	internal class PtcM2C_DragonGuildNameNtf : Protocol
	{
		// Token: 0x0600EE10 RID: 60944 RVA: 0x00349434 File Offset: 0x00347634
		public override uint GetProtoType()
		{
			return 35553U;
		}

		// Token: 0x0600EE11 RID: 60945 RVA: 0x0034944B File Offset: 0x0034764B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildNameNtf>(stream, this.Data);
		}

		// Token: 0x0600EE12 RID: 60946 RVA: 0x0034945B File Offset: 0x0034765B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DragonGuildNameNtf>(stream);
		}

		// Token: 0x0600EE13 RID: 60947 RVA: 0x0034946A File Offset: 0x0034766A
		public override void Process()
		{
			Process_PtcM2C_DragonGuildNameNtf.Process(this);
		}

		// Token: 0x040065FF RID: 26111
		public DragonGuildNameNtf Data = new DragonGuildNameNtf();
	}
}
