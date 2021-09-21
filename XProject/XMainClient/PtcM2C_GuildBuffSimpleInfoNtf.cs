using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001383 RID: 4995
	internal class PtcM2C_GuildBuffSimpleInfoNtf : Protocol
	{
		// Token: 0x0600E302 RID: 58114 RVA: 0x00339D10 File Offset: 0x00337F10
		public override uint GetProtoType()
		{
			return 57161U;
		}

		// Token: 0x0600E303 RID: 58115 RVA: 0x00339D27 File Offset: 0x00337F27
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBuffSimpleAllInfo>(stream, this.Data);
		}

		// Token: 0x0600E304 RID: 58116 RVA: 0x00339D37 File Offset: 0x00337F37
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildBuffSimpleAllInfo>(stream);
		}

		// Token: 0x0600E305 RID: 58117 RVA: 0x00339D46 File Offset: 0x00337F46
		public override void Process()
		{
			Process_PtcM2C_GuildBuffSimpleInfoNtf.Process(this);
		}

		// Token: 0x040063D9 RID: 25561
		public GuildBuffSimpleAllInfo Data = new GuildBuffSimpleAllInfo();
	}
}
