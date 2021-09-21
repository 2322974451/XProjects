using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000706 RID: 1798
	[ProtoContract(Name = "CustomBattleConfig")]
	[Serializable]
	public class CustomBattleConfig : IExtensible
	{
		// Token: 0x17002681 RID: 9857
		// (get) Token: 0x0600798E RID: 31118 RVA: 0x000E8628 File Offset: 0x000E6828
		// (set) Token: 0x0600798F RID: 31119 RVA: 0x000E8654 File Offset: 0x000E6854
		[ProtoMember(1, IsRequired = false, Name = "tagtype", DataFormat = DataFormat.TwosComplement)]
		public uint tagtype
		{
			get
			{
				return this._tagtype ?? 0U;
			}
			set
			{
				this._tagtype = new uint?(value);
			}
		}

		// Token: 0x17002682 RID: 9858
		// (get) Token: 0x06007990 RID: 31120 RVA: 0x000E8664 File Offset: 0x000E6864
		// (set) Token: 0x06007991 RID: 31121 RVA: 0x000E8684 File Offset: 0x000E6884
		[XmlIgnore]
		[Browsable(false)]
		public bool tagtypeSpecified
		{
			get
			{
				return this._tagtype != null;
			}
			set
			{
				bool flag = value == (this._tagtype == null);
				if (flag)
				{
					this._tagtype = (value ? new uint?(this.tagtype) : null);
				}
			}
		}

		// Token: 0x06007992 RID: 31122 RVA: 0x000E86C8 File Offset: 0x000E68C8
		private bool ShouldSerializetagtype()
		{
			return this.tagtypeSpecified;
		}

		// Token: 0x06007993 RID: 31123 RVA: 0x000E86E0 File Offset: 0x000E68E0
		private void Resettagtype()
		{
			this.tagtypeSpecified = false;
		}

		// Token: 0x17002683 RID: 9859
		// (get) Token: 0x06007994 RID: 31124 RVA: 0x000E86EC File Offset: 0x000E68EC
		// (set) Token: 0x06007995 RID: 31125 RVA: 0x000E8718 File Offset: 0x000E6918
		[ProtoMember(2, IsRequired = false, Name = "configid", DataFormat = DataFormat.TwosComplement)]
		public uint configid
		{
			get
			{
				return this._configid ?? 0U;
			}
			set
			{
				this._configid = new uint?(value);
			}
		}

		// Token: 0x17002684 RID: 9860
		// (get) Token: 0x06007996 RID: 31126 RVA: 0x000E8728 File Offset: 0x000E6928
		// (set) Token: 0x06007997 RID: 31127 RVA: 0x000E8748 File Offset: 0x000E6948
		[XmlIgnore]
		[Browsable(false)]
		public bool configidSpecified
		{
			get
			{
				return this._configid != null;
			}
			set
			{
				bool flag = value == (this._configid == null);
				if (flag)
				{
					this._configid = (value ? new uint?(this.configid) : null);
				}
			}
		}

		// Token: 0x06007998 RID: 31128 RVA: 0x000E878C File Offset: 0x000E698C
		private bool ShouldSerializeconfigid()
		{
			return this.configidSpecified;
		}

		// Token: 0x06007999 RID: 31129 RVA: 0x000E87A4 File Offset: 0x000E69A4
		private void Resetconfigid()
		{
			this.configidSpecified = false;
		}

		// Token: 0x17002685 RID: 9861
		// (get) Token: 0x0600799A RID: 31130 RVA: 0x000E87B0 File Offset: 0x000E69B0
		// (set) Token: 0x0600799B RID: 31131 RVA: 0x000E87DC File Offset: 0x000E69DC
		[ProtoMember(3, IsRequired = false, Name = "scalemask", DataFormat = DataFormat.TwosComplement)]
		public uint scalemask
		{
			get
			{
				return this._scalemask ?? 0U;
			}
			set
			{
				this._scalemask = new uint?(value);
			}
		}

		// Token: 0x17002686 RID: 9862
		// (get) Token: 0x0600799C RID: 31132 RVA: 0x000E87EC File Offset: 0x000E69EC
		// (set) Token: 0x0600799D RID: 31133 RVA: 0x000E880C File Offset: 0x000E6A0C
		[XmlIgnore]
		[Browsable(false)]
		public bool scalemaskSpecified
		{
			get
			{
				return this._scalemask != null;
			}
			set
			{
				bool flag = value == (this._scalemask == null);
				if (flag)
				{
					this._scalemask = (value ? new uint?(this.scalemask) : null);
				}
			}
		}

		// Token: 0x0600799E RID: 31134 RVA: 0x000E8850 File Offset: 0x000E6A50
		private bool ShouldSerializescalemask()
		{
			return this.scalemaskSpecified;
		}

		// Token: 0x0600799F RID: 31135 RVA: 0x000E8868 File Offset: 0x000E6A68
		private void Resetscalemask()
		{
			this.scalemaskSpecified = false;
		}

		// Token: 0x17002687 RID: 9863
		// (get) Token: 0x060079A0 RID: 31136 RVA: 0x000E8874 File Offset: 0x000E6A74
		// (set) Token: 0x060079A1 RID: 31137 RVA: 0x000E8895 File Offset: 0x000E6A95
		[ProtoMember(4, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17002688 RID: 9864
		// (get) Token: 0x060079A2 RID: 31138 RVA: 0x000E88A0 File Offset: 0x000E6AA0
		// (set) Token: 0x060079A3 RID: 31139 RVA: 0x000E88BC File Offset: 0x000E6ABC
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x060079A4 RID: 31140 RVA: 0x000E88EC File Offset: 0x000E6AEC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060079A5 RID: 31141 RVA: 0x000E8904 File Offset: 0x000E6B04
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002689 RID: 9865
		// (get) Token: 0x060079A6 RID: 31142 RVA: 0x000E8910 File Offset: 0x000E6B10
		// (set) Token: 0x060079A7 RID: 31143 RVA: 0x000E8931 File Offset: 0x000E6B31
		[ProtoMember(5, IsRequired = false, Name = "desc", DataFormat = DataFormat.Default)]
		public string desc
		{
			get
			{
				return this._desc ?? "";
			}
			set
			{
				this._desc = value;
			}
		}

		// Token: 0x1700268A RID: 9866
		// (get) Token: 0x060079A8 RID: 31144 RVA: 0x000E893C File Offset: 0x000E6B3C
		// (set) Token: 0x060079A9 RID: 31145 RVA: 0x000E8958 File Offset: 0x000E6B58
		[XmlIgnore]
		[Browsable(false)]
		public bool descSpecified
		{
			get
			{
				return this._desc != null;
			}
			set
			{
				bool flag = value == (this._desc == null);
				if (flag)
				{
					this._desc = (value ? this.desc : null);
				}
			}
		}

		// Token: 0x060079AA RID: 31146 RVA: 0x000E8988 File Offset: 0x000E6B88
		private bool ShouldSerializedesc()
		{
			return this.descSpecified;
		}

		// Token: 0x060079AB RID: 31147 RVA: 0x000E89A0 File Offset: 0x000E6BA0
		private void Resetdesc()
		{
			this.descSpecified = false;
		}

		// Token: 0x1700268B RID: 9867
		// (get) Token: 0x060079AC RID: 31148 RVA: 0x000E89AC File Offset: 0x000E6BAC
		// (set) Token: 0x060079AD RID: 31149 RVA: 0x000E89D8 File Offset: 0x000E6BD8
		[ProtoMember(6, IsRequired = false, Name = "haspassword", DataFormat = DataFormat.Default)]
		public bool haspassword
		{
			get
			{
				return this._haspassword ?? false;
			}
			set
			{
				this._haspassword = new bool?(value);
			}
		}

		// Token: 0x1700268C RID: 9868
		// (get) Token: 0x060079AE RID: 31150 RVA: 0x000E89E8 File Offset: 0x000E6BE8
		// (set) Token: 0x060079AF RID: 31151 RVA: 0x000E8A08 File Offset: 0x000E6C08
		[XmlIgnore]
		[Browsable(false)]
		public bool haspasswordSpecified
		{
			get
			{
				return this._haspassword != null;
			}
			set
			{
				bool flag = value == (this._haspassword == null);
				if (flag)
				{
					this._haspassword = (value ? new bool?(this.haspassword) : null);
				}
			}
		}

		// Token: 0x060079B0 RID: 31152 RVA: 0x000E8A4C File Offset: 0x000E6C4C
		private bool ShouldSerializehaspassword()
		{
			return this.haspasswordSpecified;
		}

		// Token: 0x060079B1 RID: 31153 RVA: 0x000E8A64 File Offset: 0x000E6C64
		private void Resethaspassword()
		{
			this.haspasswordSpecified = false;
		}

		// Token: 0x1700268D RID: 9869
		// (get) Token: 0x060079B2 RID: 31154 RVA: 0x000E8A70 File Offset: 0x000E6C70
		// (set) Token: 0x060079B3 RID: 31155 RVA: 0x000E8A91 File Offset: 0x000E6C91
		[ProtoMember(7, IsRequired = false, Name = "password", DataFormat = DataFormat.Default)]
		public string password
		{
			get
			{
				return this._password ?? "";
			}
			set
			{
				this._password = value;
			}
		}

		// Token: 0x1700268E RID: 9870
		// (get) Token: 0x060079B4 RID: 31156 RVA: 0x000E8A9C File Offset: 0x000E6C9C
		// (set) Token: 0x060079B5 RID: 31157 RVA: 0x000E8AB8 File Offset: 0x000E6CB8
		[XmlIgnore]
		[Browsable(false)]
		public bool passwordSpecified
		{
			get
			{
				return this._password != null;
			}
			set
			{
				bool flag = value == (this._password == null);
				if (flag)
				{
					this._password = (value ? this.password : null);
				}
			}
		}

		// Token: 0x060079B6 RID: 31158 RVA: 0x000E8AE8 File Offset: 0x000E6CE8
		private bool ShouldSerializepassword()
		{
			return this.passwordSpecified;
		}

		// Token: 0x060079B7 RID: 31159 RVA: 0x000E8B00 File Offset: 0x000E6D00
		private void Resetpassword()
		{
			this.passwordSpecified = false;
		}

		// Token: 0x1700268F RID: 9871
		// (get) Token: 0x060079B8 RID: 31160 RVA: 0x000E8B0C File Offset: 0x000E6D0C
		// (set) Token: 0x060079B9 RID: 31161 RVA: 0x000E8B38 File Offset: 0x000E6D38
		[ProtoMember(8, IsRequired = false, Name = "isfair", DataFormat = DataFormat.Default)]
		public bool isfair
		{
			get
			{
				return this._isfair ?? false;
			}
			set
			{
				this._isfair = new bool?(value);
			}
		}

		// Token: 0x17002690 RID: 9872
		// (get) Token: 0x060079BA RID: 31162 RVA: 0x000E8B48 File Offset: 0x000E6D48
		// (set) Token: 0x060079BB RID: 31163 RVA: 0x000E8B68 File Offset: 0x000E6D68
		[XmlIgnore]
		[Browsable(false)]
		public bool isfairSpecified
		{
			get
			{
				return this._isfair != null;
			}
			set
			{
				bool flag = value == (this._isfair == null);
				if (flag)
				{
					this._isfair = (value ? new bool?(this.isfair) : null);
				}
			}
		}

		// Token: 0x060079BC RID: 31164 RVA: 0x000E8BAC File Offset: 0x000E6DAC
		private bool ShouldSerializeisfair()
		{
			return this.isfairSpecified;
		}

		// Token: 0x060079BD RID: 31165 RVA: 0x000E8BC4 File Offset: 0x000E6DC4
		private void Resetisfair()
		{
			this.isfairSpecified = false;
		}

		// Token: 0x17002691 RID: 9873
		// (get) Token: 0x060079BE RID: 31166 RVA: 0x000E8BD0 File Offset: 0x000E6DD0
		// (set) Token: 0x060079BF RID: 31167 RVA: 0x000E8BFC File Offset: 0x000E6DFC
		[ProtoMember(9, IsRequired = false, Name = "battletime", DataFormat = DataFormat.TwosComplement)]
		public uint battletime
		{
			get
			{
				return this._battletime ?? 0U;
			}
			set
			{
				this._battletime = new uint?(value);
			}
		}

		// Token: 0x17002692 RID: 9874
		// (get) Token: 0x060079C0 RID: 31168 RVA: 0x000E8C0C File Offset: 0x000E6E0C
		// (set) Token: 0x060079C1 RID: 31169 RVA: 0x000E8C2C File Offset: 0x000E6E2C
		[XmlIgnore]
		[Browsable(false)]
		public bool battletimeSpecified
		{
			get
			{
				return this._battletime != null;
			}
			set
			{
				bool flag = value == (this._battletime == null);
				if (flag)
				{
					this._battletime = (value ? new uint?(this.battletime) : null);
				}
			}
		}

		// Token: 0x060079C2 RID: 31170 RVA: 0x000E8C70 File Offset: 0x000E6E70
		private bool ShouldSerializebattletime()
		{
			return this.battletimeSpecified;
		}

		// Token: 0x060079C3 RID: 31171 RVA: 0x000E8C88 File Offset: 0x000E6E88
		private void Resetbattletime()
		{
			this.battletimeSpecified = false;
		}

		// Token: 0x17002693 RID: 9875
		// (get) Token: 0x060079C4 RID: 31172 RVA: 0x000E8C94 File Offset: 0x000E6E94
		// (set) Token: 0x060079C5 RID: 31173 RVA: 0x000E8CC0 File Offset: 0x000E6EC0
		[ProtoMember(10, IsRequired = false, Name = "canjoincount", DataFormat = DataFormat.TwosComplement)]
		public uint canjoincount
		{
			get
			{
				return this._canjoincount ?? 0U;
			}
			set
			{
				this._canjoincount = new uint?(value);
			}
		}

		// Token: 0x17002694 RID: 9876
		// (get) Token: 0x060079C6 RID: 31174 RVA: 0x000E8CD0 File Offset: 0x000E6ED0
		// (set) Token: 0x060079C7 RID: 31175 RVA: 0x000E8CF0 File Offset: 0x000E6EF0
		[XmlIgnore]
		[Browsable(false)]
		public bool canjoincountSpecified
		{
			get
			{
				return this._canjoincount != null;
			}
			set
			{
				bool flag = value == (this._canjoincount == null);
				if (flag)
				{
					this._canjoincount = (value ? new uint?(this.canjoincount) : null);
				}
			}
		}

		// Token: 0x060079C8 RID: 31176 RVA: 0x000E8D34 File Offset: 0x000E6F34
		private bool ShouldSerializecanjoincount()
		{
			return this.canjoincountSpecified;
		}

		// Token: 0x060079C9 RID: 31177 RVA: 0x000E8D4C File Offset: 0x000E6F4C
		private void Resetcanjoincount()
		{
			this.canjoincountSpecified = false;
		}

		// Token: 0x17002695 RID: 9877
		// (get) Token: 0x060079CA RID: 31178 RVA: 0x000E8D58 File Offset: 0x000E6F58
		// (set) Token: 0x060079CB RID: 31179 RVA: 0x000E8D85 File Offset: 0x000E6F85
		[ProtoMember(11, IsRequired = false, Name = "creator", DataFormat = DataFormat.TwosComplement)]
		public ulong creator
		{
			get
			{
				return this._creator ?? 0UL;
			}
			set
			{
				this._creator = new ulong?(value);
			}
		}

		// Token: 0x17002696 RID: 9878
		// (get) Token: 0x060079CC RID: 31180 RVA: 0x000E8D94 File Offset: 0x000E6F94
		// (set) Token: 0x060079CD RID: 31181 RVA: 0x000E8DB4 File Offset: 0x000E6FB4
		[XmlIgnore]
		[Browsable(false)]
		public bool creatorSpecified
		{
			get
			{
				return this._creator != null;
			}
			set
			{
				bool flag = value == (this._creator == null);
				if (flag)
				{
					this._creator = (value ? new ulong?(this.creator) : null);
				}
			}
		}

		// Token: 0x060079CE RID: 31182 RVA: 0x000E8DF8 File Offset: 0x000E6FF8
		private bool ShouldSerializecreator()
		{
			return this.creatorSpecified;
		}

		// Token: 0x060079CF RID: 31183 RVA: 0x000E8E10 File Offset: 0x000E7010
		private void Resetcreator()
		{
			this.creatorSpecified = false;
		}

		// Token: 0x17002697 RID: 9879
		// (get) Token: 0x060079D0 RID: 31184 RVA: 0x000E8E1C File Offset: 0x000E701C
		// (set) Token: 0x060079D1 RID: 31185 RVA: 0x000E8E3D File Offset: 0x000E703D
		[ProtoMember(12, IsRequired = false, Name = "creatorname", DataFormat = DataFormat.Default)]
		public string creatorname
		{
			get
			{
				return this._creatorname ?? "";
			}
			set
			{
				this._creatorname = value;
			}
		}

		// Token: 0x17002698 RID: 9880
		// (get) Token: 0x060079D2 RID: 31186 RVA: 0x000E8E48 File Offset: 0x000E7048
		// (set) Token: 0x060079D3 RID: 31187 RVA: 0x000E8E64 File Offset: 0x000E7064
		[XmlIgnore]
		[Browsable(false)]
		public bool creatornameSpecified
		{
			get
			{
				return this._creatorname != null;
			}
			set
			{
				bool flag = value == (this._creatorname == null);
				if (flag)
				{
					this._creatorname = (value ? this.creatorname : null);
				}
			}
		}

		// Token: 0x060079D4 RID: 31188 RVA: 0x000E8E94 File Offset: 0x000E7094
		private bool ShouldSerializecreatorname()
		{
			return this.creatornameSpecified;
		}

		// Token: 0x060079D5 RID: 31189 RVA: 0x000E8EAC File Offset: 0x000E70AC
		private void Resetcreatorname()
		{
			this.creatornameSpecified = false;
		}

		// Token: 0x17002699 RID: 9881
		// (get) Token: 0x060079D6 RID: 31190 RVA: 0x000E8EB8 File Offset: 0x000E70B8
		// (set) Token: 0x060079D7 RID: 31191 RVA: 0x000E8EE4 File Offset: 0x000E70E4
		[ProtoMember(13, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public CustomBattleState state
		{
			get
			{
				return this._state ?? CustomBattleState.CustomBattle_Ready;
			}
			set
			{
				this._state = new CustomBattleState?(value);
			}
		}

		// Token: 0x1700269A RID: 9882
		// (get) Token: 0x060079D8 RID: 31192 RVA: 0x000E8EF4 File Offset: 0x000E70F4
		// (set) Token: 0x060079D9 RID: 31193 RVA: 0x000E8F14 File Offset: 0x000E7114
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new CustomBattleState?(this.state) : null);
				}
			}
		}

		// Token: 0x060079DA RID: 31194 RVA: 0x000E8F58 File Offset: 0x000E7158
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x060079DB RID: 31195 RVA: 0x000E8F70 File Offset: 0x000E7170
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x1700269B RID: 9883
		// (get) Token: 0x060079DC RID: 31196 RVA: 0x000E8F7C File Offset: 0x000E717C
		// (set) Token: 0x060079DD RID: 31197 RVA: 0x000E8FA8 File Offset: 0x000E71A8
		[ProtoMember(14, IsRequired = false, Name = "readytime", DataFormat = DataFormat.TwosComplement)]
		public uint readytime
		{
			get
			{
				return this._readytime ?? 0U;
			}
			set
			{
				this._readytime = new uint?(value);
			}
		}

		// Token: 0x1700269C RID: 9884
		// (get) Token: 0x060079DE RID: 31198 RVA: 0x000E8FB8 File Offset: 0x000E71B8
		// (set) Token: 0x060079DF RID: 31199 RVA: 0x000E8FD8 File Offset: 0x000E71D8
		[XmlIgnore]
		[Browsable(false)]
		public bool readytimeSpecified
		{
			get
			{
				return this._readytime != null;
			}
			set
			{
				bool flag = value == (this._readytime == null);
				if (flag)
				{
					this._readytime = (value ? new uint?(this.readytime) : null);
				}
			}
		}

		// Token: 0x060079E0 RID: 31200 RVA: 0x000E901C File Offset: 0x000E721C
		private bool ShouldSerializereadytime()
		{
			return this.readytimeSpecified;
		}

		// Token: 0x060079E1 RID: 31201 RVA: 0x000E9034 File Offset: 0x000E7234
		private void Resetreadytime()
		{
			this.readytimeSpecified = false;
		}

		// Token: 0x1700269D RID: 9885
		// (get) Token: 0x060079E2 RID: 31202 RVA: 0x000E9040 File Offset: 0x000E7240
		// (set) Token: 0x060079E3 RID: 31203 RVA: 0x000E906C File Offset: 0x000E726C
		[ProtoMember(15, IsRequired = false, Name = "issystem", DataFormat = DataFormat.Default)]
		public bool issystem
		{
			get
			{
				return this._issystem ?? false;
			}
			set
			{
				this._issystem = new bool?(value);
			}
		}

		// Token: 0x1700269E RID: 9886
		// (get) Token: 0x060079E4 RID: 31204 RVA: 0x000E907C File Offset: 0x000E727C
		// (set) Token: 0x060079E5 RID: 31205 RVA: 0x000E909C File Offset: 0x000E729C
		[XmlIgnore]
		[Browsable(false)]
		public bool issystemSpecified
		{
			get
			{
				return this._issystem != null;
			}
			set
			{
				bool flag = value == (this._issystem == null);
				if (flag)
				{
					this._issystem = (value ? new bool?(this.issystem) : null);
				}
			}
		}

		// Token: 0x060079E6 RID: 31206 RVA: 0x000E90E0 File Offset: 0x000E72E0
		private bool ShouldSerializeissystem()
		{
			return this.issystemSpecified;
		}

		// Token: 0x060079E7 RID: 31207 RVA: 0x000E90F8 File Offset: 0x000E72F8
		private void Resetissystem()
		{
			this.issystemSpecified = false;
		}

		// Token: 0x1700269F RID: 9887
		// (get) Token: 0x060079E8 RID: 31208 RVA: 0x000E9104 File Offset: 0x000E7304
		// (set) Token: 0x060079E9 RID: 31209 RVA: 0x000E9130 File Offset: 0x000E7330
		[ProtoMember(16, IsRequired = false, Name = "hasjoincount", DataFormat = DataFormat.TwosComplement)]
		public uint hasjoincount
		{
			get
			{
				return this._hasjoincount ?? 0U;
			}
			set
			{
				this._hasjoincount = new uint?(value);
			}
		}

		// Token: 0x170026A0 RID: 9888
		// (get) Token: 0x060079EA RID: 31210 RVA: 0x000E9140 File Offset: 0x000E7340
		// (set) Token: 0x060079EB RID: 31211 RVA: 0x000E9160 File Offset: 0x000E7360
		[XmlIgnore]
		[Browsable(false)]
		public bool hasjoincountSpecified
		{
			get
			{
				return this._hasjoincount != null;
			}
			set
			{
				bool flag = value == (this._hasjoincount == null);
				if (flag)
				{
					this._hasjoincount = (value ? new uint?(this.hasjoincount) : null);
				}
			}
		}

		// Token: 0x060079EC RID: 31212 RVA: 0x000E91A4 File Offset: 0x000E73A4
		private bool ShouldSerializehasjoincount()
		{
			return this.hasjoincountSpecified;
		}

		// Token: 0x060079ED RID: 31213 RVA: 0x000E91BC File Offset: 0x000E73BC
		private void Resethasjoincount()
		{
			this.hasjoincountSpecified = false;
		}

		// Token: 0x170026A1 RID: 9889
		// (get) Token: 0x060079EE RID: 31214 RVA: 0x000E91C8 File Offset: 0x000E73C8
		// (set) Token: 0x060079EF RID: 31215 RVA: 0x000E91E9 File Offset: 0x000E73E9
		[ProtoMember(17, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
		public string token
		{
			get
			{
				return this._token ?? "";
			}
			set
			{
				this._token = value;
			}
		}

		// Token: 0x170026A2 RID: 9890
		// (get) Token: 0x060079F0 RID: 31216 RVA: 0x000E91F4 File Offset: 0x000E73F4
		// (set) Token: 0x060079F1 RID: 31217 RVA: 0x000E9210 File Offset: 0x000E7410
		[XmlIgnore]
		[Browsable(false)]
		public bool tokenSpecified
		{
			get
			{
				return this._token != null;
			}
			set
			{
				bool flag = value == (this._token == null);
				if (flag)
				{
					this._token = (value ? this.token : null);
				}
			}
		}

		// Token: 0x060079F2 RID: 31218 RVA: 0x000E9240 File Offset: 0x000E7440
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x060079F3 RID: 31219 RVA: 0x000E9258 File Offset: 0x000E7458
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x170026A3 RID: 9891
		// (get) Token: 0x060079F4 RID: 31220 RVA: 0x000E9264 File Offset: 0x000E7464
		// (set) Token: 0x060079F5 RID: 31221 RVA: 0x000E9290 File Offset: 0x000E7490
		[ProtoMember(18, IsRequired = false, Name = "battletimeconf", DataFormat = DataFormat.TwosComplement)]
		public uint battletimeconf
		{
			get
			{
				return this._battletimeconf ?? 0U;
			}
			set
			{
				this._battletimeconf = new uint?(value);
			}
		}

		// Token: 0x170026A4 RID: 9892
		// (get) Token: 0x060079F6 RID: 31222 RVA: 0x000E92A0 File Offset: 0x000E74A0
		// (set) Token: 0x060079F7 RID: 31223 RVA: 0x000E92C0 File Offset: 0x000E74C0
		[XmlIgnore]
		[Browsable(false)]
		public bool battletimeconfSpecified
		{
			get
			{
				return this._battletimeconf != null;
			}
			set
			{
				bool flag = value == (this._battletimeconf == null);
				if (flag)
				{
					this._battletimeconf = (value ? new uint?(this.battletimeconf) : null);
				}
			}
		}

		// Token: 0x060079F8 RID: 31224 RVA: 0x000E9304 File Offset: 0x000E7504
		private bool ShouldSerializebattletimeconf()
		{
			return this.battletimeconfSpecified;
		}

		// Token: 0x060079F9 RID: 31225 RVA: 0x000E931C File Offset: 0x000E751C
		private void Resetbattletimeconf()
		{
			this.battletimeconfSpecified = false;
		}

		// Token: 0x170026A5 RID: 9893
		// (get) Token: 0x060079FA RID: 31226 RVA: 0x000E9328 File Offset: 0x000E7528
		// (set) Token: 0x060079FB RID: 31227 RVA: 0x000E9354 File Offset: 0x000E7554
		[ProtoMember(19, IsRequired = false, Name = "tagmask", DataFormat = DataFormat.TwosComplement)]
		public uint tagmask
		{
			get
			{
				return this._tagmask ?? 0U;
			}
			set
			{
				this._tagmask = new uint?(value);
			}
		}

		// Token: 0x170026A6 RID: 9894
		// (get) Token: 0x060079FC RID: 31228 RVA: 0x000E9364 File Offset: 0x000E7564
		// (set) Token: 0x060079FD RID: 31229 RVA: 0x000E9384 File Offset: 0x000E7584
		[XmlIgnore]
		[Browsable(false)]
		public bool tagmaskSpecified
		{
			get
			{
				return this._tagmask != null;
			}
			set
			{
				bool flag = value == (this._tagmask == null);
				if (flag)
				{
					this._tagmask = (value ? new uint?(this.tagmask) : null);
				}
			}
		}

		// Token: 0x060079FE RID: 31230 RVA: 0x000E93C8 File Offset: 0x000E75C8
		private bool ShouldSerializetagmask()
		{
			return this.tagmaskSpecified;
		}

		// Token: 0x060079FF RID: 31231 RVA: 0x000E93E0 File Offset: 0x000E75E0
		private void Resettagmask()
		{
			this.tagmaskSpecified = false;
		}

		// Token: 0x170026A7 RID: 9895
		// (get) Token: 0x06007A00 RID: 31232 RVA: 0x000E93EC File Offset: 0x000E75EC
		// (set) Token: 0x06007A01 RID: 31233 RVA: 0x000E9418 File Offset: 0x000E7618
		[ProtoMember(20, IsRequired = false, Name = "fighttype", DataFormat = DataFormat.TwosComplement)]
		public CustomBattleType fighttype
		{
			get
			{
				return this._fighttype ?? CustomBattleType.CustomBattle_PK_Normal;
			}
			set
			{
				this._fighttype = new CustomBattleType?(value);
			}
		}

		// Token: 0x170026A8 RID: 9896
		// (get) Token: 0x06007A02 RID: 31234 RVA: 0x000E9428 File Offset: 0x000E7628
		// (set) Token: 0x06007A03 RID: 31235 RVA: 0x000E9448 File Offset: 0x000E7648
		[XmlIgnore]
		[Browsable(false)]
		public bool fighttypeSpecified
		{
			get
			{
				return this._fighttype != null;
			}
			set
			{
				bool flag = value == (this._fighttype == null);
				if (flag)
				{
					this._fighttype = (value ? new CustomBattleType?(this.fighttype) : null);
				}
			}
		}

		// Token: 0x06007A04 RID: 31236 RVA: 0x000E948C File Offset: 0x000E768C
		private bool ShouldSerializefighttype()
		{
			return this.fighttypeSpecified;
		}

		// Token: 0x06007A05 RID: 31237 RVA: 0x000E94A4 File Offset: 0x000E76A4
		private void Resetfighttype()
		{
			this.fighttypeSpecified = false;
		}

		// Token: 0x06007A06 RID: 31238 RVA: 0x000E94B0 File Offset: 0x000E76B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CB8 RID: 7352
		private uint? _tagtype;

		// Token: 0x04001CB9 RID: 7353
		private uint? _configid;

		// Token: 0x04001CBA RID: 7354
		private uint? _scalemask;

		// Token: 0x04001CBB RID: 7355
		private string _name;

		// Token: 0x04001CBC RID: 7356
		private string _desc;

		// Token: 0x04001CBD RID: 7357
		private bool? _haspassword;

		// Token: 0x04001CBE RID: 7358
		private string _password;

		// Token: 0x04001CBF RID: 7359
		private bool? _isfair;

		// Token: 0x04001CC0 RID: 7360
		private uint? _battletime;

		// Token: 0x04001CC1 RID: 7361
		private uint? _canjoincount;

		// Token: 0x04001CC2 RID: 7362
		private ulong? _creator;

		// Token: 0x04001CC3 RID: 7363
		private string _creatorname;

		// Token: 0x04001CC4 RID: 7364
		private CustomBattleState? _state;

		// Token: 0x04001CC5 RID: 7365
		private uint? _readytime;

		// Token: 0x04001CC6 RID: 7366
		private bool? _issystem;

		// Token: 0x04001CC7 RID: 7367
		private uint? _hasjoincount;

		// Token: 0x04001CC8 RID: 7368
		private string _token;

		// Token: 0x04001CC9 RID: 7369
		private uint? _battletimeconf;

		// Token: 0x04001CCA RID: 7370
		private uint? _tagmask;

		// Token: 0x04001CCB RID: 7371
		private CustomBattleType? _fighttype;

		// Token: 0x04001CCC RID: 7372
		private IExtension extensionObject;
	}
}
