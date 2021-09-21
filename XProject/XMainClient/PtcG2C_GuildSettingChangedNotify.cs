using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001079 RID: 4217
	internal class PtcG2C_GuildSettingChangedNotify : Protocol
	{
		// Token: 0x0600D69F RID: 54943 RVA: 0x003265C4 File Offset: 0x003247C4
		public override uint GetProtoType()
		{
			return 63721U;
		}

		// Token: 0x0600D6A0 RID: 54944 RVA: 0x003265DB File Offset: 0x003247DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildSettingChanged>(stream, this.Data);
		}

		// Token: 0x0600D6A1 RID: 54945 RVA: 0x003265EB File Offset: 0x003247EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildSettingChanged>(stream);
		}

		// Token: 0x0600D6A2 RID: 54946 RVA: 0x003265FA File Offset: 0x003247FA
		public override void Process()
		{
			Process_PtcG2C_GuildSettingChangedNotify.Process(this);
		}

		// Token: 0x04006181 RID: 24961
		public GuildSettingChanged Data = new GuildSettingChanged();
	}
}
