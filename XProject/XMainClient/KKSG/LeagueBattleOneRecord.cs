using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006F7 RID: 1783
	[ProtoContract(Name = "LeagueBattleOneRecord")]
	[Serializable]
	public class LeagueBattleOneRecord : IExtensible
	{
		// Token: 0x17002603 RID: 9731
		// (get) Token: 0x06007806 RID: 30726 RVA: 0x000E597C File Offset: 0x000E3B7C
		// (set) Token: 0x06007807 RID: 30727 RVA: 0x000E59A9 File Offset: 0x000E3BA9
		[ProtoMember(1, IsRequired = false, Name = "other_teamid", DataFormat = DataFormat.TwosComplement)]
		public ulong other_teamid
		{
			get
			{
				return this._other_teamid ?? 0UL;
			}
			set
			{
				this._other_teamid = new ulong?(value);
			}
		}

		// Token: 0x17002604 RID: 9732
		// (get) Token: 0x06007808 RID: 30728 RVA: 0x000E59B8 File Offset: 0x000E3BB8
		// (set) Token: 0x06007809 RID: 30729 RVA: 0x000E59D8 File Offset: 0x000E3BD8
		[XmlIgnore]
		[Browsable(false)]
		public bool other_teamidSpecified
		{
			get
			{
				return this._other_teamid != null;
			}
			set
			{
				bool flag = value == (this._other_teamid == null);
				if (flag)
				{
					this._other_teamid = (value ? new ulong?(this.other_teamid) : null);
				}
			}
		}

		// Token: 0x0600780A RID: 30730 RVA: 0x000E5A1C File Offset: 0x000E3C1C
		private bool ShouldSerializeother_teamid()
		{
			return this.other_teamidSpecified;
		}

		// Token: 0x0600780B RID: 30731 RVA: 0x000E5A34 File Offset: 0x000E3C34
		private void Resetother_teamid()
		{
			this.other_teamidSpecified = false;
		}

		// Token: 0x17002605 RID: 9733
		// (get) Token: 0x0600780C RID: 30732 RVA: 0x000E5A40 File Offset: 0x000E3C40
		// (set) Token: 0x0600780D RID: 30733 RVA: 0x000E5A61 File Offset: 0x000E3C61
		[ProtoMember(2, IsRequired = false, Name = "other_teamname", DataFormat = DataFormat.Default)]
		public string other_teamname
		{
			get
			{
				return this._other_teamname ?? "";
			}
			set
			{
				this._other_teamname = value;
			}
		}

		// Token: 0x17002606 RID: 9734
		// (get) Token: 0x0600780E RID: 30734 RVA: 0x000E5A6C File Offset: 0x000E3C6C
		// (set) Token: 0x0600780F RID: 30735 RVA: 0x000E5A88 File Offset: 0x000E3C88
		[XmlIgnore]
		[Browsable(false)]
		public bool other_teamnameSpecified
		{
			get
			{
				return this._other_teamname != null;
			}
			set
			{
				bool flag = value == (this._other_teamname == null);
				if (flag)
				{
					this._other_teamname = (value ? this.other_teamname : null);
				}
			}
		}

		// Token: 0x06007810 RID: 30736 RVA: 0x000E5AB8 File Offset: 0x000E3CB8
		private bool ShouldSerializeother_teamname()
		{
			return this.other_teamnameSpecified;
		}

		// Token: 0x06007811 RID: 30737 RVA: 0x000E5AD0 File Offset: 0x000E3CD0
		private void Resetother_teamname()
		{
			this.other_teamnameSpecified = false;
		}

		// Token: 0x17002607 RID: 9735
		// (get) Token: 0x06007812 RID: 30738 RVA: 0x000E5ADC File Offset: 0x000E3CDC
		// (set) Token: 0x06007813 RID: 30739 RVA: 0x000E5AFD File Offset: 0x000E3CFD
		[ProtoMember(3, IsRequired = false, Name = "servername", DataFormat = DataFormat.Default)]
		public string servername
		{
			get
			{
				return this._servername ?? "";
			}
			set
			{
				this._servername = value;
			}
		}

		// Token: 0x17002608 RID: 9736
		// (get) Token: 0x06007814 RID: 30740 RVA: 0x000E5B08 File Offset: 0x000E3D08
		// (set) Token: 0x06007815 RID: 30741 RVA: 0x000E5B24 File Offset: 0x000E3D24
		[XmlIgnore]
		[Browsable(false)]
		public bool servernameSpecified
		{
			get
			{
				return this._servername != null;
			}
			set
			{
				bool flag = value == (this._servername == null);
				if (flag)
				{
					this._servername = (value ? this.servername : null);
				}
			}
		}

		// Token: 0x06007816 RID: 30742 RVA: 0x000E5B54 File Offset: 0x000E3D54
		private bool ShouldSerializeservername()
		{
			return this.servernameSpecified;
		}

		// Token: 0x06007817 RID: 30743 RVA: 0x000E5B6C File Offset: 0x000E3D6C
		private void Resetservername()
		{
			this.servernameSpecified = false;
		}

		// Token: 0x17002609 RID: 9737
		// (get) Token: 0x06007818 RID: 30744 RVA: 0x000E5B78 File Offset: 0x000E3D78
		// (set) Token: 0x06007819 RID: 30745 RVA: 0x000E5BA4 File Offset: 0x000E3DA4
		[ProtoMember(4, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		// Token: 0x1700260A RID: 9738
		// (get) Token: 0x0600781A RID: 30746 RVA: 0x000E5BB4 File Offset: 0x000E3DB4
		// (set) Token: 0x0600781B RID: 30747 RVA: 0x000E5BD4 File Offset: 0x000E3DD4
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
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		// Token: 0x0600781C RID: 30748 RVA: 0x000E5C18 File Offset: 0x000E3E18
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x0600781D RID: 30749 RVA: 0x000E5C30 File Offset: 0x000E3E30
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x1700260B RID: 9739
		// (get) Token: 0x0600781E RID: 30750 RVA: 0x000E5C3C File Offset: 0x000E3E3C
		// (set) Token: 0x0600781F RID: 30751 RVA: 0x000E5C68 File Offset: 0x000E3E68
		[ProtoMember(5, IsRequired = false, Name = "score_change", DataFormat = DataFormat.TwosComplement)]
		public int score_change
		{
			get
			{
				return this._score_change ?? 0;
			}
			set
			{
				this._score_change = new int?(value);
			}
		}

		// Token: 0x1700260C RID: 9740
		// (get) Token: 0x06007820 RID: 30752 RVA: 0x000E5C78 File Offset: 0x000E3E78
		// (set) Token: 0x06007821 RID: 30753 RVA: 0x000E5C98 File Offset: 0x000E3E98
		[XmlIgnore]
		[Browsable(false)]
		public bool score_changeSpecified
		{
			get
			{
				return this._score_change != null;
			}
			set
			{
				bool flag = value == (this._score_change == null);
				if (flag)
				{
					this._score_change = (value ? new int?(this.score_change) : null);
				}
			}
		}

		// Token: 0x06007822 RID: 30754 RVA: 0x000E5CDC File Offset: 0x000E3EDC
		private bool ShouldSerializescore_change()
		{
			return this.score_changeSpecified;
		}

		// Token: 0x06007823 RID: 30755 RVA: 0x000E5CF4 File Offset: 0x000E3EF4
		private void Resetscore_change()
		{
			this.score_changeSpecified = false;
		}

		// Token: 0x1700260D RID: 9741
		// (get) Token: 0x06007824 RID: 30756 RVA: 0x000E5D00 File Offset: 0x000E3F00
		// (set) Token: 0x06007825 RID: 30757 RVA: 0x000E5D2C File Offset: 0x000E3F2C
		[ProtoMember(6, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public PkResultType result
		{
			get
			{
				return this._result ?? PkResultType.PkResult_Win;
			}
			set
			{
				this._result = new PkResultType?(value);
			}
		}

		// Token: 0x1700260E RID: 9742
		// (get) Token: 0x06007826 RID: 30758 RVA: 0x000E5D3C File Offset: 0x000E3F3C
		// (set) Token: 0x06007827 RID: 30759 RVA: 0x000E5D5C File Offset: 0x000E3F5C
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new PkResultType?(this.result) : null);
				}
			}
		}

		// Token: 0x06007828 RID: 30760 RVA: 0x000E5DA0 File Offset: 0x000E3FA0
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06007829 RID: 30761 RVA: 0x000E5DB8 File Offset: 0x000E3FB8
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700260F RID: 9743
		// (get) Token: 0x0600782A RID: 30762 RVA: 0x000E5DC4 File Offset: 0x000E3FC4
		// (set) Token: 0x0600782B RID: 30763 RVA: 0x000E5DF0 File Offset: 0x000E3FF0
		[ProtoMember(7, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x17002610 RID: 9744
		// (get) Token: 0x0600782C RID: 30764 RVA: 0x000E5E00 File Offset: 0x000E4000
		// (set) Token: 0x0600782D RID: 30765 RVA: 0x000E5E20 File Offset: 0x000E4020
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x0600782E RID: 30766 RVA: 0x000E5E64 File Offset: 0x000E4064
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x0600782F RID: 30767 RVA: 0x000E5E7C File Offset: 0x000E407C
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x17002611 RID: 9745
		// (get) Token: 0x06007830 RID: 30768 RVA: 0x000E5E88 File Offset: 0x000E4088
		// (set) Token: 0x06007831 RID: 30769 RVA: 0x000E5EB4 File Offset: 0x000E40B4
		[ProtoMember(8, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public LeagueBattleType type
		{
			get
			{
				return this._type ?? LeagueBattleType.LeagueBattleType_RacePoint;
			}
			set
			{
				this._type = new LeagueBattleType?(value);
			}
		}

		// Token: 0x17002612 RID: 9746
		// (get) Token: 0x06007832 RID: 30770 RVA: 0x000E5EC4 File Offset: 0x000E40C4
		// (set) Token: 0x06007833 RID: 30771 RVA: 0x000E5EE4 File Offset: 0x000E40E4
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
					this._type = (value ? new LeagueBattleType?(this.type) : null);
				}
			}
		}

		// Token: 0x06007834 RID: 30772 RVA: 0x000E5F28 File Offset: 0x000E4128
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06007835 RID: 30773 RVA: 0x000E5F40 File Offset: 0x000E4140
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06007836 RID: 30774 RVA: 0x000E5F4C File Offset: 0x000E414C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C64 RID: 7268
		private ulong? _other_teamid;

		// Token: 0x04001C65 RID: 7269
		private string _other_teamname;

		// Token: 0x04001C66 RID: 7270
		private string _servername;

		// Token: 0x04001C67 RID: 7271
		private uint? _serverid;

		// Token: 0x04001C68 RID: 7272
		private int? _score_change;

		// Token: 0x04001C69 RID: 7273
		private PkResultType? _result;

		// Token: 0x04001C6A RID: 7274
		private uint? _time;

		// Token: 0x04001C6B RID: 7275
		private LeagueBattleType? _type;

		// Token: 0x04001C6C RID: 7276
		private IExtension extensionObject;
	}
}
