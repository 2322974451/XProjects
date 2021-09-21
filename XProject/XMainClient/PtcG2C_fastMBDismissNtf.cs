using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200113E RID: 4414
	internal class PtcG2C_fastMBDismissNtf : Protocol
	{
		// Token: 0x0600D9C0 RID: 55744 RVA: 0x0032B880 File Offset: 0x00329A80
		public override uint GetProtoType()
		{
			return 49087U;
		}

		// Token: 0x0600D9C1 RID: 55745 RVA: 0x0032B897 File Offset: 0x00329A97
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FMDArg>(stream, this.Data);
		}

		// Token: 0x0600D9C2 RID: 55746 RVA: 0x0032B8A7 File Offset: 0x00329AA7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FMDArg>(stream);
		}

		// Token: 0x0600D9C3 RID: 55747 RVA: 0x0032B8B6 File Offset: 0x00329AB6
		public override void Process()
		{
			Process_PtcG2C_fastMBDismissNtf.Process(this);
		}

		// Token: 0x04006214 RID: 25108
		public FMDArg Data = new FMDArg();
	}
}
