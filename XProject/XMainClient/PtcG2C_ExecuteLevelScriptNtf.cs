using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001090 RID: 4240
	internal class PtcG2C_ExecuteLevelScriptNtf : Protocol
	{
		// Token: 0x0600D700 RID: 55040 RVA: 0x0032709C File Offset: 0x0032529C
		public override uint GetProtoType()
		{
			return 47978U;
		}

		// Token: 0x0600D701 RID: 55041 RVA: 0x003270B3 File Offset: 0x003252B3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ExecuteLevelScriptNtf>(stream, this.Data);
		}

		// Token: 0x0600D702 RID: 55042 RVA: 0x003270C3 File Offset: 0x003252C3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ExecuteLevelScriptNtf>(stream);
		}

		// Token: 0x0600D703 RID: 55043 RVA: 0x003270D2 File Offset: 0x003252D2
		public override void Process()
		{
			Process_PtcG2C_ExecuteLevelScriptNtf.Process(this);
		}

		// Token: 0x04006194 RID: 24980
		public ExecuteLevelScriptNtf Data = new ExecuteLevelScriptNtf();
	}
}
