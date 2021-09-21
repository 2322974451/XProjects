using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200073C RID: 1852
	[ProtoContract(Name = "BoxInfos")]
	[Serializable]
	public class BoxInfos : IExtensible
	{
		// Token: 0x170028B7 RID: 10423
		// (get) Token: 0x0600806F RID: 32879 RVA: 0x000F59B8 File Offset: 0x000F3BB8
		[ProtoMember(1, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x170028B8 RID: 10424
		// (get) Token: 0x06008070 RID: 32880 RVA: 0x000F59D0 File Offset: 0x000F3BD0
		// (set) Token: 0x06008071 RID: 32881 RVA: 0x000F59FC File Offset: 0x000F3BFC
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

		// Token: 0x170028B9 RID: 10425
		// (get) Token: 0x06008072 RID: 32882 RVA: 0x000F5A0C File Offset: 0x000F3C0C
		// (set) Token: 0x06008073 RID: 32883 RVA: 0x000F5A2C File Offset: 0x000F3C2C
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

		// Token: 0x06008074 RID: 32884 RVA: 0x000F5A70 File Offset: 0x000F3C70
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06008075 RID: 32885 RVA: 0x000F5A88 File Offset: 0x000F3C88
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x170028BA RID: 10426
		// (get) Token: 0x06008076 RID: 32886 RVA: 0x000F5A94 File Offset: 0x000F3C94
		// (set) Token: 0x06008077 RID: 32887 RVA: 0x000F5AC1 File Offset: 0x000F3CC1
		[ProtoMember(3, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170028BB RID: 10427
		// (get) Token: 0x06008078 RID: 32888 RVA: 0x000F5AD0 File Offset: 0x000F3CD0
		// (set) Token: 0x06008079 RID: 32889 RVA: 0x000F5AF0 File Offset: 0x000F3CF0
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

		// Token: 0x0600807A RID: 32890 RVA: 0x000F5B34 File Offset: 0x000F3D34
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600807B RID: 32891 RVA: 0x000F5B4C File Offset: 0x000F3D4C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170028BC RID: 10428
		// (get) Token: 0x0600807C RID: 32892 RVA: 0x000F5B58 File Offset: 0x000F3D58
		[ProtoMember(4, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public List<uint> type
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x0600807D RID: 32893 RVA: 0x000F5B70 File Offset: 0x000F3D70
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E18 RID: 7704
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x04001E19 RID: 7705
		private uint? _index;

		// Token: 0x04001E1A RID: 7706
		private ulong? _roleid;

		// Token: 0x04001E1B RID: 7707
		private readonly List<uint> _type = new List<uint>();

		// Token: 0x04001E1C RID: 7708
		private IExtension extensionObject;
	}
}
