using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001125 RID: 4389
	internal class PtcG2C_QANotify : Protocol
	{
		// Token: 0x0600D955 RID: 55637 RVA: 0x0032AE20 File Offset: 0x00329020
		public override uint GetProtoType()
		{
			return 37337U;
		}

		// Token: 0x0600D956 RID: 55638 RVA: 0x0032AE37 File Offset: 0x00329037
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QANotify>(stream, this.Data);
		}

		// Token: 0x0600D957 RID: 55639 RVA: 0x0032AE47 File Offset: 0x00329047
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QANotify>(stream);
		}

		// Token: 0x0600D958 RID: 55640 RVA: 0x0032AE56 File Offset: 0x00329056
		public override void Process()
		{
			Process_PtcG2C_QANotify.Process(this);
		}

		// Token: 0x040061FF RID: 25087
		public QANotify Data = new QANotify();
	}
}
