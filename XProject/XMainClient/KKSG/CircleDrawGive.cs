using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000E5 RID: 229
	[ProtoContract(Name = "CircleDrawGive")]
	[Serializable]
	public class CircleDrawGive : IExtensible
	{
		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06000EC4 RID: 3780 RVA: 0x0001E900 File Offset: 0x0001CB00
		// (set) Token: 0x06000EC5 RID: 3781 RVA: 0x0001E92C File Offset: 0x0001CB2C
		[ProtoMember(1, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x06000EC6 RID: 3782 RVA: 0x0001E93C File Offset: 0x0001CB3C
		// (set) Token: 0x06000EC7 RID: 3783 RVA: 0x0001E95C File Offset: 0x0001CB5C
		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		// Token: 0x06000EC8 RID: 3784 RVA: 0x0001E9A0 File Offset: 0x0001CBA0
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x0001E9B8 File Offset: 0x0001CBB8
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06000ECA RID: 3786 RVA: 0x0001E9C4 File Offset: 0x0001CBC4
		// (set) Token: 0x06000ECB RID: 3787 RVA: 0x0001E9F0 File Offset: 0x0001CBF0
		[ProtoMember(2, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06000ECC RID: 3788 RVA: 0x0001EA00 File Offset: 0x0001CC00
		// (set) Token: 0x06000ECD RID: 3789 RVA: 0x0001EA20 File Offset: 0x0001CC20
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x0001EA64 File Offset: 0x0001CC64
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x0001EA7C File Offset: 0x0001CC7C
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x06000ED0 RID: 3792 RVA: 0x0001EA88 File Offset: 0x0001CC88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003B4 RID: 948
		private uint? _itemid;

		// Token: 0x040003B5 RID: 949
		private uint? _index;

		// Token: 0x040003B6 RID: 950
		private IExtension extensionObject;
	}
}
