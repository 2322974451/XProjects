using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010E2 RID: 4322
	internal class PtcG2C_ExpFindBackNtf : Protocol
	{
		// Token: 0x0600D840 RID: 55360 RVA: 0x003294C0 File Offset: 0x003276C0
		public override uint GetProtoType()
		{
			return 4933U;
		}

		// Token: 0x0600D841 RID: 55361 RVA: 0x003294D7 File Offset: 0x003276D7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ExpFindBackData>(stream, this.Data);
		}

		// Token: 0x0600D842 RID: 55362 RVA: 0x003294E7 File Offset: 0x003276E7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ExpFindBackData>(stream);
		}

		// Token: 0x0600D843 RID: 55363 RVA: 0x003294F6 File Offset: 0x003276F6
		public override void Process()
		{
			Process_PtcG2C_ExpFindBackNtf.Process(this);
		}

		// Token: 0x040061CA RID: 25034
		public ExpFindBackData Data = new ExpFindBackData();
	}
}
