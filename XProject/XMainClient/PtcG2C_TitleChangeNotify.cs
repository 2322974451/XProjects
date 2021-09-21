using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200121D RID: 4637
	internal class PtcG2C_TitleChangeNotify : Protocol
	{
		// Token: 0x0600DD40 RID: 56640 RVA: 0x003318D8 File Offset: 0x0032FAD8
		public override uint GetProtoType()
		{
			return 1040U;
		}

		// Token: 0x0600DD41 RID: 56641 RVA: 0x003318EF File Offset: 0x0032FAEF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<titleChangeData>(stream, this.Data);
		}

		// Token: 0x0600DD42 RID: 56642 RVA: 0x003318FF File Offset: 0x0032FAFF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<titleChangeData>(stream);
		}

		// Token: 0x0600DD43 RID: 56643 RVA: 0x0033190E File Offset: 0x0032FB0E
		public override void Process()
		{
			Process_PtcG2C_TitleChangeNotify.Process(this);
		}

		// Token: 0x040062BA RID: 25274
		public titleChangeData Data = new titleChangeData();
	}
}
