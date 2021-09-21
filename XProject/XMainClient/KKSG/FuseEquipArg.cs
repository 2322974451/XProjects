using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004E9 RID: 1257
	[ProtoContract(Name = "FuseEquipArg")]
	[Serializable]
	public class FuseEquipArg : IExtensible
	{
		// Token: 0x170013DE RID: 5086
		// (get) Token: 0x060040F0 RID: 16624 RVA: 0x0007BA64 File Offset: 0x00079C64
		// (set) Token: 0x060040F1 RID: 16625 RVA: 0x0007BA90 File Offset: 0x00079C90
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x170013DF RID: 5087
		// (get) Token: 0x060040F2 RID: 16626 RVA: 0x0007BAA0 File Offset: 0x00079CA0
		// (set) Token: 0x060040F3 RID: 16627 RVA: 0x0007BAC0 File Offset: 0x00079CC0
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
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x060040F4 RID: 16628 RVA: 0x0007BB04 File Offset: 0x00079D04
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060040F5 RID: 16629 RVA: 0x0007BB1C File Offset: 0x00079D1C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170013E0 RID: 5088
		// (get) Token: 0x060040F6 RID: 16630 RVA: 0x0007BB28 File Offset: 0x00079D28
		// (set) Token: 0x060040F7 RID: 16631 RVA: 0x0007BB55 File Offset: 0x00079D55
		[ProtoMember(2, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x170013E1 RID: 5089
		// (get) Token: 0x060040F8 RID: 16632 RVA: 0x0007BB64 File Offset: 0x00079D64
		// (set) Token: 0x060040F9 RID: 16633 RVA: 0x0007BB84 File Offset: 0x00079D84
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x060040FA RID: 16634 RVA: 0x0007BBC8 File Offset: 0x00079DC8
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x060040FB RID: 16635 RVA: 0x0007BBE0 File Offset: 0x00079DE0
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x170013E2 RID: 5090
		// (get) Token: 0x060040FC RID: 16636 RVA: 0x0007BBEC File Offset: 0x00079DEC
		// (set) Token: 0x060040FD RID: 16637 RVA: 0x0007BC18 File Offset: 0x00079E18
		[ProtoMember(3, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public uint itemID
		{
			get
			{
				return this._itemID ?? 0U;
			}
			set
			{
				this._itemID = new uint?(value);
			}
		}

		// Token: 0x170013E3 RID: 5091
		// (get) Token: 0x060040FE RID: 16638 RVA: 0x0007BC28 File Offset: 0x00079E28
		// (set) Token: 0x060040FF RID: 16639 RVA: 0x0007BC48 File Offset: 0x00079E48
		[XmlIgnore]
		[Browsable(false)]
		public bool itemIDSpecified
		{
			get
			{
				return this._itemID != null;
			}
			set
			{
				bool flag = value == (this._itemID == null);
				if (flag)
				{
					this._itemID = (value ? new uint?(this.itemID) : null);
				}
			}
		}

		// Token: 0x06004100 RID: 16640 RVA: 0x0007BC8C File Offset: 0x00079E8C
		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		// Token: 0x06004101 RID: 16641 RVA: 0x0007BCA4 File Offset: 0x00079EA4
		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		// Token: 0x06004102 RID: 16642 RVA: 0x0007BCB0 File Offset: 0x00079EB0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400102E RID: 4142
		private uint? _type;

		// Token: 0x0400102F RID: 4143
		private ulong? _uid;

		// Token: 0x04001030 RID: 4144
		private uint? _itemID;

		// Token: 0x04001031 RID: 4145
		private IExtension extensionObject;
	}
}
