using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001375 RID: 4981
	internal class PtcM2C_SynGuilIntegralState : Protocol
	{
		// Token: 0x0600E2CD RID: 58061 RVA: 0x00339970 File Offset: 0x00337B70
		public override uint GetProtoType()
		{
			return 28075U;
		}

		// Token: 0x0600E2CE RID: 58062 RVA: 0x00339987 File Offset: 0x00337B87
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuilIntegralState>(stream, this.Data);
		}

		// Token: 0x0600E2CF RID: 58063 RVA: 0x00339997 File Offset: 0x00337B97
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuilIntegralState>(stream);
		}

		// Token: 0x0600E2D0 RID: 58064 RVA: 0x003399A6 File Offset: 0x00337BA6
		public override void Process()
		{
			Process_PtcM2C_SynGuilIntegralState.Process(this);
		}

		// Token: 0x040063D0 RID: 25552
		public SynGuilIntegralState Data = new SynGuilIntegralState();
	}
}
