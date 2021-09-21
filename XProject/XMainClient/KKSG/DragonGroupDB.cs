using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000672 RID: 1650
	[ProtoContract(Name = "DragonGroupDB")]
	[Serializable]
	public class DragonGroupDB : IExtensible
	{
		// Token: 0x17002135 RID: 8501
		// (get) Token: 0x06006904 RID: 26884 RVA: 0x000C8C2C File Offset: 0x000C6E2C
		// (set) Token: 0x06006905 RID: 26885 RVA: 0x000C8C44 File Offset: 0x000C6E44
		[ProtoMember(1, IsRequired = false, Name = "record", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DragonGroupRecordS2C record
		{
			get
			{
				return this._record;
			}
			set
			{
				this._record = value;
			}
		}

		// Token: 0x17002136 RID: 8502
		// (get) Token: 0x06006906 RID: 26886 RVA: 0x000C8C50 File Offset: 0x000C6E50
		// (set) Token: 0x06006907 RID: 26887 RVA: 0x000C8C68 File Offset: 0x000C6E68
		[ProtoMember(2, IsRequired = false, Name = "rolelist", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DragonGroupRoleListS2C rolelist
		{
			get
			{
				return this._rolelist;
			}
			set
			{
				this._rolelist = value;
			}
		}

		// Token: 0x06006908 RID: 26888 RVA: 0x000C8C74 File Offset: 0x000C6E74
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001954 RID: 6484
		private DragonGroupRecordS2C _record = null;

		// Token: 0x04001955 RID: 6485
		private DragonGroupRoleListS2C _rolelist = null;

		// Token: 0x04001956 RID: 6486
		private IExtension extensionObject;
	}
}
