using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000409 RID: 1033
	[ProtoContract(Name = "DisplayAddItemArg")]
	[Serializable]
	public class DisplayAddItemArg : IExtensible
	{
		// Token: 0x170010E8 RID: 4328
		// (get) Token: 0x060036FD RID: 14077 RVA: 0x00069548 File Offset: 0x00067748
		// (set) Token: 0x060036FE RID: 14078 RVA: 0x00069574 File Offset: 0x00067774
		[ProtoMember(1, IsRequired = false, Name = "add_item_id", DataFormat = DataFormat.TwosComplement)]
		public uint add_item_id
		{
			get
			{
				return this._add_item_id ?? 0U;
			}
			set
			{
				this._add_item_id = new uint?(value);
			}
		}

		// Token: 0x170010E9 RID: 4329
		// (get) Token: 0x060036FF RID: 14079 RVA: 0x00069584 File Offset: 0x00067784
		// (set) Token: 0x06003700 RID: 14080 RVA: 0x000695A4 File Offset: 0x000677A4
		[XmlIgnore]
		[Browsable(false)]
		public bool add_item_idSpecified
		{
			get
			{
				return this._add_item_id != null;
			}
			set
			{
				bool flag = value == (this._add_item_id == null);
				if (flag)
				{
					this._add_item_id = (value ? new uint?(this.add_item_id) : null);
				}
			}
		}

		// Token: 0x06003701 RID: 14081 RVA: 0x000695E8 File Offset: 0x000677E8
		private bool ShouldSerializeadd_item_id()
		{
			return this.add_item_idSpecified;
		}

		// Token: 0x06003702 RID: 14082 RVA: 0x00069600 File Offset: 0x00067800
		private void Resetadd_item_id()
		{
			this.add_item_idSpecified = false;
		}

		// Token: 0x170010EA RID: 4330
		// (get) Token: 0x06003703 RID: 14083 RVA: 0x0006960C File Offset: 0x0006780C
		// (set) Token: 0x06003704 RID: 14084 RVA: 0x00069638 File Offset: 0x00067838
		[ProtoMember(2, IsRequired = false, Name = "del_item_id", DataFormat = DataFormat.TwosComplement)]
		public uint del_item_id
		{
			get
			{
				return this._del_item_id ?? 0U;
			}
			set
			{
				this._del_item_id = new uint?(value);
			}
		}

		// Token: 0x170010EB RID: 4331
		// (get) Token: 0x06003705 RID: 14085 RVA: 0x00069648 File Offset: 0x00067848
		// (set) Token: 0x06003706 RID: 14086 RVA: 0x00069668 File Offset: 0x00067868
		[XmlIgnore]
		[Browsable(false)]
		public bool del_item_idSpecified
		{
			get
			{
				return this._del_item_id != null;
			}
			set
			{
				bool flag = value == (this._del_item_id == null);
				if (flag)
				{
					this._del_item_id = (value ? new uint?(this.del_item_id) : null);
				}
			}
		}

		// Token: 0x06003707 RID: 14087 RVA: 0x000696AC File Offset: 0x000678AC
		private bool ShouldSerializedel_item_id()
		{
			return this.del_item_idSpecified;
		}

		// Token: 0x06003708 RID: 14088 RVA: 0x000696C4 File Offset: 0x000678C4
		private void Resetdel_item_id()
		{
			this.del_item_idSpecified = false;
		}

		// Token: 0x06003709 RID: 14089 RVA: 0x000696D0 File Offset: 0x000678D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DA2 RID: 3490
		private uint? _add_item_id;

		// Token: 0x04000DA3 RID: 3491
		private uint? _del_item_id;

		// Token: 0x04000DA4 RID: 3492
		private IExtension extensionObject;
	}
}
