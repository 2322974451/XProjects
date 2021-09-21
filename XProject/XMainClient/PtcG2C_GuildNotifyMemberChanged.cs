using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001077 RID: 4215
	internal class PtcG2C_GuildNotifyMemberChanged : Protocol
	{
		// Token: 0x0600D698 RID: 54936 RVA: 0x0032656C File Offset: 0x0032476C
		public override uint GetProtoType()
		{
			return 5957U;
		}

		// Token: 0x0600D699 RID: 54937 RVA: 0x00326583 File Offset: 0x00324783
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildMemberInfo>(stream, this.Data);
		}

		// Token: 0x0600D69A RID: 54938 RVA: 0x00326593 File Offset: 0x00324793
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildMemberInfo>(stream);
		}

		// Token: 0x0600D69B RID: 54939 RVA: 0x003265A2 File Offset: 0x003247A2
		public override void Process()
		{
			Process_PtcG2C_GuildNotifyMemberChanged.Process(this);
		}

		// Token: 0x04006180 RID: 24960
		public GuildMemberInfo Data = new GuildMemberInfo();
	}
}
