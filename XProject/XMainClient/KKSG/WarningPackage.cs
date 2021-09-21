using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200072A RID: 1834
	[ProtoContract(Name = "WarningPackage")]
	[Serializable]
	public class WarningPackage : IExtensible
	{
		// Token: 0x1700280F RID: 10255
		// (get) Token: 0x06007E5C RID: 32348 RVA: 0x000F19E0 File Offset: 0x000EFBE0
		[ProtoMember(1, Name = "WarningPos", DataFormat = DataFormat.TwosComplement)]
		public List<uint> WarningPos
		{
			get
			{
				return this._WarningPos;
			}
		}

		// Token: 0x17002810 RID: 10256
		// (get) Token: 0x06007E5D RID: 32349 RVA: 0x000F19F8 File Offset: 0x000EFBF8
		// (set) Token: 0x06007E5E RID: 32350 RVA: 0x000F1A10 File Offset: 0x000EFC10
		[ProtoMember(2, IsRequired = true, Name = "ID", DataFormat = DataFormat.TwosComplement)]
		public ulong ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				this._ID = value;
			}
		}

		// Token: 0x06007E5F RID: 32351 RVA: 0x000F1A1C File Offset: 0x000EFC1C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DAF RID: 7599
		private readonly List<uint> _WarningPos = new List<uint>();

		// Token: 0x04001DB0 RID: 7600
		private ulong _ID;

		// Token: 0x04001DB1 RID: 7601
		private IExtension extensionObject;
	}
}
