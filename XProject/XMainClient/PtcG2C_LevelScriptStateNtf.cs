using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001452 RID: 5202
	internal class PtcG2C_LevelScriptStateNtf : Protocol
	{
		// Token: 0x0600E652 RID: 58962 RVA: 0x0033E4A0 File Offset: 0x0033C6A0
		public override uint GetProtoType()
		{
			return 12789U;
		}

		// Token: 0x0600E653 RID: 58963 RVA: 0x0033E4B7 File Offset: 0x0033C6B7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LevelScriptStateData>(stream, this.Data);
		}

		// Token: 0x0600E654 RID: 58964 RVA: 0x0033E4C7 File Offset: 0x0033C6C7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LevelScriptStateData>(stream);
		}

		// Token: 0x0600E655 RID: 58965 RVA: 0x0033E4D6 File Offset: 0x0033C6D6
		public override void Process()
		{
			Process_PtcG2C_LevelScriptStateNtf.Process(this);
		}

		// Token: 0x0400647A RID: 25722
		public LevelScriptStateData Data = new LevelScriptStateData();
	}
}
