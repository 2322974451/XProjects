using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010A8 RID: 4264
	internal class PtcG2C_BuffNotify : Protocol
	{
		// Token: 0x0600D75F RID: 55135 RVA: 0x00327C94 File Offset: 0x00325E94
		public override uint GetProtoType()
		{
			return 18520U;
		}

		// Token: 0x0600D760 RID: 55136 RVA: 0x00327CAB File Offset: 0x00325EAB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<buffInfo>(stream, this.Data);
		}

		// Token: 0x0600D761 RID: 55137 RVA: 0x00327CBB File Offset: 0x00325EBB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<buffInfo>(stream);
		}

		// Token: 0x0600D762 RID: 55138 RVA: 0x00327CCA File Offset: 0x00325ECA
		public override void Process()
		{
			Process_PtcG2C_BuffNotify.Process(this);
		}

		// Token: 0x040061A5 RID: 24997
		public buffInfo Data = new buffInfo();
	}
}
