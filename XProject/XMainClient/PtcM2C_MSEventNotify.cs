using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001233 RID: 4659
	internal class PtcM2C_MSEventNotify : Protocol
	{
		// Token: 0x0600DD99 RID: 56729 RVA: 0x003321E8 File Offset: 0x003303E8
		public override uint GetProtoType()
		{
			return 1415U;
		}

		// Token: 0x0600DD9A RID: 56730 RVA: 0x003321FF File Offset: 0x003303FF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EventNotify>(stream, this.Data);
		}

		// Token: 0x0600DD9B RID: 56731 RVA: 0x0033220F File Offset: 0x0033040F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<EventNotify>(stream);
		}

		// Token: 0x0600DD9C RID: 56732 RVA: 0x0033221E File Offset: 0x0033041E
		public override void Process()
		{
			Process_PtcM2C_MSEventNotify.Process(this);
		}

		// Token: 0x040062CB RID: 25291
		public EventNotify Data = new EventNotify();
	}
}
