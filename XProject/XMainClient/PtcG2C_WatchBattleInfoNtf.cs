using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001168 RID: 4456
	internal class PtcG2C_WatchBattleInfoNtf : Protocol
	{
		// Token: 0x0600DA75 RID: 55925 RVA: 0x0032DAB0 File Offset: 0x0032BCB0
		public override uint GetProtoType()
		{
			return 23415U;
		}

		// Token: 0x0600DA76 RID: 55926 RVA: 0x0032DAC7 File Offset: 0x0032BCC7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WatchBattleData>(stream, this.Data);
		}

		// Token: 0x0600DA77 RID: 55927 RVA: 0x0032DAD7 File Offset: 0x0032BCD7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WatchBattleData>(stream);
		}

		// Token: 0x0600DA78 RID: 55928 RVA: 0x0032DAE6 File Offset: 0x0032BCE6
		public override void Process()
		{
			Process_PtcG2C_WatchBattleInfoNtf.Process(this);
		}

		// Token: 0x0400623A RID: 25146
		public WatchBattleData Data = new WatchBattleData();
	}
}
