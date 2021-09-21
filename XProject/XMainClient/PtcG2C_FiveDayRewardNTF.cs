using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200110C RID: 4364
	internal class PtcG2C_FiveDayRewardNTF : Protocol
	{
		// Token: 0x0600D8F0 RID: 55536 RVA: 0x0032A458 File Offset: 0x00328658
		public override uint GetProtoType()
		{
			return 37452U;
		}

		// Token: 0x0600D8F1 RID: 55537 RVA: 0x0032A46F File Offset: 0x0032866F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FiveRewardState>(stream, this.Data);
		}

		// Token: 0x0600D8F2 RID: 55538 RVA: 0x0032A47F File Offset: 0x0032867F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FiveRewardState>(stream);
		}

		// Token: 0x0600D8F3 RID: 55539 RVA: 0x0032A48E File Offset: 0x0032868E
		public override void Process()
		{
			Process_PtcG2C_FiveDayRewardNTF.Process(this);
		}

		// Token: 0x040061EC RID: 25068
		public FiveRewardState Data = new FiveRewardState();
	}
}
