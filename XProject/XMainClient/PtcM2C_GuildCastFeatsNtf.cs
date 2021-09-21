using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001665 RID: 5733
	internal class PtcM2C_GuildCastFeatsNtf : Protocol
	{
		// Token: 0x0600EEDF RID: 61151 RVA: 0x0034A63C File Offset: 0x0034883C
		public override uint GetProtoType()
		{
			return 32885U;
		}

		// Token: 0x0600EEE0 RID: 61152 RVA: 0x0034A653 File Offset: 0x00348853
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCastFeats>(stream, this.Data);
		}

		// Token: 0x0600EEE1 RID: 61153 RVA: 0x0034A663 File Offset: 0x00348863
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCastFeats>(stream);
		}

		// Token: 0x0600EEE2 RID: 61154 RVA: 0x0034A672 File Offset: 0x00348872
		public override void Process()
		{
			Process_PtcM2C_GuildCastFeatsNtf.Process(this);
		}

		// Token: 0x04006629 RID: 26153
		public GuildCastFeats Data = new GuildCastFeats();
	}
}
