using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005B8 RID: 1464
	[ProtoContract(Name = "GHisRecord")]
	[Serializable]
	public class GHisRecord : IExtensible
	{
		// Token: 0x17001912 RID: 6418
		// (get) Token: 0x06005125 RID: 20773 RVA: 0x0009A624 File Offset: 0x00098824
		// (set) Token: 0x06005126 RID: 20774 RVA: 0x0009A650 File Offset: 0x00098850
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

		// Token: 0x17001913 RID: 6419
		// (get) Token: 0x06005127 RID: 20775 RVA: 0x0009A660 File Offset: 0x00098860
		// (set) Token: 0x06005128 RID: 20776 RVA: 0x0009A680 File Offset: 0x00098880
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

		// Token: 0x06005129 RID: 20777 RVA: 0x0009A6C4 File Offset: 0x000988C4
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600512A RID: 20778 RVA: 0x0009A6DC File Offset: 0x000988DC
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001914 RID: 6420
		// (get) Token: 0x0600512B RID: 20779 RVA: 0x0009A6E8 File Offset: 0x000988E8
		// (set) Token: 0x0600512C RID: 20780 RVA: 0x0009A714 File Offset: 0x00098914
		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x17001915 RID: 6421
		// (get) Token: 0x0600512D RID: 20781 RVA: 0x0009A724 File Offset: 0x00098924
		// (set) Token: 0x0600512E RID: 20782 RVA: 0x0009A744 File Offset: 0x00098944
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x0600512F RID: 20783 RVA: 0x0009A788 File Offset: 0x00098988
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06005130 RID: 20784 RVA: 0x0009A7A0 File Offset: 0x000989A0
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x17001916 RID: 6422
		// (get) Token: 0x06005131 RID: 20785 RVA: 0x0009A7AC File Offset: 0x000989AC
		// (set) Token: 0x06005132 RID: 20786 RVA: 0x0009A7D8 File Offset: 0x000989D8
		[ProtoMember(3, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public uint position
		{
			get
			{
				return this._position ?? 0U;
			}
			set
			{
				this._position = new uint?(value);
			}
		}

		// Token: 0x17001917 RID: 6423
		// (get) Token: 0x06005133 RID: 20787 RVA: 0x0009A7E8 File Offset: 0x000989E8
		// (set) Token: 0x06005134 RID: 20788 RVA: 0x0009A808 File Offset: 0x00098A08
		[XmlIgnore]
		[Browsable(false)]
		public bool positionSpecified
		{
			get
			{
				return this._position != null;
			}
			set
			{
				bool flag = value == (this._position == null);
				if (flag)
				{
					this._position = (value ? new uint?(this.position) : null);
				}
			}
		}

		// Token: 0x06005135 RID: 20789 RVA: 0x0009A84C File Offset: 0x00098A4C
		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		// Token: 0x06005136 RID: 20790 RVA: 0x0009A864 File Offset: 0x00098A64
		private void Resetposition()
		{
			this.positionSpecified = false;
		}

		// Token: 0x17001918 RID: 6424
		// (get) Token: 0x06005137 RID: 20791 RVA: 0x0009A870 File Offset: 0x00098A70
		// (set) Token: 0x06005138 RID: 20792 RVA: 0x0009A89D File Offset: 0x00098A9D
		[ProtoMember(4, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x17001919 RID: 6425
		// (get) Token: 0x06005139 RID: 20793 RVA: 0x0009A8AC File Offset: 0x00098AAC
		// (set) Token: 0x0600513A RID: 20794 RVA: 0x0009A8CC File Offset: 0x00098ACC
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
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x0600513B RID: 20795 RVA: 0x0009A910 File Offset: 0x00098B10
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600513C RID: 20796 RVA: 0x0009A928 File Offset: 0x00098B28
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700191A RID: 6426
		// (get) Token: 0x0600513D RID: 20797 RVA: 0x0009A934 File Offset: 0x00098B34
		// (set) Token: 0x0600513E RID: 20798 RVA: 0x0009A955 File Offset: 0x00098B55
		[ProtoMember(5, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		// Token: 0x1700191B RID: 6427
		// (get) Token: 0x0600513F RID: 20799 RVA: 0x0009A960 File Offset: 0x00098B60
		// (set) Token: 0x06005140 RID: 20800 RVA: 0x0009A97C File Offset: 0x00098B7C
		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		// Token: 0x06005141 RID: 20801 RVA: 0x0009A9AC File Offset: 0x00098BAC
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06005142 RID: 20802 RVA: 0x0009A9C4 File Offset: 0x00098BC4
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x06005143 RID: 20803 RVA: 0x0009A9D0 File Offset: 0x00098BD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040013E8 RID: 5096
		private uint? _type;

		// Token: 0x040013E9 RID: 5097
		private uint? _time;

		// Token: 0x040013EA RID: 5098
		private uint? _position;

		// Token: 0x040013EB RID: 5099
		private ulong? _roleid;

		// Token: 0x040013EC RID: 5100
		private string _rolename;

		// Token: 0x040013ED RID: 5101
		private IExtension extensionObject;
	}
}
