using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015CF RID: 5583
	internal class PtcG2C_ThemeActivityChangeNtf : Protocol
	{
		// Token: 0x0600EC66 RID: 60518 RVA: 0x003470E0 File Offset: 0x003452E0
		public override uint GetProtoType()
		{
			return 25642U;
		}

		// Token: 0x0600EC67 RID: 60519 RVA: 0x003470F7 File Offset: 0x003452F7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ThemeActivityChangeData>(stream, this.Data);
		}

		// Token: 0x0600EC68 RID: 60520 RVA: 0x00347107 File Offset: 0x00345307
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ThemeActivityChangeData>(stream);
		}

		// Token: 0x0600EC69 RID: 60521 RVA: 0x00347116 File Offset: 0x00345316
		public override void Process()
		{
			Process_PtcG2C_ThemeActivityChangeNtf.Process(this);
		}

		// Token: 0x040065A9 RID: 26025
		public ThemeActivityChangeData Data = new ThemeActivityChangeData();
	}
}
