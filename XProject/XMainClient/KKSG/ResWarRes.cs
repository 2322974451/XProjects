using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002A4 RID: 676
	[ProtoContract(Name = "ResWarRes")]
	[Serializable]
	public class ResWarRes : IExtensible
	{
		// Token: 0x17000BC3 RID: 3011
		// (get) Token: 0x060025D1 RID: 9681 RVA: 0x00049A78 File Offset: 0x00047C78
		// (set) Token: 0x060025D2 RID: 9682 RVA: 0x00049A90 File Offset: 0x00047C90
		[ProtoMember(1, IsRequired = false, Name = "baseinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ResWarAllTeamBaseInfo baseinfo
		{
			get
			{
				return this._baseinfo;
			}
			set
			{
				this._baseinfo = value;
			}
		}

		// Token: 0x17000BC4 RID: 3012
		// (get) Token: 0x060025D3 RID: 9683 RVA: 0x00049A9C File Offset: 0x00047C9C
		// (set) Token: 0x060025D4 RID: 9684 RVA: 0x00049AB4 File Offset: 0x00047CB4
		[ProtoMember(2, IsRequired = false, Name = "allinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ResWarAllInfo allinfo
		{
			get
			{
				return this._allinfo;
			}
			set
			{
				this._allinfo = value;
			}
		}

		// Token: 0x060025D5 RID: 9685 RVA: 0x00049AC0 File Offset: 0x00047CC0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400095D RID: 2397
		private ResWarAllTeamBaseInfo _baseinfo = null;

		// Token: 0x0400095E RID: 2398
		private ResWarAllInfo _allinfo = null;

		// Token: 0x0400095F RID: 2399
		private IExtension extensionObject;
	}
}
