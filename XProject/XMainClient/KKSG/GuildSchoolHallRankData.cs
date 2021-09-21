using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000744 RID: 1860
	[ProtoContract(Name = "GuildSchoolHallRankData")]
	[Serializable]
	public class GuildSchoolHallRankData : IExtensible
	{
		// Token: 0x1700291D RID: 10525
		// (get) Token: 0x060081AB RID: 33195 RVA: 0x000F8034 File Offset: 0x000F6234
		// (set) Token: 0x060081AC RID: 33196 RVA: 0x000F8061 File Offset: 0x000F6261
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

		// Token: 0x1700291E RID: 10526
		// (get) Token: 0x060081AD RID: 33197 RVA: 0x000F8070 File Offset: 0x000F6270
		// (set) Token: 0x060081AE RID: 33198 RVA: 0x000F8090 File Offset: 0x000F6290
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

		// Token: 0x060081AF RID: 33199 RVA: 0x000F80D4 File Offset: 0x000F62D4
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x060081B0 RID: 33200 RVA: 0x000F80EC File Offset: 0x000F62EC
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700291F RID: 10527
		// (get) Token: 0x060081B1 RID: 33201 RVA: 0x000F80F8 File Offset: 0x000F62F8
		// (set) Token: 0x060081B2 RID: 33202 RVA: 0x000F8119 File Offset: 0x000F6319
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

		// Token: 0x17002920 RID: 10528
		// (get) Token: 0x060081B3 RID: 33203 RVA: 0x000F8124 File Offset: 0x000F6324
		// (set) Token: 0x060081B4 RID: 33204 RVA: 0x000F8140 File Offset: 0x000F6340
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

		// Token: 0x060081B5 RID: 33205 RVA: 0x000F8170 File Offset: 0x000F6370
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x060081B6 RID: 33206 RVA: 0x000F8188 File Offset: 0x000F6388
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x17002921 RID: 10529
		// (get) Token: 0x060081B7 RID: 33207 RVA: 0x000F8194 File Offset: 0x000F6394
		// (set) Token: 0x060081B8 RID: 33208 RVA: 0x000F81C0 File Offset: 0x000F63C0
		[ProtoMember(3, IsRequired = false, Name = "roleprofession", DataFormat = DataFormat.TwosComplement)]
		public uint roleprofession
		{
			get
			{
				return this._roleprofession ?? 0U;
			}
			set
			{
				this._roleprofession = new uint?(value);
			}
		}

		// Token: 0x17002922 RID: 10530
		// (get) Token: 0x060081B9 RID: 33209 RVA: 0x000F81D0 File Offset: 0x000F63D0
		// (set) Token: 0x060081BA RID: 33210 RVA: 0x000F81F0 File Offset: 0x000F63F0
		[XmlIgnore]
		[Browsable(false)]
		public bool roleprofessionSpecified
		{
			get
			{
				return this._roleprofession != null;
			}
			set
			{
				bool flag = value == (this._roleprofession == null);
				if (flag)
				{
					this._roleprofession = (value ? new uint?(this.roleprofession) : null);
				}
			}
		}

		// Token: 0x060081BB RID: 33211 RVA: 0x000F8234 File Offset: 0x000F6434
		private bool ShouldSerializeroleprofession()
		{
			return this.roleprofessionSpecified;
		}

		// Token: 0x060081BC RID: 33212 RVA: 0x000F824C File Offset: 0x000F644C
		private void Resetroleprofession()
		{
			this.roleprofessionSpecified = false;
		}

		// Token: 0x17002923 RID: 10531
		// (get) Token: 0x060081BD RID: 33213 RVA: 0x000F8258 File Offset: 0x000F6458
		// (set) Token: 0x060081BE RID: 33214 RVA: 0x000F8284 File Offset: 0x000F6484
		[ProtoMember(4, IsRequired = false, Name = "weeklyschoolpoint", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyschoolpoint
		{
			get
			{
				return this._weeklyschoolpoint ?? 0U;
			}
			set
			{
				this._weeklyschoolpoint = new uint?(value);
			}
		}

		// Token: 0x17002924 RID: 10532
		// (get) Token: 0x060081BF RID: 33215 RVA: 0x000F8294 File Offset: 0x000F6494
		// (set) Token: 0x060081C0 RID: 33216 RVA: 0x000F82B4 File Offset: 0x000F64B4
		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyschoolpointSpecified
		{
			get
			{
				return this._weeklyschoolpoint != null;
			}
			set
			{
				bool flag = value == (this._weeklyschoolpoint == null);
				if (flag)
				{
					this._weeklyschoolpoint = (value ? new uint?(this.weeklyschoolpoint) : null);
				}
			}
		}

		// Token: 0x060081C1 RID: 33217 RVA: 0x000F82F8 File Offset: 0x000F64F8
		private bool ShouldSerializeweeklyschoolpoint()
		{
			return this.weeklyschoolpointSpecified;
		}

		// Token: 0x060081C2 RID: 33218 RVA: 0x000F8310 File Offset: 0x000F6510
		private void Resetweeklyschoolpoint()
		{
			this.weeklyschoolpointSpecified = false;
		}

		// Token: 0x17002925 RID: 10533
		// (get) Token: 0x060081C3 RID: 33219 RVA: 0x000F831C File Offset: 0x000F651C
		// (set) Token: 0x060081C4 RID: 33220 RVA: 0x000F8348 File Offset: 0x000F6548
		[ProtoMember(5, IsRequired = false, Name = "weeklyhallpoint", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyhallpoint
		{
			get
			{
				return this._weeklyhallpoint ?? 0U;
			}
			set
			{
				this._weeklyhallpoint = new uint?(value);
			}
		}

		// Token: 0x17002926 RID: 10534
		// (get) Token: 0x060081C5 RID: 33221 RVA: 0x000F8358 File Offset: 0x000F6558
		// (set) Token: 0x060081C6 RID: 33222 RVA: 0x000F8378 File Offset: 0x000F6578
		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyhallpointSpecified
		{
			get
			{
				return this._weeklyhallpoint != null;
			}
			set
			{
				bool flag = value == (this._weeklyhallpoint == null);
				if (flag)
				{
					this._weeklyhallpoint = (value ? new uint?(this.weeklyhallpoint) : null);
				}
			}
		}

		// Token: 0x060081C7 RID: 33223 RVA: 0x000F83BC File Offset: 0x000F65BC
		private bool ShouldSerializeweeklyhallpoint()
		{
			return this.weeklyhallpointSpecified;
		}

		// Token: 0x060081C8 RID: 33224 RVA: 0x000F83D4 File Offset: 0x000F65D4
		private void Resetweeklyhallpoint()
		{
			this.weeklyhallpointSpecified = false;
		}

		// Token: 0x17002927 RID: 10535
		// (get) Token: 0x060081C9 RID: 33225 RVA: 0x000F83E0 File Offset: 0x000F65E0
		// (set) Token: 0x060081CA RID: 33226 RVA: 0x000F840C File Offset: 0x000F660C
		[ProtoMember(6, IsRequired = false, Name = "updatetime", DataFormat = DataFormat.TwosComplement)]
		public uint updatetime
		{
			get
			{
				return this._updatetime ?? 0U;
			}
			set
			{
				this._updatetime = new uint?(value);
			}
		}

		// Token: 0x17002928 RID: 10536
		// (get) Token: 0x060081CB RID: 33227 RVA: 0x000F841C File Offset: 0x000F661C
		// (set) Token: 0x060081CC RID: 33228 RVA: 0x000F843C File Offset: 0x000F663C
		[XmlIgnore]
		[Browsable(false)]
		public bool updatetimeSpecified
		{
			get
			{
				return this._updatetime != null;
			}
			set
			{
				bool flag = value == (this._updatetime == null);
				if (flag)
				{
					this._updatetime = (value ? new uint?(this.updatetime) : null);
				}
			}
		}

		// Token: 0x060081CD RID: 33229 RVA: 0x000F8480 File Offset: 0x000F6680
		private bool ShouldSerializeupdatetime()
		{
			return this.updatetimeSpecified;
		}

		// Token: 0x060081CE RID: 33230 RVA: 0x000F8498 File Offset: 0x000F6698
		private void Resetupdatetime()
		{
			this.updatetimeSpecified = false;
		}

		// Token: 0x060081CF RID: 33231 RVA: 0x000F84A4 File Offset: 0x000F66A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E55 RID: 7765
		private ulong? _roleid;

		// Token: 0x04001E56 RID: 7766
		private string _rolename;

		// Token: 0x04001E57 RID: 7767
		private uint? _roleprofession;

		// Token: 0x04001E58 RID: 7768
		private uint? _weeklyschoolpoint;

		// Token: 0x04001E59 RID: 7769
		private uint? _weeklyhallpoint;

		// Token: 0x04001E5A RID: 7770
		private uint? _updatetime;

		// Token: 0x04001E5B RID: 7771
		private IExtension extensionObject;
	}
}
