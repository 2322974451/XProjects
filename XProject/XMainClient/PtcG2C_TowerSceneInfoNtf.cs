using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010E9 RID: 4329
	internal class PtcG2C_TowerSceneInfoNtf : Protocol
	{
		// Token: 0x0600D85E RID: 55390 RVA: 0x003296FC File Offset: 0x003278FC
		public override uint GetProtoType()
		{
			return 14948U;
		}

		// Token: 0x0600D85F RID: 55391 RVA: 0x00329713 File Offset: 0x00327913
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TowerSceneInfoData>(stream, this.Data);
		}

		// Token: 0x0600D860 RID: 55392 RVA: 0x00329723 File Offset: 0x00327923
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TowerSceneInfoData>(stream);
		}

		// Token: 0x0600D861 RID: 55393 RVA: 0x00329732 File Offset: 0x00327932
		public override void Process()
		{
			Process_PtcG2C_TowerSceneInfoNtf.Process(this);
		}

		// Token: 0x040061D0 RID: 25040
		public TowerSceneInfoData Data = new TowerSceneInfoData();
	}
}
