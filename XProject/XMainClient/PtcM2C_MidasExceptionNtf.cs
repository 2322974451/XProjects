using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200148B RID: 5259
	internal class PtcM2C_MidasExceptionNtf : Protocol
	{
		// Token: 0x0600E731 RID: 59185 RVA: 0x0033FA80 File Offset: 0x0033DC80
		public override uint GetProtoType()
		{
			return 22947U;
		}

		// Token: 0x0600E732 RID: 59186 RVA: 0x0033FA97 File Offset: 0x0033DC97
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MidasExceptionInfo>(stream, this.Data);
		}

		// Token: 0x0600E733 RID: 59187 RVA: 0x0033FAA7 File Offset: 0x0033DCA7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MidasExceptionInfo>(stream);
		}

		// Token: 0x0600E734 RID: 59188 RVA: 0x0033FAB6 File Offset: 0x0033DCB6
		public override void Process()
		{
			Process_PtcM2C_MidasExceptionNtf.Process(this);
		}

		// Token: 0x040064A2 RID: 25762
		public MidasExceptionInfo Data = new MidasExceptionInfo();
	}
}
