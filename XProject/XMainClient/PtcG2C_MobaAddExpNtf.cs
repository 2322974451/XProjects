using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001555 RID: 5461
	internal class PtcG2C_MobaAddExpNtf : Protocol
	{
		// Token: 0x0600EA6D RID: 60013 RVA: 0x00344318 File Offset: 0x00342518
		public override uint GetProtoType()
		{
			return 36674U;
		}

		// Token: 0x0600EA6E RID: 60014 RVA: 0x0034432F File Offset: 0x0034252F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaAddExpData>(stream, this.Data);
		}

		// Token: 0x0600EA6F RID: 60015 RVA: 0x0034433F File Offset: 0x0034253F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaAddExpData>(stream);
		}

		// Token: 0x0600EA70 RID: 60016 RVA: 0x0034434E File Offset: 0x0034254E
		public override void Process()
		{
			Process_PtcG2C_MobaAddExpNtf.Process(this);
		}

		// Token: 0x04006541 RID: 25921
		public MobaAddExpData Data = new MobaAddExpData();
	}
}
