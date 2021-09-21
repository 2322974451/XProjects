using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001087 RID: 4231
	internal class PtcG2C_GuildCheckinBoxNtf : Protocol
	{
		// Token: 0x0600D6DE RID: 55006 RVA: 0x00326DBC File Offset: 0x00324FBC
		public override uint GetProtoType()
		{
			return 5114U;
		}

		// Token: 0x0600D6DF RID: 55007 RVA: 0x00326DD3 File Offset: 0x00324FD3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCheckinBoxNtf>(stream, this.Data);
		}

		// Token: 0x0600D6E0 RID: 55008 RVA: 0x00326DE3 File Offset: 0x00324FE3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCheckinBoxNtf>(stream);
		}

		// Token: 0x0600D6E1 RID: 55009 RVA: 0x00326DF2 File Offset: 0x00324FF2
		public override void Process()
		{
			Process_PtcG2C_GuildCheckinBoxNtf.Process(this);
		}

		// Token: 0x0400618E RID: 24974
		public GuildCheckinBoxNtf Data = new GuildCheckinBoxNtf();
	}
}
