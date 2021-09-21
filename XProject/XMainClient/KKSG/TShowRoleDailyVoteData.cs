using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200060A RID: 1546
	[ProtoContract(Name = "TShowRoleDailyVoteData")]
	[Serializable]
	public class TShowRoleDailyVoteData : IExtensible
	{
		// Token: 0x17001D34 RID: 7476
		// (get) Token: 0x06005D27 RID: 23847 RVA: 0x000B1808 File Offset: 0x000AFA08
		// (set) Token: 0x06005D28 RID: 23848 RVA: 0x000B1835 File Offset: 0x000AFA35
		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x17001D35 RID: 7477
		// (get) Token: 0x06005D29 RID: 23849 RVA: 0x000B1844 File Offset: 0x000AFA44
		// (set) Token: 0x06005D2A RID: 23850 RVA: 0x000B1864 File Offset: 0x000AFA64
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x06005D2B RID: 23851 RVA: 0x000B18A8 File Offset: 0x000AFAA8
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06005D2C RID: 23852 RVA: 0x000B18C0 File Offset: 0x000AFAC0
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x17001D36 RID: 7478
		// (get) Token: 0x06005D2D RID: 23853 RVA: 0x000B18CC File Offset: 0x000AFACC
		// (set) Token: 0x06005D2E RID: 23854 RVA: 0x000B18F8 File Offset: 0x000AFAF8
		[ProtoMember(2, IsRequired = false, Name = "freeCount", DataFormat = DataFormat.TwosComplement)]
		public int freeCount
		{
			get
			{
				return this._freeCount ?? 0;
			}
			set
			{
				this._freeCount = new int?(value);
			}
		}

		// Token: 0x17001D37 RID: 7479
		// (get) Token: 0x06005D2F RID: 23855 RVA: 0x000B1908 File Offset: 0x000AFB08
		// (set) Token: 0x06005D30 RID: 23856 RVA: 0x000B1928 File Offset: 0x000AFB28
		[XmlIgnore]
		[Browsable(false)]
		public bool freeCountSpecified
		{
			get
			{
				return this._freeCount != null;
			}
			set
			{
				bool flag = value == (this._freeCount == null);
				if (flag)
				{
					this._freeCount = (value ? new int?(this.freeCount) : null);
				}
			}
		}

		// Token: 0x06005D31 RID: 23857 RVA: 0x000B196C File Offset: 0x000AFB6C
		private bool ShouldSerializefreeCount()
		{
			return this.freeCountSpecified;
		}

		// Token: 0x06005D32 RID: 23858 RVA: 0x000B1984 File Offset: 0x000AFB84
		private void ResetfreeCount()
		{
			this.freeCountSpecified = false;
		}

		// Token: 0x17001D38 RID: 7480
		// (get) Token: 0x06005D33 RID: 23859 RVA: 0x000B1990 File Offset: 0x000AFB90
		// (set) Token: 0x06005D34 RID: 23860 RVA: 0x000B19BC File Offset: 0x000AFBBC
		[ProtoMember(3, IsRequired = false, Name = "costCount", DataFormat = DataFormat.TwosComplement)]
		public int costCount
		{
			get
			{
				return this._costCount ?? 0;
			}
			set
			{
				this._costCount = new int?(value);
			}
		}

		// Token: 0x17001D39 RID: 7481
		// (get) Token: 0x06005D35 RID: 23861 RVA: 0x000B19CC File Offset: 0x000AFBCC
		// (set) Token: 0x06005D36 RID: 23862 RVA: 0x000B19EC File Offset: 0x000AFBEC
		[XmlIgnore]
		[Browsable(false)]
		public bool costCountSpecified
		{
			get
			{
				return this._costCount != null;
			}
			set
			{
				bool flag = value == (this._costCount == null);
				if (flag)
				{
					this._costCount = (value ? new int?(this.costCount) : null);
				}
			}
		}

		// Token: 0x06005D37 RID: 23863 RVA: 0x000B1A30 File Offset: 0x000AFC30
		private bool ShouldSerializecostCount()
		{
			return this.costCountSpecified;
		}

		// Token: 0x06005D38 RID: 23864 RVA: 0x000B1A48 File Offset: 0x000AFC48
		private void ResetcostCount()
		{
			this.costCountSpecified = false;
		}

		// Token: 0x06005D39 RID: 23865 RVA: 0x000B1A54 File Offset: 0x000AFC54
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016A5 RID: 5797
		private ulong? _roleID;

		// Token: 0x040016A6 RID: 5798
		private int? _freeCount;

		// Token: 0x040016A7 RID: 5799
		private int? _costCount;

		// Token: 0x040016A8 RID: 5800
		private IExtension extensionObject;
	}
}
