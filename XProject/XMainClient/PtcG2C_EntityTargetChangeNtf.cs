using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200153D RID: 5437
	internal class PtcG2C_EntityTargetChangeNtf : Protocol
	{
		// Token: 0x0600EA0B RID: 59915 RVA: 0x00343A2C File Offset: 0x00341C2C
		public override uint GetProtoType()
		{
			return 9303U;
		}

		// Token: 0x0600EA0C RID: 59916 RVA: 0x00343A43 File Offset: 0x00341C43
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EntityTargetData>(stream, this.Data);
		}

		// Token: 0x0600EA0D RID: 59917 RVA: 0x00343A53 File Offset: 0x00341C53
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<EntityTargetData>(stream);
		}

		// Token: 0x0600EA0E RID: 59918 RVA: 0x00343A62 File Offset: 0x00341C62
		public override void Process()
		{
			Process_PtcG2C_EntityTargetChangeNtf.Process(this);
		}

		// Token: 0x0400652E RID: 25902
		public EntityTargetData Data = new EntityTargetData();
	}
}
