using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001055 RID: 4181
	internal class PtcG2C_LeaveTeam : Protocol
	{
		// Token: 0x0600D60D RID: 54797 RVA: 0x0032573C File Offset: 0x0032393C
		public override uint GetProtoType()
		{
			return 47730U;
		}

		// Token: 0x0600D60E RID: 54798 RVA: 0x00325753 File Offset: 0x00323953
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ErrorInfo>(stream, this.Data);
		}

		// Token: 0x0600D60F RID: 54799 RVA: 0x00325763 File Offset: 0x00323963
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ErrorInfo>(stream);
		}

		// Token: 0x0600D610 RID: 54800 RVA: 0x00325772 File Offset: 0x00323972
		public override void Process()
		{
			Process_PtcG2C_LeaveTeam.Process(this);
		}

		// Token: 0x04006160 RID: 24928
		public ErrorInfo Data = new ErrorInfo();
	}
}
