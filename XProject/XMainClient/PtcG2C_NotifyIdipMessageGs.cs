using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200129D RID: 4765
	internal class PtcG2C_NotifyIdipMessageGs : Protocol
	{
		// Token: 0x0600DF56 RID: 57174 RVA: 0x00334798 File Offset: 0x00332998
		public override uint GetProtoType()
		{
			return 59353U;
		}

		// Token: 0x0600DF57 RID: 57175 RVA: 0x003347AF File Offset: 0x003329AF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IdipMessage>(stream, this.Data);
		}

		// Token: 0x0600DF58 RID: 57176 RVA: 0x003347BF File Offset: 0x003329BF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IdipMessage>(stream);
		}

		// Token: 0x0600DF59 RID: 57177 RVA: 0x003347CE File Offset: 0x003329CE
		public override void Process()
		{
			Process_PtcG2C_NotifyIdipMessageGs.Process(this);
		}

		// Token: 0x04006324 RID: 25380
		public IdipMessage Data = new IdipMessage();
	}
}
