using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006B7 RID: 1719
	[ProtoContract(Name = "PlatFriend")]
	[Serializable]
	public class PlatFriend : IExtensible
	{
		// Token: 0x170023B7 RID: 9143
		// (get) Token: 0x060070D5 RID: 28885 RVA: 0x000D7EC8 File Offset: 0x000D60C8
		// (set) Token: 0x060070D6 RID: 28886 RVA: 0x000D7EE9 File Offset: 0x000D60E9
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

		// Token: 0x170023B8 RID: 9144
		// (get) Token: 0x060070D7 RID: 28887 RVA: 0x000D7EF4 File Offset: 0x000D60F4
		// (set) Token: 0x060070D8 RID: 28888 RVA: 0x000D7F10 File Offset: 0x000D6110
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

		// Token: 0x060070D9 RID: 28889 RVA: 0x000D7F40 File Offset: 0x000D6140
		private bool ShouldSerializeopenid()
		{
			return this.openidSpecified;
		}

		// Token: 0x060070DA RID: 28890 RVA: 0x000D7F58 File Offset: 0x000D6158
		private void Resetopenid()
		{
			this.openidSpecified = false;
		}

		// Token: 0x170023B9 RID: 9145
		// (get) Token: 0x060070DB RID: 28891 RVA: 0x000D7F64 File Offset: 0x000D6164
		// (set) Token: 0x060070DC RID: 28892 RVA: 0x000D7F85 File Offset: 0x000D6185
		[ProtoMember(2, IsRequired = false, Name = "nickname", DataFormat = DataFormat.Default)]
		public string nickname
		{
			get
			{
				return this._nickname ?? "";
			}
			set
			{
				this._nickname = value;
			}
		}

		// Token: 0x170023BA RID: 9146
		// (get) Token: 0x060070DD RID: 28893 RVA: 0x000D7F90 File Offset: 0x000D6190
		// (set) Token: 0x060070DE RID: 28894 RVA: 0x000D7FAC File Offset: 0x000D61AC
		[XmlIgnore]
		[Browsable(false)]
		public bool nicknameSpecified
		{
			get
			{
				return this._nickname != null;
			}
			set
			{
				bool flag = value == (this._nickname == null);
				if (flag)
				{
					this._nickname = (value ? this.nickname : null);
				}
			}
		}

		// Token: 0x060070DF RID: 28895 RVA: 0x000D7FDC File Offset: 0x000D61DC
		private bool ShouldSerializenickname()
		{
			return this.nicknameSpecified;
		}

		// Token: 0x060070E0 RID: 28896 RVA: 0x000D7FF4 File Offset: 0x000D61F4
		private void Resetnickname()
		{
			this.nicknameSpecified = false;
		}

		// Token: 0x170023BB RID: 9147
		// (get) Token: 0x060070E1 RID: 28897 RVA: 0x000D8000 File Offset: 0x000D6200
		// (set) Token: 0x060070E2 RID: 28898 RVA: 0x000D8021 File Offset: 0x000D6221
		[ProtoMember(3, IsRequired = false, Name = "bigpic", DataFormat = DataFormat.Default)]
		public string bigpic
		{
			get
			{
				return this._bigpic ?? "";
			}
			set
			{
				this._bigpic = value;
			}
		}

		// Token: 0x170023BC RID: 9148
		// (get) Token: 0x060070E3 RID: 28899 RVA: 0x000D802C File Offset: 0x000D622C
		// (set) Token: 0x060070E4 RID: 28900 RVA: 0x000D8048 File Offset: 0x000D6248
		[XmlIgnore]
		[Browsable(false)]
		public bool bigpicSpecified
		{
			get
			{
				return this._bigpic != null;
			}
			set
			{
				bool flag = value == (this._bigpic == null);
				if (flag)
				{
					this._bigpic = (value ? this.bigpic : null);
				}
			}
		}

		// Token: 0x060070E5 RID: 28901 RVA: 0x000D8078 File Offset: 0x000D6278
		private bool ShouldSerializebigpic()
		{
			return this.bigpicSpecified;
		}

		// Token: 0x060070E6 RID: 28902 RVA: 0x000D8090 File Offset: 0x000D6290
		private void Resetbigpic()
		{
			this.bigpicSpecified = false;
		}

		// Token: 0x170023BD RID: 9149
		// (get) Token: 0x060070E7 RID: 28903 RVA: 0x000D809C File Offset: 0x000D629C
		// (set) Token: 0x060070E8 RID: 28904 RVA: 0x000D80BD File Offset: 0x000D62BD
		[ProtoMember(4, IsRequired = false, Name = "midpic", DataFormat = DataFormat.Default)]
		public string midpic
		{
			get
			{
				return this._midpic ?? "";
			}
			set
			{
				this._midpic = value;
			}
		}

		// Token: 0x170023BE RID: 9150
		// (get) Token: 0x060070E9 RID: 28905 RVA: 0x000D80C8 File Offset: 0x000D62C8
		// (set) Token: 0x060070EA RID: 28906 RVA: 0x000D80E4 File Offset: 0x000D62E4
		[XmlIgnore]
		[Browsable(false)]
		public bool midpicSpecified
		{
			get
			{
				return this._midpic != null;
			}
			set
			{
				bool flag = value == (this._midpic == null);
				if (flag)
				{
					this._midpic = (value ? this.midpic : null);
				}
			}
		}

		// Token: 0x060070EB RID: 28907 RVA: 0x000D8114 File Offset: 0x000D6314
		private bool ShouldSerializemidpic()
		{
			return this.midpicSpecified;
		}

		// Token: 0x060070EC RID: 28908 RVA: 0x000D812C File Offset: 0x000D632C
		private void Resetmidpic()
		{
			this.midpicSpecified = false;
		}

		// Token: 0x170023BF RID: 9151
		// (get) Token: 0x060070ED RID: 28909 RVA: 0x000D8138 File Offset: 0x000D6338
		// (set) Token: 0x060070EE RID: 28910 RVA: 0x000D8159 File Offset: 0x000D6359
		[ProtoMember(5, IsRequired = false, Name = "smallpic", DataFormat = DataFormat.Default)]
		public string smallpic
		{
			get
			{
				return this._smallpic ?? "";
			}
			set
			{
				this._smallpic = value;
			}
		}

		// Token: 0x170023C0 RID: 9152
		// (get) Token: 0x060070EF RID: 28911 RVA: 0x000D8164 File Offset: 0x000D6364
		// (set) Token: 0x060070F0 RID: 28912 RVA: 0x000D8180 File Offset: 0x000D6380
		[XmlIgnore]
		[Browsable(false)]
		public bool smallpicSpecified
		{
			get
			{
				return this._smallpic != null;
			}
			set
			{
				bool flag = value == (this._smallpic == null);
				if (flag)
				{
					this._smallpic = (value ? this.smallpic : null);
				}
			}
		}

		// Token: 0x060070F1 RID: 28913 RVA: 0x000D81B0 File Offset: 0x000D63B0
		private bool ShouldSerializesmallpic()
		{
			return this.smallpicSpecified;
		}

		// Token: 0x060070F2 RID: 28914 RVA: 0x000D81C8 File Offset: 0x000D63C8
		private void Resetsmallpic()
		{
			this.smallpicSpecified = false;
		}

		// Token: 0x060070F3 RID: 28915 RVA: 0x000D81D4 File Offset: 0x000D63D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001AED RID: 6893
		private string _openid;

		// Token: 0x04001AEE RID: 6894
		private string _nickname;

		// Token: 0x04001AEF RID: 6895
		private string _bigpic;

		// Token: 0x04001AF0 RID: 6896
		private string _midpic;

		// Token: 0x04001AF1 RID: 6897
		private string _smallpic;

		// Token: 0x04001AF2 RID: 6898
		private IExtension extensionObject;
	}
}
