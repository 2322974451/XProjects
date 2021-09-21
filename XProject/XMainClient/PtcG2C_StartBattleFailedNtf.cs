using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200114E RID: 4430
	internal class PtcG2C_StartBattleFailedNtf : Protocol
	{
		// Token: 0x0600DA00 RID: 55808 RVA: 0x0032C7D0 File Offset: 0x0032A9D0
		public override uint GetProtoType()
		{
			return 54098U;
		}

		// Token: 0x0600DA01 RID: 55809 RVA: 0x0032C7E7 File Offset: 0x0032A9E7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StartBattleFailedRes>(stream, this.Data);
		}

		// Token: 0x0600DA02 RID: 55810 RVA: 0x0032C7F7 File Offset: 0x0032A9F7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<StartBattleFailedRes>(stream);
		}

		// Token: 0x0600DA03 RID: 55811 RVA: 0x0032C806 File Offset: 0x0032AA06
		public override void Process()
		{
			Process_PtcG2C_StartBattleFailedNtf.Process(this);
		}

		// Token: 0x04006220 RID: 25120
		public StartBattleFailedRes Data = new StartBattleFailedRes();
	}
}
