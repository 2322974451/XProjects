using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000694 RID: 1684
	[ProtoContract(Name = "GmfRoleBrief")]
	[Serializable]
	public class GmfRoleBrief : IExtensible
	{
		// Token: 0x1700228B RID: 8843
		// (get) Token: 0x06006D24 RID: 27940 RVA: 0x000D0D58 File Offset: 0x000CEF58
		// (set) Token: 0x06006D25 RID: 27941 RVA: 0x000D0D85 File Offset: 0x000CEF85
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

		// Token: 0x1700228C RID: 8844
		// (get) Token: 0x06006D26 RID: 27942 RVA: 0x000D0D94 File Offset: 0x000CEF94
		// (set) Token: 0x06006D27 RID: 27943 RVA: 0x000D0DB4 File Offset: 0x000CEFB4
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

		// Token: 0x06006D28 RID: 27944 RVA: 0x000D0DF8 File Offset: 0x000CEFF8
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06006D29 RID: 27945 RVA: 0x000D0E10 File Offset: 0x000CF010
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700228D RID: 8845
		// (get) Token: 0x06006D2A RID: 27946 RVA: 0x000D0E1C File Offset: 0x000CF01C
		// (set) Token: 0x06006D2B RID: 27947 RVA: 0x000D0E3D File Offset: 0x000CF03D
		[ProtoMember(2, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
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

		// Token: 0x1700228E RID: 8846
		// (get) Token: 0x06006D2C RID: 27948 RVA: 0x000D0E48 File Offset: 0x000CF048
		// (set) Token: 0x06006D2D RID: 27949 RVA: 0x000D0E64 File Offset: 0x000CF064
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

		// Token: 0x06006D2E RID: 27950 RVA: 0x000D0E94 File Offset: 0x000CF094
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06006D2F RID: 27951 RVA: 0x000D0EAC File Offset: 0x000CF0AC
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x1700228F RID: 8847
		// (get) Token: 0x06006D30 RID: 27952 RVA: 0x000D0EB8 File Offset: 0x000CF0B8
		// (set) Token: 0x06006D31 RID: 27953 RVA: 0x000D0EE4 File Offset: 0x000CF0E4
		[ProtoMember(3, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		// Token: 0x17002290 RID: 8848
		// (get) Token: 0x06006D32 RID: 27954 RVA: 0x000D0EF4 File Offset: 0x000CF0F4
		// (set) Token: 0x06006D33 RID: 27955 RVA: 0x000D0F14 File Offset: 0x000CF114
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		// Token: 0x06006D34 RID: 27956 RVA: 0x000D0F58 File Offset: 0x000CF158
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06006D35 RID: 27957 RVA: 0x000D0F70 File Offset: 0x000CF170
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x06006D36 RID: 27958 RVA: 0x000D0F7C File Offset: 0x000CF17C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A2C RID: 6700
		private ulong? _roleid;

		// Token: 0x04001A2D RID: 6701
		private string _rolename;

		// Token: 0x04001A2E RID: 6702
		private uint? _profession;

		// Token: 0x04001A2F RID: 6703
		private IExtension extensionObject;
	}
}
