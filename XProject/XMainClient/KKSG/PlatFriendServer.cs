using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005B1 RID: 1457
	[ProtoContract(Name = "PlatFriendServer")]
	[Serializable]
	public class PlatFriendServer : IExtensible
	{
		// Token: 0x17001884 RID: 6276
		// (get) Token: 0x06004F70 RID: 20336 RVA: 0x0009712C File Offset: 0x0009532C
		// (set) Token: 0x06004F71 RID: 20337 RVA: 0x0009714D File Offset: 0x0009534D
		[ProtoMember(1, IsRequired = false, Name = "openid", DataFormat = DataFormat.Default)]
		public string openid
		{
			get
			{
				return this._openid ?? "";
			}
			set
			{
				this._openid = value;
			}
		}

		// Token: 0x17001885 RID: 6277
		// (get) Token: 0x06004F72 RID: 20338 RVA: 0x00097158 File Offset: 0x00095358
		// (set) Token: 0x06004F73 RID: 20339 RVA: 0x00097174 File Offset: 0x00095374
		[XmlIgnore]
		[Browsable(false)]
		public bool openidSpecified
		{
			get
			{
				return this._openid != null;
			}
			set
			{
				bool flag = value == (this._openid == null);
				if (flag)
				{
					this._openid = (value ? this.openid : null);
				}
			}
		}

		// Token: 0x06004F74 RID: 20340 RVA: 0x000971A4 File Offset: 0x000953A4
		private bool ShouldSerializeopenid()
		{
			return this.openidSpecified;
		}

		// Token: 0x06004F75 RID: 20341 RVA: 0x000971BC File Offset: 0x000953BC
		private void Resetopenid()
		{
			this.openidSpecified = false;
		}

		// Token: 0x17001886 RID: 6278
		// (get) Token: 0x06004F76 RID: 20342 RVA: 0x000971C8 File Offset: 0x000953C8
		// (set) Token: 0x06004F77 RID: 20343 RVA: 0x000971F4 File Offset: 0x000953F4
		[ProtoMember(2, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public int serverid
		{
			get
			{
				return this._serverid ?? 0;
			}
			set
			{
				this._serverid = new int?(value);
			}
		}

		// Token: 0x17001887 RID: 6279
		// (get) Token: 0x06004F78 RID: 20344 RVA: 0x00097204 File Offset: 0x00095404
		// (set) Token: 0x06004F79 RID: 20345 RVA: 0x00097224 File Offset: 0x00095424
		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new int?(this.serverid) : null);
				}
			}
		}

		// Token: 0x06004F7A RID: 20346 RVA: 0x00097268 File Offset: 0x00095468
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06004F7B RID: 20347 RVA: 0x00097280 File Offset: 0x00095480
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x17001888 RID: 6280
		// (get) Token: 0x06004F7C RID: 20348 RVA: 0x0009728C File Offset: 0x0009548C
		// (set) Token: 0x06004F7D RID: 20349 RVA: 0x000972AD File Offset: 0x000954AD
		[ProtoMember(3, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
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

		// Token: 0x17001889 RID: 6281
		// (get) Token: 0x06004F7E RID: 20350 RVA: 0x000972B8 File Offset: 0x000954B8
		// (set) Token: 0x06004F7F RID: 20351 RVA: 0x000972D4 File Offset: 0x000954D4
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

		// Token: 0x06004F80 RID: 20352 RVA: 0x00097304 File Offset: 0x00095504
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06004F81 RID: 20353 RVA: 0x0009731C File Offset: 0x0009551C
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x1700188A RID: 6282
		// (get) Token: 0x06004F82 RID: 20354 RVA: 0x00097328 File Offset: 0x00095528
		// (set) Token: 0x06004F83 RID: 20355 RVA: 0x00097354 File Offset: 0x00095554
		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
			}
		}

		// Token: 0x1700188B RID: 6283
		// (get) Token: 0x06004F84 RID: 20356 RVA: 0x00097364 File Offset: 0x00095564
		// (set) Token: 0x06004F85 RID: 20357 RVA: 0x00097384 File Offset: 0x00095584
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new int?(this.level) : null);
				}
			}
		}

		// Token: 0x06004F86 RID: 20358 RVA: 0x000973C8 File Offset: 0x000955C8
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06004F87 RID: 20359 RVA: 0x000973E0 File Offset: 0x000955E0
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x06004F88 RID: 20360 RVA: 0x000973EC File Offset: 0x000955EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001399 RID: 5017
		private string _openid;

		// Token: 0x0400139A RID: 5018
		private int? _serverid;

		// Token: 0x0400139B RID: 5019
		private string _rolename;

		// Token: 0x0400139C RID: 5020
		private int? _level;

		// Token: 0x0400139D RID: 5021
		private IExtension extensionObject;
	}
}
