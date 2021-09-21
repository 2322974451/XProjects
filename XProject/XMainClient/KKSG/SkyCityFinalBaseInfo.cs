using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005D6 RID: 1494
	[ProtoContract(Name = "SkyCityFinalBaseInfo")]
	[Serializable]
	public class SkyCityFinalBaseInfo : IExtensible
	{
		// Token: 0x17001A8C RID: 6796
		// (get) Token: 0x0600558C RID: 21900 RVA: 0x000A2D28 File Offset: 0x000A0F28
		// (set) Token: 0x0600558D RID: 21901 RVA: 0x000A2D55 File Offset: 0x000A0F55
		[ProtoMember(1, IsRequired = false, Name = "uuid", DataFormat = DataFormat.TwosComplement)]
		public ulong uuid
		{
			get
			{
				return this._uuid ?? 0UL;
			}
			set
			{
				this._uuid = new ulong?(value);
			}
		}

		// Token: 0x17001A8D RID: 6797
		// (get) Token: 0x0600558E RID: 21902 RVA: 0x000A2D64 File Offset: 0x000A0F64
		// (set) Token: 0x0600558F RID: 21903 RVA: 0x000A2D84 File Offset: 0x000A0F84
		[XmlIgnore]
		[Browsable(false)]
		public bool uuidSpecified
		{
			get
			{
				return this._uuid != null;
			}
			set
			{
				bool flag = value == (this._uuid == null);
				if (flag)
				{
					this._uuid = (value ? new ulong?(this.uuid) : null);
				}
			}
		}

		// Token: 0x06005590 RID: 21904 RVA: 0x000A2DC8 File Offset: 0x000A0FC8
		private bool ShouldSerializeuuid()
		{
			return this.uuidSpecified;
		}

		// Token: 0x06005591 RID: 21905 RVA: 0x000A2DE0 File Offset: 0x000A0FE0
		private void Resetuuid()
		{
			this.uuidSpecified = false;
		}

		// Token: 0x17001A8E RID: 6798
		// (get) Token: 0x06005592 RID: 21906 RVA: 0x000A2DEC File Offset: 0x000A0FEC
		// (set) Token: 0x06005593 RID: 21907 RVA: 0x000A2E18 File Offset: 0x000A1018
		[ProtoMember(2, IsRequired = false, Name = "job", DataFormat = DataFormat.TwosComplement)]
		public uint job
		{
			get
			{
				return this._job ?? 0U;
			}
			set
			{
				this._job = new uint?(value);
			}
		}

		// Token: 0x17001A8F RID: 6799
		// (get) Token: 0x06005594 RID: 21908 RVA: 0x000A2E28 File Offset: 0x000A1028
		// (set) Token: 0x06005595 RID: 21909 RVA: 0x000A2E48 File Offset: 0x000A1048
		[XmlIgnore]
		[Browsable(false)]
		public bool jobSpecified
		{
			get
			{
				return this._job != null;
			}
			set
			{
				bool flag = value == (this._job == null);
				if (flag)
				{
					this._job = (value ? new uint?(this.job) : null);
				}
			}
		}

		// Token: 0x06005596 RID: 21910 RVA: 0x000A2E8C File Offset: 0x000A108C
		private bool ShouldSerializejob()
		{
			return this.jobSpecified;
		}

		// Token: 0x06005597 RID: 21911 RVA: 0x000A2EA4 File Offset: 0x000A10A4
		private void Resetjob()
		{
			this.jobSpecified = false;
		}

		// Token: 0x17001A90 RID: 6800
		// (get) Token: 0x06005598 RID: 21912 RVA: 0x000A2EB0 File Offset: 0x000A10B0
		// (set) Token: 0x06005599 RID: 21913 RVA: 0x000A2EDC File Offset: 0x000A10DC
		[ProtoMember(3, IsRequired = false, Name = "killer", DataFormat = DataFormat.TwosComplement)]
		public uint killer
		{
			get
			{
				return this._killer ?? 0U;
			}
			set
			{
				this._killer = new uint?(value);
			}
		}

		// Token: 0x17001A91 RID: 6801
		// (get) Token: 0x0600559A RID: 21914 RVA: 0x000A2EEC File Offset: 0x000A10EC
		// (set) Token: 0x0600559B RID: 21915 RVA: 0x000A2F0C File Offset: 0x000A110C
		[XmlIgnore]
		[Browsable(false)]
		public bool killerSpecified
		{
			get
			{
				return this._killer != null;
			}
			set
			{
				bool flag = value == (this._killer == null);
				if (flag)
				{
					this._killer = (value ? new uint?(this.killer) : null);
				}
			}
		}

		// Token: 0x0600559C RID: 21916 RVA: 0x000A2F50 File Offset: 0x000A1150
		private bool ShouldSerializekiller()
		{
			return this.killerSpecified;
		}

		// Token: 0x0600559D RID: 21917 RVA: 0x000A2F68 File Offset: 0x000A1168
		private void Resetkiller()
		{
			this.killerSpecified = false;
		}

		// Token: 0x17001A92 RID: 6802
		// (get) Token: 0x0600559E RID: 21918 RVA: 0x000A2F74 File Offset: 0x000A1174
		// (set) Token: 0x0600559F RID: 21919 RVA: 0x000A2FA0 File Offset: 0x000A11A0
		[ProtoMember(4, IsRequired = false, Name = "dead", DataFormat = DataFormat.TwosComplement)]
		public uint dead
		{
			get
			{
				return this._dead ?? 0U;
			}
			set
			{
				this._dead = new uint?(value);
			}
		}

		// Token: 0x17001A93 RID: 6803
		// (get) Token: 0x060055A0 RID: 21920 RVA: 0x000A2FB0 File Offset: 0x000A11B0
		// (set) Token: 0x060055A1 RID: 21921 RVA: 0x000A2FD0 File Offset: 0x000A11D0
		[XmlIgnore]
		[Browsable(false)]
		public bool deadSpecified
		{
			get
			{
				return this._dead != null;
			}
			set
			{
				bool flag = value == (this._dead == null);
				if (flag)
				{
					this._dead = (value ? new uint?(this.dead) : null);
				}
			}
		}

		// Token: 0x060055A2 RID: 21922 RVA: 0x000A3014 File Offset: 0x000A1214
		private bool ShouldSerializedead()
		{
			return this.deadSpecified;
		}

		// Token: 0x060055A3 RID: 21923 RVA: 0x000A302C File Offset: 0x000A122C
		private void Resetdead()
		{
			this.deadSpecified = false;
		}

		// Token: 0x17001A94 RID: 6804
		// (get) Token: 0x060055A4 RID: 21924 RVA: 0x000A3038 File Offset: 0x000A1238
		// (set) Token: 0x060055A5 RID: 21925 RVA: 0x000A3064 File Offset: 0x000A1264
		[ProtoMember(5, IsRequired = false, Name = "intimategree", DataFormat = DataFormat.TwosComplement)]
		public uint intimategree
		{
			get
			{
				return this._intimategree ?? 0U;
			}
			set
			{
				this._intimategree = new uint?(value);
			}
		}

		// Token: 0x17001A95 RID: 6805
		// (get) Token: 0x060055A6 RID: 21926 RVA: 0x000A3074 File Offset: 0x000A1274
		// (set) Token: 0x060055A7 RID: 21927 RVA: 0x000A3094 File Offset: 0x000A1294
		[XmlIgnore]
		[Browsable(false)]
		public bool intimategreeSpecified
		{
			get
			{
				return this._intimategree != null;
			}
			set
			{
				bool flag = value == (this._intimategree == null);
				if (flag)
				{
					this._intimategree = (value ? new uint?(this.intimategree) : null);
				}
			}
		}

		// Token: 0x060055A8 RID: 21928 RVA: 0x000A30D8 File Offset: 0x000A12D8
		private bool ShouldSerializeintimategree()
		{
			return this.intimategreeSpecified;
		}

		// Token: 0x060055A9 RID: 21929 RVA: 0x000A30F0 File Offset: 0x000A12F0
		private void Resetintimategree()
		{
			this.intimategreeSpecified = false;
		}

		// Token: 0x17001A96 RID: 6806
		// (get) Token: 0x060055AA RID: 21930 RVA: 0x000A30FC File Offset: 0x000A12FC
		// (set) Token: 0x060055AB RID: 21931 RVA: 0x000A3128 File Offset: 0x000A1328
		[ProtoMember(6, IsRequired = false, Name = "ismvp", DataFormat = DataFormat.Default)]
		public bool ismvp
		{
			get
			{
				return this._ismvp ?? false;
			}
			set
			{
				this._ismvp = new bool?(value);
			}
		}

		// Token: 0x17001A97 RID: 6807
		// (get) Token: 0x060055AC RID: 21932 RVA: 0x000A3138 File Offset: 0x000A1338
		// (set) Token: 0x060055AD RID: 21933 RVA: 0x000A3158 File Offset: 0x000A1358
		[XmlIgnore]
		[Browsable(false)]
		public bool ismvpSpecified
		{
			get
			{
				return this._ismvp != null;
			}
			set
			{
				bool flag = value == (this._ismvp == null);
				if (flag)
				{
					this._ismvp = (value ? new bool?(this.ismvp) : null);
				}
			}
		}

		// Token: 0x060055AE RID: 21934 RVA: 0x000A319C File Offset: 0x000A139C
		private bool ShouldSerializeismvp()
		{
			return this.ismvpSpecified;
		}

		// Token: 0x060055AF RID: 21935 RVA: 0x000A31B4 File Offset: 0x000A13B4
		private void Resetismvp()
		{
			this.ismvpSpecified = false;
		}

		// Token: 0x17001A98 RID: 6808
		// (get) Token: 0x060055B0 RID: 21936 RVA: 0x000A31C0 File Offset: 0x000A13C0
		// (set) Token: 0x060055B1 RID: 21937 RVA: 0x000A31EC File Offset: 0x000A13EC
		[ProtoMember(7, IsRequired = false, Name = "isfriend", DataFormat = DataFormat.Default)]
		public bool isfriend
		{
			get
			{
				return this._isfriend ?? false;
			}
			set
			{
				this._isfriend = new bool?(value);
			}
		}

		// Token: 0x17001A99 RID: 6809
		// (get) Token: 0x060055B2 RID: 21938 RVA: 0x000A31FC File Offset: 0x000A13FC
		// (set) Token: 0x060055B3 RID: 21939 RVA: 0x000A321C File Offset: 0x000A141C
		[XmlIgnore]
		[Browsable(false)]
		public bool isfriendSpecified
		{
			get
			{
				return this._isfriend != null;
			}
			set
			{
				bool flag = value == (this._isfriend == null);
				if (flag)
				{
					this._isfriend = (value ? new bool?(this.isfriend) : null);
				}
			}
		}

		// Token: 0x060055B4 RID: 21940 RVA: 0x000A3260 File Offset: 0x000A1460
		private bool ShouldSerializeisfriend()
		{
			return this.isfriendSpecified;
		}

		// Token: 0x060055B5 RID: 21941 RVA: 0x000A3278 File Offset: 0x000A1478
		private void Resetisfriend()
		{
			this.isfriendSpecified = false;
		}

		// Token: 0x060055B6 RID: 21942 RVA: 0x000A3284 File Offset: 0x000A1484
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040014DA RID: 5338
		private ulong? _uuid;

		// Token: 0x040014DB RID: 5339
		private uint? _job;

		// Token: 0x040014DC RID: 5340
		private uint? _killer;

		// Token: 0x040014DD RID: 5341
		private uint? _dead;

		// Token: 0x040014DE RID: 5342
		private uint? _intimategree;

		// Token: 0x040014DF RID: 5343
		private bool? _ismvp;

		// Token: 0x040014E0 RID: 5344
		private bool? _isfriend;

		// Token: 0x040014E1 RID: 5345
		private IExtension extensionObject;
	}
}
