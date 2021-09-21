using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014DF RID: 5343
	internal class PtcM2C_SkyCraftEliRoomNtf : Protocol
	{
		// Token: 0x0600E889 RID: 59529 RVA: 0x003416FC File Offset: 0x0033F8FC
		public override uint GetProtoType()
		{
			return 6761U;
		}

		// Token: 0x0600E88A RID: 59530 RVA: 0x00341713 File Offset: 0x0033F913
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCraftEliRoomNtf>(stream, this.Data);
		}

		// Token: 0x0600E88B RID: 59531 RVA: 0x00341723 File Offset: 0x0033F923
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCraftEliRoomNtf>(stream);
		}

		// Token: 0x0600E88C RID: 59532 RVA: 0x00341732 File Offset: 0x0033F932
		public override void Process()
		{
			Process_PtcM2C_SkyCraftEliRoomNtf.Process(this);
		}

		// Token: 0x040064E3 RID: 25827
		public SkyCraftEliRoomNtf Data = new SkyCraftEliRoomNtf();
	}
}
