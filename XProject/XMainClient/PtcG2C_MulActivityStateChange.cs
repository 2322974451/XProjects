using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001184 RID: 4484
	internal class PtcG2C_MulActivityStateChange : Protocol
	{
		// Token: 0x0600DADF RID: 56031 RVA: 0x0032E358 File Offset: 0x0032C558
		public override uint GetProtoType()
		{
			return 13448U;
		}

		// Token: 0x0600DAE0 RID: 56032 RVA: 0x0032E36F File Offset: 0x0032C56F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MulActivityCha>(stream, this.Data);
		}

		// Token: 0x0600DAE1 RID: 56033 RVA: 0x0032E37F File Offset: 0x0032C57F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MulActivityCha>(stream);
		}

		// Token: 0x0600DAE2 RID: 56034 RVA: 0x0032E38E File Offset: 0x0032C58E
		public override void Process()
		{
			Process_PtcG2C_MulActivityStateChange.Process(this);
		}

		// Token: 0x0400624C RID: 25164
		public MulActivityCha Data = new MulActivityCha();
	}
}
