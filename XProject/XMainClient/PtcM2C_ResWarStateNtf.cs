using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001377 RID: 4983
	internal class PtcM2C_ResWarStateNtf : Protocol
	{
		// Token: 0x0600E2D4 RID: 58068 RVA: 0x003399F0 File Offset: 0x00337BF0
		public override uint GetProtoType()
		{
			return 18481U;
		}

		// Token: 0x0600E2D5 RID: 58069 RVA: 0x00339A07 File Offset: 0x00337C07
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarStateInfo>(stream, this.Data);
		}

		// Token: 0x0600E2D6 RID: 58070 RVA: 0x00339A17 File Offset: 0x00337C17
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarStateInfo>(stream);
		}

		// Token: 0x0600E2D7 RID: 58071 RVA: 0x00339A26 File Offset: 0x00337C26
		public override void Process()
		{
			Process_PtcM2C_ResWarStateNtf.Process(this);
		}

		// Token: 0x040063D1 RID: 25553
		public ResWarStateInfo Data = new ResWarStateInfo();
	}
}
