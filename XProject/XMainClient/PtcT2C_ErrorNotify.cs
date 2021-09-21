using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000FF6 RID: 4086
	internal class PtcT2C_ErrorNotify : Protocol
	{
		// Token: 0x0600D47F RID: 54399 RVA: 0x00321820 File Offset: 0x0031FA20
		public override uint GetProtoType()
		{
			return 21940U;
		}

		// Token: 0x0600D480 RID: 54400 RVA: 0x00321837 File Offset: 0x0031FA37
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ErrorInfo>(stream, this.Data);
		}

		// Token: 0x0600D481 RID: 54401 RVA: 0x00321847 File Offset: 0x0031FA47
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ErrorInfo>(stream);
		}

		// Token: 0x0600D482 RID: 54402 RVA: 0x00321856 File Offset: 0x0031FA56
		public override void Process()
		{
			Process_PtcT2C_ErrorNotify.Process(this);
		}

		// Token: 0x040060F2 RID: 24818
		public ErrorInfo Data = new ErrorInfo();
	}
}
