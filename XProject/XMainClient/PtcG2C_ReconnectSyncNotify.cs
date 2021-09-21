using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001106 RID: 4358
	internal class PtcG2C_ReconnectSyncNotify : Protocol
	{
		// Token: 0x0600D8D7 RID: 55511 RVA: 0x0032A1FC File Offset: 0x003283FC
		public override uint GetProtoType()
		{
			return 42128U;
		}

		// Token: 0x0600D8D8 RID: 55512 RVA: 0x0032A213 File Offset: 0x00328413
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReconectSync>(stream, this.Data);
		}

		// Token: 0x0600D8D9 RID: 55513 RVA: 0x0032A223 File Offset: 0x00328423
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReconectSync>(stream);
		}

		// Token: 0x0600D8DA RID: 55514 RVA: 0x0032A232 File Offset: 0x00328432
		public override void Process()
		{
			Process_PtcG2C_ReconnectSyncNotify.Process(this);
		}

		// Token: 0x040061E7 RID: 25063
		public ReconectSync Data = new ReconectSync();
	}
}
