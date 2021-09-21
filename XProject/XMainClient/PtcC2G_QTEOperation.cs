using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010D1 RID: 4305
	internal class PtcC2G_QTEOperation : Protocol
	{
		// Token: 0x0600D7FD RID: 55293 RVA: 0x00328E38 File Offset: 0x00327038
		public override uint GetProtoType()
		{
			return 11413U;
		}

		// Token: 0x0600D7FE RID: 55294 RVA: 0x00328E4F File Offset: 0x0032704F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QTEOperation>(stream, this.Data);
		}

		// Token: 0x0600D7FF RID: 55295 RVA: 0x00328E5F File Offset: 0x0032705F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QTEOperation>(stream);
		}

		// Token: 0x0600D800 RID: 55296 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040061BE RID: 25022
		public QTEOperation Data = new QTEOperation();
	}
}
