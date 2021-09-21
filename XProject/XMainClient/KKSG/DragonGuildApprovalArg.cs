using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004B3 RID: 1203
	[ProtoContract(Name = "DragonGuildApprovalArg")]
	[Serializable]
	public class DragonGuildApprovalArg : IExtensible
	{
		// Token: 0x1700133B RID: 4923
		// (get) Token: 0x06003EC0 RID: 16064 RVA: 0x00077AFC File Offset: 0x00075CFC
		// (set) Token: 0x06003EC1 RID: 16065 RVA: 0x00077B29 File Offset: 0x00075D29
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700133C RID: 4924
		// (get) Token: 0x06003EC2 RID: 16066 RVA: 0x00077B38 File Offset: 0x00075D38
		// (set) Token: 0x06003EC3 RID: 16067 RVA: 0x00077B58 File Offset: 0x00075D58
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

		// Token: 0x06003EC4 RID: 16068 RVA: 0x00077B9C File Offset: 0x00075D9C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06003EC5 RID: 16069 RVA: 0x00077BB4 File Offset: 0x00075DB4
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700133D RID: 4925
		// (get) Token: 0x06003EC6 RID: 16070 RVA: 0x00077BC0 File Offset: 0x00075DC0
		// (set) Token: 0x06003EC7 RID: 16071 RVA: 0x00077BEC File Offset: 0x00075DEC
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700133E RID: 4926
		// (get) Token: 0x06003EC8 RID: 16072 RVA: 0x00077BFC File Offset: 0x00075DFC
		// (set) Token: 0x06003EC9 RID: 16073 RVA: 0x00077C1C File Offset: 0x00075E1C
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

		// Token: 0x06003ECA RID: 16074 RVA: 0x00077C60 File Offset: 0x00075E60
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003ECB RID: 16075 RVA: 0x00077C78 File Offset: 0x00075E78
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06003ECC RID: 16076 RVA: 0x00077C84 File Offset: 0x00075E84
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F9D RID: 3997
		private ulong? _roleid;

		// Token: 0x04000F9E RID: 3998
		private uint? _type;

		// Token: 0x04000F9F RID: 3999
		private IExtension extensionObject;
	}
}
