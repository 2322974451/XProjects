using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001672 RID: 5746
	internal class PtcG2C_WorldLevelNtf2Client : Protocol
	{
		// Token: 0x0600EF18 RID: 61208 RVA: 0x0034AC28 File Offset: 0x00348E28
		public override uint GetProtoType()
		{
			return 63449U;
		}

		// Token: 0x0600EF19 RID: 61209 RVA: 0x0034AC3F File Offset: 0x00348E3F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldLevel>(stream, this.Data);
		}

		// Token: 0x0600EF1A RID: 61210 RVA: 0x0034AC4F File Offset: 0x00348E4F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WorldLevel>(stream);
		}

		// Token: 0x0600EF1B RID: 61211 RVA: 0x0034AC5E File Offset: 0x00348E5E
		public override void Process()
		{
			Process_PtcG2C_WorldLevelNtf2Client.Process(this);
		}

		// Token: 0x0400663C RID: 26172
		public WorldLevel Data = new WorldLevel();
	}
}
