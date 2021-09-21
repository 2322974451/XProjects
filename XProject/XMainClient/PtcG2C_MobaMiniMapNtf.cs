using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001553 RID: 5459
	internal class PtcG2C_MobaMiniMapNtf : Protocol
	{
		// Token: 0x0600EA66 RID: 60006 RVA: 0x00344298 File Offset: 0x00342498
		public override uint GetProtoType()
		{
			return 32069U;
		}

		// Token: 0x0600EA67 RID: 60007 RVA: 0x003442AF File Offset: 0x003424AF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaMiniMapData>(stream, this.Data);
		}

		// Token: 0x0600EA68 RID: 60008 RVA: 0x003442BF File Offset: 0x003424BF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaMiniMapData>(stream);
		}

		// Token: 0x0600EA69 RID: 60009 RVA: 0x003442CE File Offset: 0x003424CE
		public override void Process()
		{
			Process_PtcG2C_MobaMiniMapNtf.Process(this);
		}

		// Token: 0x04006540 RID: 25920
		public MobaMiniMapData Data = new MobaMiniMapData();
	}
}
