using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001387 RID: 4999
	internal class PtcG2C_ServerOpenDayNtf : Protocol
	{
		// Token: 0x0600E312 RID: 58130 RVA: 0x00339E28 File Offset: 0x00338028
		public override uint GetProtoType()
		{
			return 23820U;
		}

		// Token: 0x0600E313 RID: 58131 RVA: 0x00339E3F File Offset: 0x0033803F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ServerOpenDay>(stream, this.Data);
		}

		// Token: 0x0600E314 RID: 58132 RVA: 0x00339E4F File Offset: 0x0033804F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ServerOpenDay>(stream);
		}

		// Token: 0x0600E315 RID: 58133 RVA: 0x00339E5E File Offset: 0x0033805E
		public override void Process()
		{
			Process_PtcG2C_ServerOpenDayNtf.Process(this);
		}

		// Token: 0x040063DC RID: 25564
		public ServerOpenDay Data = new ServerOpenDay();
	}
}
