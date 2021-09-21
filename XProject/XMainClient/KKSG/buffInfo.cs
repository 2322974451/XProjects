using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000D6 RID: 214
	[ProtoContract(Name = "buffInfo")]
	[Serializable]
	public class buffInfo : IExtensible
	{
		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06000DAF RID: 3503 RVA: 0x0001C888 File Offset: 0x0001AA88
		// (set) Token: 0x06000DB0 RID: 3504 RVA: 0x0001C8B5 File Offset: 0x0001AAB5
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06000DB1 RID: 3505 RVA: 0x0001C8C4 File Offset: 0x0001AAC4
		// (set) Token: 0x06000DB2 RID: 3506 RVA: 0x0001C8E4 File Offset: 0x0001AAE4
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

		// Token: 0x06000DB3 RID: 3507 RVA: 0x0001C928 File Offset: 0x0001AB28
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x0001C940 File Offset: 0x0001AB40
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06000DB5 RID: 3509 RVA: 0x0001C94C File Offset: 0x0001AB4C
		// (set) Token: 0x06000DB6 RID: 3510 RVA: 0x0001C964 File Offset: 0x0001AB64
		[ProtoMember(2, IsRequired = false, Name = "addbuff", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BuffInfo addbuff
		{
			get
			{
				return this._addbuff;
			}
			set
			{
				this._addbuff = value;
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06000DB7 RID: 3511 RVA: 0x0001C970 File Offset: 0x0001AB70
		// (set) Token: 0x06000DB8 RID: 3512 RVA: 0x0001C988 File Offset: 0x0001AB88
		[ProtoMember(3, IsRequired = false, Name = "removebuff", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BuffInfo removebuff
		{
			get
			{
				return this._removebuff;
			}
			set
			{
				this._removebuff = value;
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06000DB9 RID: 3513 RVA: 0x0001C994 File Offset: 0x0001AB94
		// (set) Token: 0x06000DBA RID: 3514 RVA: 0x0001C9AC File Offset: 0x0001ABAC
		[ProtoMember(4, IsRequired = false, Name = "updatebuff", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BuffInfo updatebuff
		{
			get
			{
				return this._updatebuff;
			}
			set
			{
				this._updatebuff = value;
			}
		}

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06000DBB RID: 3515 RVA: 0x0001C9B8 File Offset: 0x0001ABB8
		// (set) Token: 0x06000DBC RID: 3516 RVA: 0x0001C9D0 File Offset: 0x0001ABD0
		[ProtoMember(5, IsRequired = false, Name = "allbuffsinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public AllBuffsInfo allbuffsinfo
		{
			get
			{
				return this._allbuffsinfo;
			}
			set
			{
				this._allbuffsinfo = value;
			}
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x0001C9DC File Offset: 0x0001ABDC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000371 RID: 881
		private ulong? _uid;

		// Token: 0x04000372 RID: 882
		private BuffInfo _addbuff = null;

		// Token: 0x04000373 RID: 883
		private BuffInfo _removebuff = null;

		// Token: 0x04000374 RID: 884
		private BuffInfo _updatebuff = null;

		// Token: 0x04000375 RID: 885
		private AllBuffsInfo _allbuffsinfo = null;

		// Token: 0x04000376 RID: 886
		private IExtension extensionObject;
	}
}
