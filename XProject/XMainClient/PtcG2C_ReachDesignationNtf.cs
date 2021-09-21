using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010FD RID: 4349
	internal class PtcG2C_ReachDesignationNtf : Protocol
	{
		// Token: 0x0600D8B2 RID: 55474 RVA: 0x00329EE8 File Offset: 0x003280E8
		public override uint GetProtoType()
		{
			return 17457U;
		}

		// Token: 0x0600D8B3 RID: 55475 RVA: 0x00329EFF File Offset: 0x003280FF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReachDesignationNtf>(stream, this.Data);
		}

		// Token: 0x0600D8B4 RID: 55476 RVA: 0x00329F0F File Offset: 0x0032810F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReachDesignationNtf>(stream);
		}

		// Token: 0x0600D8B5 RID: 55477 RVA: 0x00329F1E File Offset: 0x0032811E
		public override void Process()
		{
			Process_PtcG2C_ReachDesignationNtf.Process(this);
		}

		// Token: 0x040061E1 RID: 25057
		public ReachDesignationNtf Data = new ReachDesignationNtf();
	}
}
