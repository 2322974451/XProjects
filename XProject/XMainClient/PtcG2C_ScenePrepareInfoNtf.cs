using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001414 RID: 5140
	internal class PtcG2C_ScenePrepareInfoNtf : Protocol
	{
		// Token: 0x0600E558 RID: 58712 RVA: 0x0033CCEC File Offset: 0x0033AEEC
		public override uint GetProtoType()
		{
			return 65478U;
		}

		// Token: 0x0600E559 RID: 58713 RVA: 0x0033CD03 File Offset: 0x0033AF03
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ScenePrepareInfoNtf>(stream, this.Data);
		}

		// Token: 0x0600E55A RID: 58714 RVA: 0x0033CD13 File Offset: 0x0033AF13
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ScenePrepareInfoNtf>(stream);
		}

		// Token: 0x0600E55B RID: 58715 RVA: 0x0033CD22 File Offset: 0x0033AF22
		public override void Process()
		{
			Process_PtcG2C_ScenePrepareInfoNtf.Process(this);
		}

		// Token: 0x0400644D RID: 25677
		public ScenePrepareInfoNtf Data = new ScenePrepareInfoNtf();
	}
}
