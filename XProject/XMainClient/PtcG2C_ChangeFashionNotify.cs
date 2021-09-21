using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001033 RID: 4147
	internal class PtcG2C_ChangeFashionNotify : Protocol
	{
		// Token: 0x0600D579 RID: 54649 RVA: 0x003242A8 File Offset: 0x003224A8
		public override uint GetProtoType()
		{
			return 1731U;
		}

		// Token: 0x0600D57A RID: 54650 RVA: 0x003242BF File Offset: 0x003224BF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FashionChanged>(stream, this.Data);
		}

		// Token: 0x0600D57B RID: 54651 RVA: 0x003242CF File Offset: 0x003224CF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FashionChanged>(stream);
		}

		// Token: 0x0600D57C RID: 54652 RVA: 0x003242DE File Offset: 0x003224DE
		public override void Process()
		{
			Process_PtcG2C_ChangeFashionNotify.Process(this);
		}

		// Token: 0x04006124 RID: 24868
		public FashionChanged Data = new FashionChanged();
	}
}
