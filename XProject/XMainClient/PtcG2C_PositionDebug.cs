using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010A0 RID: 4256
	internal class PtcG2C_PositionDebug : Protocol
	{
		// Token: 0x0600D741 RID: 55105 RVA: 0x00327A08 File Offset: 0x00325C08
		public override uint GetProtoType()
		{
			return 42493U;
		}

		// Token: 0x0600D742 RID: 55106 RVA: 0x00327A1F File Offset: 0x00325C1F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PositionCheckList>(stream, this.Data);
		}

		// Token: 0x0600D743 RID: 55107 RVA: 0x00327A2F File Offset: 0x00325C2F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PositionCheckList>(stream);
		}

		// Token: 0x0600D744 RID: 55108 RVA: 0x00327A3E File Offset: 0x00325C3E
		public override void Process()
		{
			Process_PtcG2C_PositionDebug.Process(this);
		}

		// Token: 0x040061A0 RID: 24992
		public PositionCheckList Data = new PositionCheckList();
	}
}
