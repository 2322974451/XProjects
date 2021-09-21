using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200153F RID: 5439
	internal class PtcG2C_MobaSignalBroadcast : Protocol
	{
		// Token: 0x0600EA12 RID: 59922 RVA: 0x00343ABC File Offset: 0x00341CBC
		public override uint GetProtoType()
		{
			return 6250U;
		}

		// Token: 0x0600EA13 RID: 59923 RVA: 0x00343AD3 File Offset: 0x00341CD3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaSignalBroadcastData>(stream, this.Data);
		}

		// Token: 0x0600EA14 RID: 59924 RVA: 0x00343AE3 File Offset: 0x00341CE3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaSignalBroadcastData>(stream);
		}

		// Token: 0x0600EA15 RID: 59925 RVA: 0x00343AF2 File Offset: 0x00341CF2
		public override void Process()
		{
			Process_PtcG2C_MobaSignalBroadcast.Process(this);
		}

		// Token: 0x0400652F RID: 25903
		public MobaSignalBroadcastData Data = new MobaSignalBroadcastData();
	}
}
