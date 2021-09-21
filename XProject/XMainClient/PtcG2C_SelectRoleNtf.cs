using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001148 RID: 4424
	internal class PtcG2C_SelectRoleNtf : Protocol
	{
		// Token: 0x0600D9EB RID: 55787 RVA: 0x0032BF14 File Offset: 0x0032A114
		public override uint GetProtoType()
		{
			return 19493U;
		}

		// Token: 0x0600D9EC RID: 55788 RVA: 0x0032BF2B File Offset: 0x0032A12B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SelectRoleNtfData>(stream, this.Data);
		}

		// Token: 0x0600D9ED RID: 55789 RVA: 0x0032BF3B File Offset: 0x0032A13B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SelectRoleNtfData>(stream);
		}

		// Token: 0x0600D9EE RID: 55790 RVA: 0x0032BF4A File Offset: 0x0032A14A
		public override void Process()
		{
			Process_PtcG2C_SelectRoleNtf.Process(this);
		}

		// Token: 0x0400621D RID: 25117
		public SelectRoleNtfData Data = new SelectRoleNtfData();
	}
}
