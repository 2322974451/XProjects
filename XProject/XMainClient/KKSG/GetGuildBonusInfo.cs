using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005BD RID: 1469
	[ProtoContract(Name = "GetGuildBonusInfo")]
	[Serializable]
	public class GetGuildBonusInfo : IExtensible
	{
		// Token: 0x17001964 RID: 6500
		// (get) Token: 0x06005225 RID: 21029 RVA: 0x0009C3AC File Offset: 0x0009A5AC
		// (set) Token: 0x06005226 RID: 21030 RVA: 0x0009C3D9 File Offset: 0x0009A5D9
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

		// Token: 0x17001965 RID: 6501
		// (get) Token: 0x06005227 RID: 21031 RVA: 0x0009C3E8 File Offset: 0x0009A5E8
		// (set) Token: 0x06005228 RID: 21032 RVA: 0x0009C408 File Offset: 0x0009A608
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

		// Token: 0x06005229 RID: 21033 RVA: 0x0009C44C File Offset: 0x0009A64C
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x0600522A RID: 21034 RVA: 0x0009C464 File Offset: 0x0009A664
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x17001966 RID: 6502
		// (get) Token: 0x0600522B RID: 21035 RVA: 0x0009C470 File Offset: 0x0009A670
		// (set) Token: 0x0600522C RID: 21036 RVA: 0x0009C491 File Offset: 0x0009A691
		[ProtoMember(2, IsRequired = false, Name = "roleName", DataFormat = DataFormat.Default)]
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

		// Token: 0x17001967 RID: 6503
		// (get) Token: 0x0600522D RID: 21037 RVA: 0x0009C49C File Offset: 0x0009A69C
		// (set) Token: 0x0600522E RID: 21038 RVA: 0x0009C4B8 File Offset: 0x0009A6B8
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

		// Token: 0x0600522F RID: 21039 RVA: 0x0009C4E8 File Offset: 0x0009A6E8
		private bool ShouldSerializeroleName()
		{
			return this.roleNameSpecified;
		}

		// Token: 0x06005230 RID: 21040 RVA: 0x0009C500 File Offset: 0x0009A700
		private void ResetroleName()
		{
			this.roleNameSpecified = false;
		}

		// Token: 0x17001968 RID: 6504
		// (get) Token: 0x06005231 RID: 21041 RVA: 0x0009C50C File Offset: 0x0009A70C
		// (set) Token: 0x06005232 RID: 21042 RVA: 0x0009C538 File Offset: 0x0009A738
		[ProtoMember(3, IsRequired = false, Name = "getNum", DataFormat = DataFormat.TwosComplement)]
		public uint getNum
		{
			get
			{
				return this._getNum ?? 0U;
			}
			set
			{
				this._getNum = new uint?(value);
			}
		}

		// Token: 0x17001969 RID: 6505
		// (get) Token: 0x06005233 RID: 21043 RVA: 0x0009C548 File Offset: 0x0009A748
		// (set) Token: 0x06005234 RID: 21044 RVA: 0x0009C568 File Offset: 0x0009A768
		[XmlIgnore]
		[Browsable(false)]
		public bool getNumSpecified
		{
			get
			{
				return this._getNum != null;
			}
			set
			{
				bool flag = value == (this._getNum == null);
				if (flag)
				{
					this._getNum = (value ? new uint?(this.getNum) : null);
				}
			}
		}

		// Token: 0x06005235 RID: 21045 RVA: 0x0009C5AC File Offset: 0x0009A7AC
		private bool ShouldSerializegetNum()
		{
			return this.getNumSpecified;
		}

		// Token: 0x06005236 RID: 21046 RVA: 0x0009C5C4 File Offset: 0x0009A7C4
		private void ResetgetNum()
		{
			this.getNumSpecified = false;
		}

		// Token: 0x1700196A RID: 6506
		// (get) Token: 0x06005237 RID: 21047 RVA: 0x0009C5D0 File Offset: 0x0009A7D0
		// (set) Token: 0x06005238 RID: 21048 RVA: 0x0009C5FC File Offset: 0x0009A7FC
		[ProtoMember(4, IsRequired = false, Name = "getTime", DataFormat = DataFormat.TwosComplement)]
		public uint getTime
		{
			get
			{
				return this._getTime ?? 0U;
			}
			set
			{
				this._getTime = new uint?(value);
			}
		}

		// Token: 0x1700196B RID: 6507
		// (get) Token: 0x06005239 RID: 21049 RVA: 0x0009C60C File Offset: 0x0009A80C
		// (set) Token: 0x0600523A RID: 21050 RVA: 0x0009C62C File Offset: 0x0009A82C
		[XmlIgnore]
		[Browsable(false)]
		public bool getTimeSpecified
		{
			get
			{
				return this._getTime != null;
			}
			set
			{
				bool flag = value == (this._getTime == null);
				if (flag)
				{
					this._getTime = (value ? new uint?(this.getTime) : null);
				}
			}
		}

		// Token: 0x0600523B RID: 21051 RVA: 0x0009C670 File Offset: 0x0009A870
		private bool ShouldSerializegetTime()
		{
			return this.getTimeSpecified;
		}

		// Token: 0x0600523C RID: 21052 RVA: 0x0009C688 File Offset: 0x0009A888
		private void ResetgetTime()
		{
			this.getTimeSpecified = false;
		}

		// Token: 0x1700196C RID: 6508
		// (get) Token: 0x0600523D RID: 21053 RVA: 0x0009C694 File Offset: 0x0009A894
		// (set) Token: 0x0600523E RID: 21054 RVA: 0x0009C6C0 File Offset: 0x0009A8C0
		[ProtoMember(5, IsRequired = false, Name = "canThank", DataFormat = DataFormat.Default)]
		public bool canThank
		{
			get
			{
				return this._canThank ?? false;
			}
			set
			{
				this._canThank = new bool?(value);
			}
		}

		// Token: 0x1700196D RID: 6509
		// (get) Token: 0x0600523F RID: 21055 RVA: 0x0009C6D0 File Offset: 0x0009A8D0
		// (set) Token: 0x06005240 RID: 21056 RVA: 0x0009C6F0 File Offset: 0x0009A8F0
		[XmlIgnore]
		[Browsable(false)]
		public bool canThankSpecified
		{
			get
			{
				return this._canThank != null;
			}
			set
			{
				bool flag = value == (this._canThank == null);
				if (flag)
				{
					this._canThank = (value ? new bool?(this.canThank) : null);
				}
			}
		}

		// Token: 0x06005241 RID: 21057 RVA: 0x0009C734 File Offset: 0x0009A934
		private bool ShouldSerializecanThank()
		{
			return this.canThankSpecified;
		}

		// Token: 0x06005242 RID: 21058 RVA: 0x0009C74C File Offset: 0x0009A94C
		private void ResetcanThank()
		{
			this.canThankSpecified = false;
		}

		// Token: 0x06005243 RID: 21059 RVA: 0x0009C758 File Offset: 0x0009A958
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001416 RID: 5142
		private ulong? _roleID;

		// Token: 0x04001417 RID: 5143
		private string _roleName;

		// Token: 0x04001418 RID: 5144
		private uint? _getNum;

		// Token: 0x04001419 RID: 5145
		private uint? _getTime;

		// Token: 0x0400141A RID: 5146
		private bool? _canThank;

		// Token: 0x0400141B RID: 5147
		private IExtension extensionObject;
	}
}
