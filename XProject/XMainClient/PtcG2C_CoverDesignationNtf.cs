using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010F1 RID: 4337
	internal class PtcG2C_CoverDesignationNtf : Protocol
	{
		// Token: 0x0600D880 RID: 55424 RVA: 0x00329AC0 File Offset: 0x00327CC0
		public override uint GetProtoType()
		{
			return 45821U;
		}

		// Token: 0x0600D881 RID: 55425 RVA: 0x00329AD7 File Offset: 0x00327CD7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CoverDesignationNtf>(stream, this.Data);
		}

		// Token: 0x0600D882 RID: 55426 RVA: 0x00329AE7 File Offset: 0x00327CE7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CoverDesignationNtf>(stream);
		}

		// Token: 0x0600D883 RID: 55427 RVA: 0x00329AF6 File Offset: 0x00327CF6
		public override void Process()
		{
			Process_PtcG2C_CoverDesignationNtf.Process(this);
		}

		// Token: 0x040061D7 RID: 25047
		public CoverDesignationNtf Data = new CoverDesignationNtf();
	}
}
