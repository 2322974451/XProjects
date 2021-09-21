using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200162C RID: 5676
	internal class PtcM2C_DragonGuildSettingChanged : Protocol
	{
		// Token: 0x0600EDEE RID: 60910 RVA: 0x003490CC File Offset: 0x003472CC
		public override uint GetProtoType()
		{
			return 42603U;
		}

		// Token: 0x0600EDEF RID: 60911 RVA: 0x003490E3 File Offset: 0x003472E3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildSettingChanged>(stream, this.Data);
		}

		// Token: 0x0600EDF0 RID: 60912 RVA: 0x003490F3 File Offset: 0x003472F3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DragonGuildSettingChanged>(stream);
		}

		// Token: 0x0600EDF1 RID: 60913 RVA: 0x00349102 File Offset: 0x00347302
		public override void Process()
		{
			Process_PtcM2C_DragonGuildSettingChanged.Process(this);
		}

		// Token: 0x040065F8 RID: 26104
		public DragonGuildSettingChanged Data = new DragonGuildSettingChanged();
	}
}
