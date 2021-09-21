using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200067D RID: 1661
	[ProtoContract(Name = "NpcFlReturn")]
	[Serializable]
	public class NpcFlReturn : IExtensible
	{
		// Token: 0x170021AC RID: 8620
		// (get) Token: 0x06006A69 RID: 27241 RVA: 0x000CB7E0 File Offset: 0x000C99E0
		// (set) Token: 0x06006A6A RID: 27242 RVA: 0x000CB80C File Offset: 0x000C9A0C
		[ProtoMember(1, IsRequired = false, Name = "dropid", DataFormat = DataFormat.TwosComplement)]
		public uint dropid
		{
			get
			{
				return this._dropid ?? 0U;
			}
			set
			{
				this._dropid = new uint?(value);
			}
		}

		// Token: 0x170021AD RID: 8621
		// (get) Token: 0x06006A6B RID: 27243 RVA: 0x000CB81C File Offset: 0x000C9A1C
		// (set) Token: 0x06006A6C RID: 27244 RVA: 0x000CB83C File Offset: 0x000C9A3C
		[XmlIgnore]
		[Browsable(false)]
		public bool dropidSpecified
		{
			get
			{
				return this._dropid != null;
			}
			set
			{
				bool flag = value == (this._dropid == null);
				if (flag)
				{
					this._dropid = (value ? new uint?(this.dropid) : null);
				}
			}
		}

		// Token: 0x06006A6D RID: 27245 RVA: 0x000CB880 File Offset: 0x000C9A80
		private bool ShouldSerializedropid()
		{
			return this.dropidSpecified;
		}

		// Token: 0x06006A6E RID: 27246 RVA: 0x000CB898 File Offset: 0x000C9A98
		private void Resetdropid()
		{
			this.dropidSpecified = false;
		}

		// Token: 0x170021AE RID: 8622
		// (get) Token: 0x06006A6F RID: 27247 RVA: 0x000CB8A4 File Offset: 0x000C9AA4
		// (set) Token: 0x06006A70 RID: 27248 RVA: 0x000CB8D0 File Offset: 0x000C9AD0
		[ProtoMember(2, IsRequired = false, Name = "gtime", DataFormat = DataFormat.TwosComplement)]
		public uint gtime
		{
			get
			{
				return this._gtime ?? 0U;
			}
			set
			{
				this._gtime = new uint?(value);
			}
		}

		// Token: 0x170021AF RID: 8623
		// (get) Token: 0x06006A71 RID: 27249 RVA: 0x000CB8E0 File Offset: 0x000C9AE0
		// (set) Token: 0x06006A72 RID: 27250 RVA: 0x000CB900 File Offset: 0x000C9B00
		[XmlIgnore]
		[Browsable(false)]
		public bool gtimeSpecified
		{
			get
			{
				return this._gtime != null;
			}
			set
			{
				bool flag = value == (this._gtime == null);
				if (flag)
				{
					this._gtime = (value ? new uint?(this.gtime) : null);
				}
			}
		}

		// Token: 0x06006A73 RID: 27251 RVA: 0x000CB944 File Offset: 0x000C9B44
		private bool ShouldSerializegtime()
		{
			return this.gtimeSpecified;
		}

		// Token: 0x06006A74 RID: 27252 RVA: 0x000CB95C File Offset: 0x000C9B5C
		private void Resetgtime()
		{
			this.gtimeSpecified = false;
		}

		// Token: 0x170021B0 RID: 8624
		// (get) Token: 0x06006A75 RID: 27253 RVA: 0x000CB968 File Offset: 0x000C9B68
		// (set) Token: 0x06006A76 RID: 27254 RVA: 0x000CB994 File Offset: 0x000C9B94
		[ProtoMember(3, IsRequired = false, Name = "mailconfid", DataFormat = DataFormat.TwosComplement)]
		public uint mailconfid
		{
			get
			{
				return this._mailconfid ?? 0U;
			}
			set
			{
				this._mailconfid = new uint?(value);
			}
		}

		// Token: 0x170021B1 RID: 8625
		// (get) Token: 0x06006A77 RID: 27255 RVA: 0x000CB9A4 File Offset: 0x000C9BA4
		// (set) Token: 0x06006A78 RID: 27256 RVA: 0x000CB9C4 File Offset: 0x000C9BC4
		[XmlIgnore]
		[Browsable(false)]
		public bool mailconfidSpecified
		{
			get
			{
				return this._mailconfid != null;
			}
			set
			{
				bool flag = value == (this._mailconfid == null);
				if (flag)
				{
					this._mailconfid = (value ? new uint?(this.mailconfid) : null);
				}
			}
		}

		// Token: 0x06006A79 RID: 27257 RVA: 0x000CBA08 File Offset: 0x000C9C08
		private bool ShouldSerializemailconfid()
		{
			return this.mailconfidSpecified;
		}

		// Token: 0x06006A7A RID: 27258 RVA: 0x000CBA20 File Offset: 0x000C9C20
		private void Resetmailconfid()
		{
			this.mailconfidSpecified = false;
		}

		// Token: 0x06006A7B RID: 27259 RVA: 0x000CBA2C File Offset: 0x000C9C2C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019A1 RID: 6561
		private uint? _dropid;

		// Token: 0x040019A2 RID: 6562
		private uint? _gtime;

		// Token: 0x040019A3 RID: 6563
		private uint? _mailconfid;

		// Token: 0x040019A4 RID: 6564
		private IExtension extensionObject;
	}
}
