using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200113B RID: 4411
	internal class PtcG2C_FastMBConfirmNtf : Protocol
	{
		// Token: 0x0600D9B4 RID: 55732 RVA: 0x0032B7CC File Offset: 0x003299CC
		public override uint GetProtoType()
		{
			return 51623U;
		}

		// Token: 0x0600D9B5 RID: 55733 RVA: 0x0032B7E3 File Offset: 0x003299E3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FMBArg>(stream, this.Data);
		}

		// Token: 0x0600D9B6 RID: 55734 RVA: 0x0032B7F3 File Offset: 0x003299F3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FMBArg>(stream);
		}

		// Token: 0x0600D9B7 RID: 55735 RVA: 0x0032B802 File Offset: 0x00329A02
		public override void Process()
		{
			Process_PtcG2C_FastMBConfirmNtf.Process(this);
		}

		// Token: 0x04006212 RID: 25106
		public FMBArg Data = new FMBArg();
	}
}
