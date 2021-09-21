using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014CD RID: 5325
	internal class PtcG2C_MilitaryrankNtf : Protocol
	{
		// Token: 0x0600E83F RID: 59455 RVA: 0x003411AC File Offset: 0x0033F3AC
		public override uint GetProtoType()
		{
			return 64945U;
		}

		// Token: 0x0600E840 RID: 59456 RVA: 0x003411C3 File Offset: 0x0033F3C3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MilitaryRecord>(stream, this.Data);
		}

		// Token: 0x0600E841 RID: 59457 RVA: 0x003411D3 File Offset: 0x0033F3D3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MilitaryRecord>(stream);
		}

		// Token: 0x0600E842 RID: 59458 RVA: 0x003411E2 File Offset: 0x0033F3E2
		public override void Process()
		{
			Process_PtcG2C_MilitaryrankNtf.Process(this);
		}

		// Token: 0x040064D5 RID: 25813
		public MilitaryRecord Data = new MilitaryRecord();
	}
}
