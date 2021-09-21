using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000FF9 RID: 4089
	internal class PtcG2C_EnterSceneNtf : Protocol
	{
		// Token: 0x0600D48B RID: 54411 RVA: 0x003218DC File Offset: 0x0031FADC
		public override uint GetProtoType()
		{
			return 63366U;
		}

		// Token: 0x0600D48C RID: 54412 RVA: 0x003218F3 File Offset: 0x0031FAF3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SceneCfg>(stream, this.Data);
		}

		// Token: 0x0600D48D RID: 54413 RVA: 0x00321903 File Offset: 0x0031FB03
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SceneCfg>(stream);
		}

		// Token: 0x0600D48E RID: 54414 RVA: 0x00321912 File Offset: 0x0031FB12
		public override void Process()
		{
			Process_PtcG2C_EnterSceneNtf.Process(this);
		}

		// Token: 0x040060F4 RID: 24820
		public SceneCfg Data = new SceneCfg();
	}
}
