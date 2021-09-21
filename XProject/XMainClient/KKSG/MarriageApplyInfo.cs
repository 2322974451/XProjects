using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000727 RID: 1831
	[ProtoContract(Name = "MarriageApplyInfo")]
	[Serializable]
	public class MarriageApplyInfo : IExtensible
	{
		// Token: 0x17002802 RID: 10242
		// (get) Token: 0x06007E31 RID: 32305 RVA: 0x000F14F8 File Offset: 0x000EF6F8
		// (set) Token: 0x06007E32 RID: 32306 RVA: 0x000F1525 File Offset: 0x000EF725
		[ProtoMember(1, IsRequired = false, Name = "applyRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong applyRoleID
		{
			get
			{
				return this._applyRoleID ?? 0UL;
			}
			set
			{
				this._applyRoleID = new ulong?(value);
			}
		}

		// Token: 0x17002803 RID: 10243
		// (get) Token: 0x06007E33 RID: 32307 RVA: 0x000F1534 File Offset: 0x000EF734
		// (set) Token: 0x06007E34 RID: 32308 RVA: 0x000F1554 File Offset: 0x000EF754
		[XmlIgnore]
		[Browsable(false)]
		public bool applyRoleIDSpecified
		{
			get
			{
				return this._applyRoleID != null;
			}
			set
			{
				bool flag = value == (this._applyRoleID == null);
				if (flag)
				{
					this._applyRoleID = (value ? new ulong?(this.applyRoleID) : null);
				}
			}
		}

		// Token: 0x06007E35 RID: 32309 RVA: 0x000F1598 File Offset: 0x000EF798
		private bool ShouldSerializeapplyRoleID()
		{
			return this.applyRoleIDSpecified;
		}

		// Token: 0x06007E36 RID: 32310 RVA: 0x000F15B0 File Offset: 0x000EF7B0
		private void ResetapplyRoleID()
		{
			this.applyRoleIDSpecified = false;
		}

		// Token: 0x17002804 RID: 10244
		// (get) Token: 0x06007E37 RID: 32311 RVA: 0x000F15BC File Offset: 0x000EF7BC
		// (set) Token: 0x06007E38 RID: 32312 RVA: 0x000F15DD File Offset: 0x000EF7DD
		[ProtoMember(2, IsRequired = false, Name = "applyName", DataFormat = DataFormat.Default)]
		public string applyName
		{
			get
			{
				return this._applyName ?? "";
			}
			set
			{
				this._applyName = value;
			}
		}

		// Token: 0x17002805 RID: 10245
		// (get) Token: 0x06007E39 RID: 32313 RVA: 0x000F15E8 File Offset: 0x000EF7E8
		// (set) Token: 0x06007E3A RID: 32314 RVA: 0x000F1604 File Offset: 0x000EF804
		[XmlIgnore]
		[Browsable(false)]
		public bool applyNameSpecified
		{
			get
			{
				return this._applyName != null;
			}
			set
			{
				bool flag = value == (this._applyName == null);
				if (flag)
				{
					this._applyName = (value ? this.applyName : null);
				}
			}
		}

		// Token: 0x06007E3B RID: 32315 RVA: 0x000F1634 File Offset: 0x000EF834
		private bool ShouldSerializeapplyName()
		{
			return this.applyNameSpecified;
		}

		// Token: 0x06007E3C RID: 32316 RVA: 0x000F164C File Offset: 0x000EF84C
		private void ResetapplyName()
		{
			this.applyNameSpecified = false;
		}

		// Token: 0x17002806 RID: 10246
		// (get) Token: 0x06007E3D RID: 32317 RVA: 0x000F1658 File Offset: 0x000EF858
		// (set) Token: 0x06007E3E RID: 32318 RVA: 0x000F1684 File Offset: 0x000EF884
		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeddingType type
		{
			get
			{
				return this._type ?? WeddingType.WeddingType_Normal;
			}
			set
			{
				this._type = new WeddingType?(value);
			}
		}

		// Token: 0x17002807 RID: 10247
		// (get) Token: 0x06007E3F RID: 32319 RVA: 0x000F1694 File Offset: 0x000EF894
		// (set) Token: 0x06007E40 RID: 32320 RVA: 0x000F16B4 File Offset: 0x000EF8B4
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new WeddingType?(this.type) : null);
				}
			}
		}

		// Token: 0x06007E41 RID: 32321 RVA: 0x000F16F8 File Offset: 0x000EF8F8
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06007E42 RID: 32322 RVA: 0x000F1710 File Offset: 0x000EF910
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06007E43 RID: 32323 RVA: 0x000F171C File Offset: 0x000EF91C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DA5 RID: 7589
		private ulong? _applyRoleID;

		// Token: 0x04001DA6 RID: 7590
		private string _applyName;

		// Token: 0x04001DA7 RID: 7591
		private WeddingType? _type;

		// Token: 0x04001DA8 RID: 7592
		private IExtension extensionObject;
	}
}
