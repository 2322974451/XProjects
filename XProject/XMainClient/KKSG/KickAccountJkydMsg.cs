using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000517 RID: 1303
	[ProtoContract(Name = "KickAccountJkydMsg")]
	[Serializable]
	public class KickAccountJkydMsg : IExtensible
	{
		// Token: 0x1700147B RID: 5243
		// (get) Token: 0x060042FF RID: 17151 RVA: 0x0007F7A0 File Offset: 0x0007D9A0
		// (set) Token: 0x06004300 RID: 17152 RVA: 0x0007F7C1 File Offset: 0x0007D9C1
		[ProtoMember(1, IsRequired = false, Name = "msg", DataFormat = DataFormat.Default)]
		public string msg
		{
			get
			{
				return this._msg ?? "";
			}
			set
			{
				this._msg = value;
			}
		}

		// Token: 0x1700147C RID: 5244
		// (get) Token: 0x06004301 RID: 17153 RVA: 0x0007F7CC File Offset: 0x0007D9CC
		// (set) Token: 0x06004302 RID: 17154 RVA: 0x0007F7E8 File Offset: 0x0007D9E8
		[XmlIgnore]
		[Browsable(false)]
		public bool msgSpecified
		{
			get
			{
				return this._msg != null;
			}
			set
			{
				bool flag = value == (this._msg == null);
				if (flag)
				{
					this._msg = (value ? this.msg : null);
				}
			}
		}

		// Token: 0x06004303 RID: 17155 RVA: 0x0007F818 File Offset: 0x0007DA18
		private bool ShouldSerializemsg()
		{
			return this.msgSpecified;
		}

		// Token: 0x06004304 RID: 17156 RVA: 0x0007F830 File Offset: 0x0007DA30
		private void Resetmsg()
		{
			this.msgSpecified = false;
		}

		// Token: 0x1700147D RID: 5245
		// (get) Token: 0x06004305 RID: 17157 RVA: 0x0007F83C File Offset: 0x0007DA3C
		// (set) Token: 0x06004306 RID: 17158 RVA: 0x0007F868 File Offset: 0x0007DA68
		[ProtoMember(2, IsRequired = false, Name = "kt", DataFormat = DataFormat.TwosComplement)]
		public KickType kt
		{
			get
			{
				return this._kt ?? KickType.KICK_NORMAL;
			}
			set
			{
				this._kt = new KickType?(value);
			}
		}

		// Token: 0x1700147E RID: 5246
		// (get) Token: 0x06004307 RID: 17159 RVA: 0x0007F878 File Offset: 0x0007DA78
		// (set) Token: 0x06004308 RID: 17160 RVA: 0x0007F898 File Offset: 0x0007DA98
		[XmlIgnore]
		[Browsable(false)]
		public bool ktSpecified
		{
			get
			{
				return this._kt != null;
			}
			set
			{
				bool flag = value == (this._kt == null);
				if (flag)
				{
					this._kt = (value ? new KickType?(this.kt) : null);
				}
			}
		}

		// Token: 0x06004309 RID: 17161 RVA: 0x0007F8DC File Offset: 0x0007DADC
		private bool ShouldSerializekt()
		{
			return this.ktSpecified;
		}

		// Token: 0x0600430A RID: 17162 RVA: 0x0007F8F4 File Offset: 0x0007DAF4
		private void Resetkt()
		{
			this.ktSpecified = false;
		}

		// Token: 0x0600430B RID: 17163 RVA: 0x0007F900 File Offset: 0x0007DB00
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010B5 RID: 4277
		private string _msg;

		// Token: 0x040010B6 RID: 4278
		private KickType? _kt;

		// Token: 0x040010B7 RID: 4279
		private IExtension extensionObject;
	}
}
