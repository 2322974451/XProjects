using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000D5 RID: 213
	[ProtoContract(Name = "TeamSelect")]
	[Serializable]
	public class TeamSelect : IExtensible
	{
		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06000DA1 RID: 3489 RVA: 0x0001C6BC File Offset: 0x0001A8BC
		// (set) Token: 0x06000DA2 RID: 3490 RVA: 0x0001C6E9 File Offset: 0x0001A8E9
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public long roleid
		{
			get
			{
				return this._roleid ?? 0L;
			}
			set
			{
				this._roleid = new long?(value);
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06000DA3 RID: 3491 RVA: 0x0001C6F8 File Offset: 0x0001A8F8
		// (set) Token: 0x06000DA4 RID: 3492 RVA: 0x0001C718 File Offset: 0x0001A918
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
					this._roleid = (value ? new long?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x0001C75C File Offset: 0x0001A95C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x0001C774 File Offset: 0x0001A974
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06000DA7 RID: 3495 RVA: 0x0001C780 File Offset: 0x0001A980
		// (set) Token: 0x06000DA8 RID: 3496 RVA: 0x0001C7AC File Offset: 0x0001A9AC
		[ProtoMember(2, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public int index
		{
			get
			{
				return this._index ?? 0;
			}
			set
			{
				this._index = new int?(value);
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06000DA9 RID: 3497 RVA: 0x0001C7BC File Offset: 0x0001A9BC
		// (set) Token: 0x06000DAA RID: 3498 RVA: 0x0001C7DC File Offset: 0x0001A9DC
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
					this._index = (value ? new int?(this.index) : null);
				}
			}
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x0001C820 File Offset: 0x0001AA20
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x0001C838 File Offset: 0x0001AA38
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x0001C844 File Offset: 0x0001AA44
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400036E RID: 878
		private long? _roleid;

		// Token: 0x0400036F RID: 879
		private int? _index;

		// Token: 0x04000370 RID: 880
		private IExtension extensionObject;
	}
}
