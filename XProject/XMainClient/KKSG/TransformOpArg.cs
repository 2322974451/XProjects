using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004A3 RID: 1187
	[ProtoContract(Name = "TransformOpArg")]
	[Serializable]
	public class TransformOpArg : IExtensible
	{
		// Token: 0x170012EA RID: 4842
		// (get) Token: 0x06003DBA RID: 15802 RVA: 0x00075CA4 File Offset: 0x00073EA4
		// (set) Token: 0x06003DBB RID: 15803 RVA: 0x00075CD0 File Offset: 0x00073ED0
		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public int op
		{
			get
			{
				return this._op ?? 0;
			}
			set
			{
				this._op = new int?(value);
			}
		}

		// Token: 0x170012EB RID: 4843
		// (get) Token: 0x06003DBC RID: 15804 RVA: 0x00075CE0 File Offset: 0x00073EE0
		// (set) Token: 0x06003DBD RID: 15805 RVA: 0x00075D00 File Offset: 0x00073F00
		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new int?(this.op) : null);
				}
			}
		}

		// Token: 0x06003DBE RID: 15806 RVA: 0x00075D44 File Offset: 0x00073F44
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x06003DBF RID: 15807 RVA: 0x00075D5C File Offset: 0x00073F5C
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x170012EC RID: 4844
		// (get) Token: 0x06003DC0 RID: 15808 RVA: 0x00075D68 File Offset: 0x00073F68
		// (set) Token: 0x06003DC1 RID: 15809 RVA: 0x00075D89 File Offset: 0x00073F89
		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.Default)]
		public string roleid
		{
			get
			{
				return this._roleid ?? "";
			}
			set
			{
				this._roleid = value;
			}
		}

		// Token: 0x170012ED RID: 4845
		// (get) Token: 0x06003DC2 RID: 15810 RVA: 0x00075D94 File Offset: 0x00073F94
		// (set) Token: 0x06003DC3 RID: 15811 RVA: 0x00075DB0 File Offset: 0x00073FB0
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? this.roleid : null);
				}
			}
		}

		// Token: 0x06003DC4 RID: 15812 RVA: 0x00075DE0 File Offset: 0x00073FE0
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06003DC5 RID: 15813 RVA: 0x00075DF8 File Offset: 0x00073FF8
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170012EE RID: 4846
		// (get) Token: 0x06003DC6 RID: 15814 RVA: 0x00075E04 File Offset: 0x00074004
		// (set) Token: 0x06003DC7 RID: 15815 RVA: 0x00075E30 File Offset: 0x00074030
		[ProtoMember(3, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170012EF RID: 4847
		// (get) Token: 0x06003DC8 RID: 15816 RVA: 0x00075E40 File Offset: 0x00074040
		// (set) Token: 0x06003DC9 RID: 15817 RVA: 0x00075E60 File Offset: 0x00074060
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

		// Token: 0x06003DCA RID: 15818 RVA: 0x00075EA4 File Offset: 0x000740A4
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06003DCB RID: 15819 RVA: 0x00075EBC File Offset: 0x000740BC
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x06003DCC RID: 15820 RVA: 0x00075EC8 File Offset: 0x000740C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F61 RID: 3937
		private int? _op;

		// Token: 0x04000F62 RID: 3938
		private string _roleid;

		// Token: 0x04000F63 RID: 3939
		private uint? _itemid;

		// Token: 0x04000F64 RID: 3940
		private IExtension extensionObject;
	}
}
