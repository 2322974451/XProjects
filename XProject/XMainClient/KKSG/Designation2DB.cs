using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000651 RID: 1617
	[ProtoContract(Name = "Designation2DB")]
	[Serializable]
	public class Designation2DB : IExtensible
	{
		// Token: 0x17001FBA RID: 8122
		// (get) Token: 0x06006494 RID: 25748 RVA: 0x000BFFAC File Offset: 0x000BE1AC
		// (set) Token: 0x06006495 RID: 25749 RVA: 0x000BFFD8 File Offset: 0x000BE1D8
		[ProtoMember(1, IsRequired = false, Name = "coverDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint coverDesignationID
		{
			get
			{
				return this._coverDesignationID ?? 0U;
			}
			set
			{
				this._coverDesignationID = new uint?(value);
			}
		}

		// Token: 0x17001FBB RID: 8123
		// (get) Token: 0x06006496 RID: 25750 RVA: 0x000BFFE8 File Offset: 0x000BE1E8
		// (set) Token: 0x06006497 RID: 25751 RVA: 0x000C0008 File Offset: 0x000BE208
		[XmlIgnore]
		[Browsable(false)]
		public bool coverDesignationIDSpecified
		{
			get
			{
				return this._coverDesignationID != null;
			}
			set
			{
				bool flag = value == (this._coverDesignationID == null);
				if (flag)
				{
					this._coverDesignationID = (value ? new uint?(this.coverDesignationID) : null);
				}
			}
		}

		// Token: 0x06006498 RID: 25752 RVA: 0x000C004C File Offset: 0x000BE24C
		private bool ShouldSerializecoverDesignationID()
		{
			return this.coverDesignationIDSpecified;
		}

		// Token: 0x06006499 RID: 25753 RVA: 0x000C0064 File Offset: 0x000BE264
		private void ResetcoverDesignationID()
		{
			this.coverDesignationIDSpecified = false;
		}

		// Token: 0x17001FBC RID: 8124
		// (get) Token: 0x0600649A RID: 25754 RVA: 0x000C0070 File Offset: 0x000BE270
		// (set) Token: 0x0600649B RID: 25755 RVA: 0x000C009C File Offset: 0x000BE29C
		[ProtoMember(2, IsRequired = false, Name = "abilityDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint abilityDesignationID
		{
			get
			{
				return this._abilityDesignationID ?? 0U;
			}
			set
			{
				this._abilityDesignationID = new uint?(value);
			}
		}

		// Token: 0x17001FBD RID: 8125
		// (get) Token: 0x0600649C RID: 25756 RVA: 0x000C00AC File Offset: 0x000BE2AC
		// (set) Token: 0x0600649D RID: 25757 RVA: 0x000C00CC File Offset: 0x000BE2CC
		[XmlIgnore]
		[Browsable(false)]
		public bool abilityDesignationIDSpecified
		{
			get
			{
				return this._abilityDesignationID != null;
			}
			set
			{
				bool flag = value == (this._abilityDesignationID == null);
				if (flag)
				{
					this._abilityDesignationID = (value ? new uint?(this.abilityDesignationID) : null);
				}
			}
		}

		// Token: 0x0600649E RID: 25758 RVA: 0x000C0110 File Offset: 0x000BE310
		private bool ShouldSerializeabilityDesignationID()
		{
			return this.abilityDesignationIDSpecified;
		}

		// Token: 0x0600649F RID: 25759 RVA: 0x000C0128 File Offset: 0x000BE328
		private void ResetabilityDesignationID()
		{
			this.abilityDesignationIDSpecified = false;
		}

		// Token: 0x17001FBE RID: 8126
		// (get) Token: 0x060064A0 RID: 25760 RVA: 0x000C0134 File Offset: 0x000BE334
		// (set) Token: 0x060064A1 RID: 25761 RVA: 0x000C0160 File Offset: 0x000BE360
		[ProtoMember(3, IsRequired = false, Name = "maxAbilityDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint maxAbilityDesignationID
		{
			get
			{
				return this._maxAbilityDesignationID ?? 0U;
			}
			set
			{
				this._maxAbilityDesignationID = new uint?(value);
			}
		}

		// Token: 0x17001FBF RID: 8127
		// (get) Token: 0x060064A2 RID: 25762 RVA: 0x000C0170 File Offset: 0x000BE370
		// (set) Token: 0x060064A3 RID: 25763 RVA: 0x000C0190 File Offset: 0x000BE390
		[XmlIgnore]
		[Browsable(false)]
		public bool maxAbilityDesignationIDSpecified
		{
			get
			{
				return this._maxAbilityDesignationID != null;
			}
			set
			{
				bool flag = value == (this._maxAbilityDesignationID == null);
				if (flag)
				{
					this._maxAbilityDesignationID = (value ? new uint?(this.maxAbilityDesignationID) : null);
				}
			}
		}

		// Token: 0x060064A4 RID: 25764 RVA: 0x000C01D4 File Offset: 0x000BE3D4
		private bool ShouldSerializemaxAbilityDesignationID()
		{
			return this.maxAbilityDesignationIDSpecified;
		}

		// Token: 0x060064A5 RID: 25765 RVA: 0x000C01EC File Offset: 0x000BE3EC
		private void ResetmaxAbilityDesignationID()
		{
			this.maxAbilityDesignationIDSpecified = false;
		}

		// Token: 0x17001FC0 RID: 8128
		// (get) Token: 0x060064A6 RID: 25766 RVA: 0x000C01F8 File Offset: 0x000BE3F8
		[ProtoMember(4, Name = "designationData", DataFormat = DataFormat.Default)]
		public List<StcDesignationInfo> designationData
		{
			get
			{
				return this._designationData;
			}
		}

		// Token: 0x060064A7 RID: 25767 RVA: 0x000C0210 File Offset: 0x000BE410
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001863 RID: 6243
		private uint? _coverDesignationID;

		// Token: 0x04001864 RID: 6244
		private uint? _abilityDesignationID;

		// Token: 0x04001865 RID: 6245
		private uint? _maxAbilityDesignationID;

		// Token: 0x04001866 RID: 6246
		private readonly List<StcDesignationInfo> _designationData = new List<StcDesignationInfo>();

		// Token: 0x04001867 RID: 6247
		private IExtension extensionObject;
	}
}
