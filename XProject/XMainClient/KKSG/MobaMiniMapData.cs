using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000438 RID: 1080
	[ProtoContract(Name = "MobaMiniMapData")]
	[Serializable]
	public class MobaMiniMapData : IExtensible
	{
		// Token: 0x17001185 RID: 4485
		// (get) Token: 0x06003910 RID: 14608 RVA: 0x0006D304 File Offset: 0x0006B504
		[ProtoMember(1, Name = "canSeePosIndex", DataFormat = DataFormat.TwosComplement)]
		public List<uint> canSeePosIndex
		{
			get
			{
				return this._canSeePosIndex;
			}
		}

		// Token: 0x06003911 RID: 14609 RVA: 0x0006D31C File Offset: 0x0006B51C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E29 RID: 3625
		private readonly List<uint> _canSeePosIndex = new List<uint>();

		// Token: 0x04000E2A RID: 3626
		private IExtension extensionObject;
	}
}
