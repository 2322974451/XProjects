using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001066 RID: 4198
	internal class PtcG2C_EnterSceneCoolDownNotify : Protocol
	{
		// Token: 0x0600D651 RID: 54865 RVA: 0x00325EC0 File Offset: 0x003240C0
		public override uint GetProtoType()
		{
			return 38664U;
		}

		// Token: 0x0600D652 RID: 54866 RVA: 0x00325ED7 File Offset: 0x003240D7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterSceneCoolDownNotify>(stream, this.Data);
		}

		// Token: 0x0600D653 RID: 54867 RVA: 0x00325EE7 File Offset: 0x003240E7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<EnterSceneCoolDownNotify>(stream);
		}

		// Token: 0x0600D654 RID: 54868 RVA: 0x00325EF6 File Offset: 0x003240F6
		public override void Process()
		{
			Process_PtcG2C_EnterSceneCoolDownNotify.Process(this);
		}

		// Token: 0x04006172 RID: 24946
		public EnterSceneCoolDownNotify Data = new EnterSceneCoolDownNotify();
	}
}
