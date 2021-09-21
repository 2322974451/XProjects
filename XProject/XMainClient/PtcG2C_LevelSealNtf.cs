using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001102 RID: 4354
	internal class PtcG2C_LevelSealNtf : Protocol
	{
		// Token: 0x0600D8C7 RID: 55495 RVA: 0x0032A084 File Offset: 0x00328284
		public override uint GetProtoType()
		{
			return 40338U;
		}

		// Token: 0x0600D8C8 RID: 55496 RVA: 0x0032A09B File Offset: 0x0032829B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LevelSealInfo>(stream, this.Data);
		}

		// Token: 0x0600D8C9 RID: 55497 RVA: 0x0032A0AB File Offset: 0x003282AB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LevelSealInfo>(stream);
		}

		// Token: 0x0600D8CA RID: 55498 RVA: 0x0032A0BA File Offset: 0x003282BA
		public override void Process()
		{
			Process_PtcG2C_LevelSealNtf.Process(this);
		}

		// Token: 0x040061E4 RID: 25060
		public LevelSealInfo Data = new LevelSealInfo();
	}
}
