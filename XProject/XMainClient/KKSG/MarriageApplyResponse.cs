using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000728 RID: 1832
	[ProtoContract(Name = "MarriageApplyResponse")]
	[Serializable]
	public class MarriageApplyResponse : IExtensible
	{
		// Token: 0x17002808 RID: 10248
		// (get) Token: 0x06007E45 RID: 32325 RVA: 0x000F173C File Offset: 0x000EF93C
		// (set) Token: 0x06007E46 RID: 32326 RVA: 0x000F1768 File Offset: 0x000EF968
		[ProtoMember(1, IsRequired = false, Name = "isAgree", DataFormat = DataFormat.Default)]
		public bool isAgree
		{
			get
			{
				return this._isAgree ?? false;
			}
			set
			{
				this._isAgree = new bool?(value);
			}
		}

		// Token: 0x17002809 RID: 10249
		// (get) Token: 0x06007E47 RID: 32327 RVA: 0x000F1778 File Offset: 0x000EF978
		// (set) Token: 0x06007E48 RID: 32328 RVA: 0x000F1798 File Offset: 0x000EF998
		[XmlIgnore]
		[Browsable(false)]
		public bool isAgreeSpecified
		{
			get
			{
				return this._isAgree != null;
			}
			set
			{
				bool flag = value == (this._isAgree == null);
				if (flag)
				{
					this._isAgree = (value ? new bool?(this.isAgree) : null);
				}
			}
		}

		// Token: 0x06007E49 RID: 32329 RVA: 0x000F17DC File Offset: 0x000EF9DC
		private bool ShouldSerializeisAgree()
		{
			return this.isAgreeSpecified;
		}

		// Token: 0x06007E4A RID: 32330 RVA: 0x000F17F4 File Offset: 0x000EF9F4
		private void ResetisAgree()
		{
			this.isAgreeSpecified = false;
		}

		// Token: 0x1700280A RID: 10250
		// (get) Token: 0x06007E4B RID: 32331 RVA: 0x000F1800 File Offset: 0x000EFA00
		// (set) Token: 0x06007E4C RID: 32332 RVA: 0x000F182D File Offset: 0x000EFA2D
		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700280B RID: 10251
		// (get) Token: 0x06007E4D RID: 32333 RVA: 0x000F183C File Offset: 0x000EFA3C
		// (set) Token: 0x06007E4E RID: 32334 RVA: 0x000F185C File Offset: 0x000EFA5C
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

		// Token: 0x06007E4F RID: 32335 RVA: 0x000F18A0 File Offset: 0x000EFAA0
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06007E50 RID: 32336 RVA: 0x000F18B8 File Offset: 0x000EFAB8
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x1700280C RID: 10252
		// (get) Token: 0x06007E51 RID: 32337 RVA: 0x000F18C4 File Offset: 0x000EFAC4
		// (set) Token: 0x06007E52 RID: 32338 RVA: 0x000F18E5 File Offset: 0x000EFAE5
		[ProtoMember(3, IsRequired = false, Name = "roleName", DataFormat = DataFormat.Default)]
		public string roleName
		{
			get
			{
				return this._roleName ?? "";
			}
			set
			{
				this._roleName = value;
			}
		}

		// Token: 0x1700280D RID: 10253
		// (get) Token: 0x06007E53 RID: 32339 RVA: 0x000F18F0 File Offset: 0x000EFAF0
		// (set) Token: 0x06007E54 RID: 32340 RVA: 0x000F190C File Offset: 0x000EFB0C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleNameSpecified
		{
			get
			{
				return this._roleName != null;
			}
			set
			{
				bool flag = value == (this._roleName == null);
				if (flag)
				{
					this._roleName = (value ? this.roleName : null);
				}
			}
		}

		// Token: 0x06007E55 RID: 32341 RVA: 0x000F193C File Offset: 0x000EFB3C
		private bool ShouldSerializeroleName()
		{
			return this.roleNameSpecified;
		}

		// Token: 0x06007E56 RID: 32342 RVA: 0x000F1954 File Offset: 0x000EFB54
		private void ResetroleName()
		{
			this.roleNameSpecified = false;
		}

		// Token: 0x06007E57 RID: 32343 RVA: 0x000F1960 File Offset: 0x000EFB60
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DA9 RID: 7593
		private bool? _isAgree;

		// Token: 0x04001DAA RID: 7594
		private ulong? _roleID;

		// Token: 0x04001DAB RID: 7595
		private string _roleName;

		// Token: 0x04001DAC RID: 7596
		private IExtension extensionObject;
	}
}
