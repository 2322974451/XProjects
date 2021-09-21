using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001698 RID: 5784
	internal class PtcM2C_CrossGvgRoomStateNtf : Protocol
	{
		// Token: 0x0600EFB9 RID: 61369 RVA: 0x0034BD1C File Offset: 0x00349F1C
		public override uint GetProtoType()
		{
			return 43720U;
		}

		// Token: 0x0600EFBA RID: 61370 RVA: 0x0034BD33 File Offset: 0x00349F33
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CrossGvgRoomStateNtf>(stream, this.Data);
		}

		// Token: 0x0600EFBB RID: 61371 RVA: 0x0034BD43 File Offset: 0x00349F43
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CrossGvgRoomStateNtf>(stream);
		}

		// Token: 0x0600EFBC RID: 61372 RVA: 0x0034BD52 File Offset: 0x00349F52
		public override void Process()
		{
			Process_PtcM2C_CrossGvgRoomStateNtf.Process(this);
		}

		// Token: 0x0400665D RID: 26205
		public CrossGvgRoomStateNtf Data = new CrossGvgRoomStateNtf();
	}
}
