using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000625 RID: 1573
	[ProtoContract(Name = "PayPrivilegeShop")]
	[Serializable]
	public class PayPrivilegeShop : IExtensible
	{
		// Token: 0x17001E56 RID: 7766
		// (get) Token: 0x0600606E RID: 24686 RVA: 0x000B7ED0 File Offset: 0x000B60D0
		// (set) Token: 0x0600606F RID: 24687 RVA: 0x000B7EFC File Offset: 0x000B60FC
		[ProtoMember(1, IsRequired = false, Name = "goodsID", DataFormat = DataFormat.TwosComplement)]
		public int goodsID
		{
			get
			{
				return this._goodsID ?? 0;
			}
			set
			{
				this._goodsID = new int?(value);
			}
		}

		// Token: 0x17001E57 RID: 7767
		// (get) Token: 0x06006070 RID: 24688 RVA: 0x000B7F0C File Offset: 0x000B610C
		// (set) Token: 0x06006071 RID: 24689 RVA: 0x000B7F2C File Offset: 0x000B612C
		[XmlIgnore]
		[Browsable(false)]
		public bool goodsIDSpecified
		{
			get
			{
				return this._goodsID != null;
			}
			set
			{
				bool flag = value == (this._goodsID == null);
				if (flag)
				{
					this._goodsID = (value ? new int?(this.goodsID) : null);
				}
			}
		}

		// Token: 0x06006072 RID: 24690 RVA: 0x000B7F70 File Offset: 0x000B6170
		private bool ShouldSerializegoodsID()
		{
			return this.goodsIDSpecified;
		}

		// Token: 0x06006073 RID: 24691 RVA: 0x000B7F88 File Offset: 0x000B6188
		private void ResetgoodsID()
		{
			this.goodsIDSpecified = false;
		}

		// Token: 0x17001E58 RID: 7768
		// (get) Token: 0x06006074 RID: 24692 RVA: 0x000B7F94 File Offset: 0x000B6194
		// (set) Token: 0x06006075 RID: 24693 RVA: 0x000B7FC0 File Offset: 0x000B61C0
		[ProtoMember(2, IsRequired = false, Name = "totalCount", DataFormat = DataFormat.TwosComplement)]
		public int totalCount
		{
			get
			{
				return this._totalCount ?? 0;
			}
			set
			{
				this._totalCount = new int?(value);
			}
		}

		// Token: 0x17001E59 RID: 7769
		// (get) Token: 0x06006076 RID: 24694 RVA: 0x000B7FD0 File Offset: 0x000B61D0
		// (set) Token: 0x06006077 RID: 24695 RVA: 0x000B7FF0 File Offset: 0x000B61F0
		[XmlIgnore]
		[Browsable(false)]
		public bool totalCountSpecified
		{
			get
			{
				return this._totalCount != null;
			}
			set
			{
				bool flag = value == (this._totalCount == null);
				if (flag)
				{
					this._totalCount = (value ? new int?(this.totalCount) : null);
				}
			}
		}

		// Token: 0x06006078 RID: 24696 RVA: 0x000B8034 File Offset: 0x000B6234
		private bool ShouldSerializetotalCount()
		{
			return this.totalCountSpecified;
		}

		// Token: 0x06006079 RID: 24697 RVA: 0x000B804C File Offset: 0x000B624C
		private void ResettotalCount()
		{
			this.totalCountSpecified = false;
		}

		// Token: 0x17001E5A RID: 7770
		// (get) Token: 0x0600607A RID: 24698 RVA: 0x000B8058 File Offset: 0x000B6258
		// (set) Token: 0x0600607B RID: 24699 RVA: 0x000B8084 File Offset: 0x000B6284
		[ProtoMember(3, IsRequired = false, Name = "usedCount", DataFormat = DataFormat.TwosComplement)]
		public int usedCount
		{
			get
			{
				return this._usedCount ?? 0;
			}
			set
			{
				this._usedCount = new int?(value);
			}
		}

		// Token: 0x17001E5B RID: 7771
		// (get) Token: 0x0600607C RID: 24700 RVA: 0x000B8094 File Offset: 0x000B6294
		// (set) Token: 0x0600607D RID: 24701 RVA: 0x000B80B4 File Offset: 0x000B62B4
		[XmlIgnore]
		[Browsable(false)]
		public bool usedCountSpecified
		{
			get
			{
				return this._usedCount != null;
			}
			set
			{
				bool flag = value == (this._usedCount == null);
				if (flag)
				{
					this._usedCount = (value ? new int?(this.usedCount) : null);
				}
			}
		}

		// Token: 0x0600607E RID: 24702 RVA: 0x000B80F8 File Offset: 0x000B62F8
		private bool ShouldSerializeusedCount()
		{
			return this.usedCountSpecified;
		}

		// Token: 0x0600607F RID: 24703 RVA: 0x000B8110 File Offset: 0x000B6310
		private void ResetusedCount()
		{
			this.usedCountSpecified = false;
		}

		// Token: 0x06006080 RID: 24704 RVA: 0x000B811C File Offset: 0x000B631C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001769 RID: 5993
		private int? _goodsID;

		// Token: 0x0400176A RID: 5994
		private int? _totalCount;

		// Token: 0x0400176B RID: 5995
		private int? _usedCount;

		// Token: 0x0400176C RID: 5996
		private IExtension extensionObject;
	}
}
