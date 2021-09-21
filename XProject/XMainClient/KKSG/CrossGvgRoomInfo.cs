using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000742 RID: 1858
	[ProtoContract(Name = "CrossGvgRoomInfo")]
	[Serializable]
	public class CrossGvgRoomInfo : IExtensible
	{
		// Token: 0x170028FB RID: 10491
		// (get) Token: 0x06008141 RID: 33089 RVA: 0x000F72F0 File Offset: 0x000F54F0
		// (set) Token: 0x06008142 RID: 33090 RVA: 0x000F731C File Offset: 0x000F551C
		[ProtoMember(1, IsRequired = false, Name = "roomid", DataFormat = DataFormat.TwosComplement)]
		public uint roomid
		{
			get
			{
				return this._roomid ?? 0U;
			}
			set
			{
				this._roomid = new uint?(value);
			}
		}

		// Token: 0x170028FC RID: 10492
		// (get) Token: 0x06008143 RID: 33091 RVA: 0x000F732C File Offset: 0x000F552C
		// (set) Token: 0x06008144 RID: 33092 RVA: 0x000F734C File Offset: 0x000F554C
		[XmlIgnore]
		[Browsable(false)]
		public bool roomidSpecified
		{
			get
			{
				return this._roomid != null;
			}
			set
			{
				bool flag = value == (this._roomid == null);
				if (flag)
				{
					this._roomid = (value ? new uint?(this.roomid) : null);
				}
			}
		}

		// Token: 0x06008145 RID: 33093 RVA: 0x000F7390 File Offset: 0x000F5590
		private bool ShouldSerializeroomid()
		{
			return this.roomidSpecified;
		}

		// Token: 0x06008146 RID: 33094 RVA: 0x000F73A8 File Offset: 0x000F55A8
		private void Resetroomid()
		{
			this.roomidSpecified = false;
		}

		// Token: 0x170028FD RID: 10493
		// (get) Token: 0x06008147 RID: 33095 RVA: 0x000F73B4 File Offset: 0x000F55B4
		// (set) Token: 0x06008148 RID: 33096 RVA: 0x000F73E1 File Offset: 0x000F55E1
		[ProtoMember(2, IsRequired = false, Name = "guild1", DataFormat = DataFormat.TwosComplement)]
		public ulong guild1
		{
			get
			{
				return this._guild1 ?? 0UL;
			}
			set
			{
				this._guild1 = new ulong?(value);
			}
		}

		// Token: 0x170028FE RID: 10494
		// (get) Token: 0x06008149 RID: 33097 RVA: 0x000F73F0 File Offset: 0x000F55F0
		// (set) Token: 0x0600814A RID: 33098 RVA: 0x000F7410 File Offset: 0x000F5610
		[XmlIgnore]
		[Browsable(false)]
		public bool guild1Specified
		{
			get
			{
				return this._guild1 != null;
			}
			set
			{
				bool flag = value == (this._guild1 == null);
				if (flag)
				{
					this._guild1 = (value ? new ulong?(this.guild1) : null);
				}
			}
		}

		// Token: 0x0600814B RID: 33099 RVA: 0x000F7454 File Offset: 0x000F5654
		private bool ShouldSerializeguild1()
		{
			return this.guild1Specified;
		}

		// Token: 0x0600814C RID: 33100 RVA: 0x000F746C File Offset: 0x000F566C
		private void Resetguild1()
		{
			this.guild1Specified = false;
		}

		// Token: 0x170028FF RID: 10495
		// (get) Token: 0x0600814D RID: 33101 RVA: 0x000F7478 File Offset: 0x000F5678
		// (set) Token: 0x0600814E RID: 33102 RVA: 0x000F74A5 File Offset: 0x000F56A5
		[ProtoMember(3, IsRequired = false, Name = "guild2", DataFormat = DataFormat.TwosComplement)]
		public ulong guild2
		{
			get
			{
				return this._guild2 ?? 0UL;
			}
			set
			{
				this._guild2 = new ulong?(value);
			}
		}

		// Token: 0x17002900 RID: 10496
		// (get) Token: 0x0600814F RID: 33103 RVA: 0x000F74B4 File Offset: 0x000F56B4
		// (set) Token: 0x06008150 RID: 33104 RVA: 0x000F74D4 File Offset: 0x000F56D4
		[XmlIgnore]
		[Browsable(false)]
		public bool guild2Specified
		{
			get
			{
				return this._guild2 != null;
			}
			set
			{
				bool flag = value == (this._guild2 == null);
				if (flag)
				{
					this._guild2 = (value ? new ulong?(this.guild2) : null);
				}
			}
		}

		// Token: 0x06008151 RID: 33105 RVA: 0x000F7518 File Offset: 0x000F5718
		private bool ShouldSerializeguild2()
		{
			return this.guild2Specified;
		}

		// Token: 0x06008152 RID: 33106 RVA: 0x000F7530 File Offset: 0x000F5730
		private void Resetguild2()
		{
			this.guild2Specified = false;
		}

		// Token: 0x17002901 RID: 10497
		// (get) Token: 0x06008153 RID: 33107 RVA: 0x000F753C File Offset: 0x000F573C
		// (set) Token: 0x06008154 RID: 33108 RVA: 0x000F7568 File Offset: 0x000F5768
		[ProtoMember(4, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public CrossGvgRoomState state
		{
			get
			{
				return this._state ?? CrossGvgRoomState.CGRS_Idle;
			}
			set
			{
				this._state = new CrossGvgRoomState?(value);
			}
		}

		// Token: 0x17002902 RID: 10498
		// (get) Token: 0x06008155 RID: 33109 RVA: 0x000F7578 File Offset: 0x000F5778
		// (set) Token: 0x06008156 RID: 33110 RVA: 0x000F7598 File Offset: 0x000F5798
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
					this._state = (value ? new CrossGvgRoomState?(this.state) : null);
				}
			}
		}

		// Token: 0x06008157 RID: 33111 RVA: 0x000F75DC File Offset: 0x000F57DC
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06008158 RID: 33112 RVA: 0x000F75F4 File Offset: 0x000F57F4
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17002903 RID: 10499
		// (get) Token: 0x06008159 RID: 33113 RVA: 0x000F7600 File Offset: 0x000F5800
		// (set) Token: 0x0600815A RID: 33114 RVA: 0x000F762D File Offset: 0x000F582D
		[ProtoMember(5, IsRequired = false, Name = "winguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong winguildid
		{
			get
			{
				return this._winguildid ?? 0UL;
			}
			set
			{
				this._winguildid = new ulong?(value);
			}
		}

		// Token: 0x17002904 RID: 10500
		// (get) Token: 0x0600815B RID: 33115 RVA: 0x000F763C File Offset: 0x000F583C
		// (set) Token: 0x0600815C RID: 33116 RVA: 0x000F765C File Offset: 0x000F585C
		[XmlIgnore]
		[Browsable(false)]
		public bool winguildidSpecified
		{
			get
			{
				return this._winguildid != null;
			}
			set
			{
				bool flag = value == (this._winguildid == null);
				if (flag)
				{
					this._winguildid = (value ? new ulong?(this.winguildid) : null);
				}
			}
		}

		// Token: 0x0600815D RID: 33117 RVA: 0x000F76A0 File Offset: 0x000F58A0
		private bool ShouldSerializewinguildid()
		{
			return this.winguildidSpecified;
		}

		// Token: 0x0600815E RID: 33118 RVA: 0x000F76B8 File Offset: 0x000F58B8
		private void Resetwinguildid()
		{
			this.winguildidSpecified = false;
		}

		// Token: 0x17002905 RID: 10501
		// (get) Token: 0x0600815F RID: 33119 RVA: 0x000F76C4 File Offset: 0x000F58C4
		// (set) Token: 0x06008160 RID: 33120 RVA: 0x000F76F0 File Offset: 0x000F58F0
		[ProtoMember(6, IsRequired = false, Name = "liveid", DataFormat = DataFormat.TwosComplement)]
		public uint liveid
		{
			get
			{
				return this._liveid ?? 0U;
			}
			set
			{
				this._liveid = new uint?(value);
			}
		}

		// Token: 0x17002906 RID: 10502
		// (get) Token: 0x06008161 RID: 33121 RVA: 0x000F7700 File Offset: 0x000F5900
		// (set) Token: 0x06008162 RID: 33122 RVA: 0x000F7720 File Offset: 0x000F5920
		[XmlIgnore]
		[Browsable(false)]
		public bool liveidSpecified
		{
			get
			{
				return this._liveid != null;
			}
			set
			{
				bool flag = value == (this._liveid == null);
				if (flag)
				{
					this._liveid = (value ? new uint?(this.liveid) : null);
				}
			}
		}

		// Token: 0x06008163 RID: 33123 RVA: 0x000F7764 File Offset: 0x000F5964
		private bool ShouldSerializeliveid()
		{
			return this.liveidSpecified;
		}

		// Token: 0x06008164 RID: 33124 RVA: 0x000F777C File Offset: 0x000F597C
		private void Resetliveid()
		{
			this.liveidSpecified = false;
		}

		// Token: 0x17002907 RID: 10503
		// (get) Token: 0x06008165 RID: 33125 RVA: 0x000F7788 File Offset: 0x000F5988
		// (set) Token: 0x06008166 RID: 33126 RVA: 0x000F77B4 File Offset: 0x000F59B4
		[ProtoMember(7, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		// Token: 0x17002908 RID: 10504
		// (get) Token: 0x06008167 RID: 33127 RVA: 0x000F77C4 File Offset: 0x000F59C4
		// (set) Token: 0x06008168 RID: 33128 RVA: 0x000F77E4 File Offset: 0x000F59E4
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		// Token: 0x06008169 RID: 33129 RVA: 0x000F7828 File Offset: 0x000F5A28
		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		// Token: 0x0600816A RID: 33130 RVA: 0x000F7840 File Offset: 0x000F5A40
		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		// Token: 0x17002909 RID: 10505
		// (get) Token: 0x0600816B RID: 33131 RVA: 0x000F784C File Offset: 0x000F5A4C
		// (set) Token: 0x0600816C RID: 33132 RVA: 0x000F7878 File Offset: 0x000F5A78
		[ProtoMember(8, IsRequired = false, Name = "gsline", DataFormat = DataFormat.TwosComplement)]
		public uint gsline
		{
			get
			{
				return this._gsline ?? 0U;
			}
			set
			{
				this._gsline = new uint?(value);
			}
		}

		// Token: 0x1700290A RID: 10506
		// (get) Token: 0x0600816D RID: 33133 RVA: 0x000F7888 File Offset: 0x000F5A88
		// (set) Token: 0x0600816E RID: 33134 RVA: 0x000F78A8 File Offset: 0x000F5AA8
		[XmlIgnore]
		[Browsable(false)]
		public bool gslineSpecified
		{
			get
			{
				return this._gsline != null;
			}
			set
			{
				bool flag = value == (this._gsline == null);
				if (flag)
				{
					this._gsline = (value ? new uint?(this.gsline) : null);
				}
			}
		}

		// Token: 0x0600816F RID: 33135 RVA: 0x000F78EC File Offset: 0x000F5AEC
		private bool ShouldSerializegsline()
		{
			return this.gslineSpecified;
		}

		// Token: 0x06008170 RID: 33136 RVA: 0x000F7904 File Offset: 0x000F5B04
		private void Resetgsline()
		{
			this.gslineSpecified = false;
		}

		// Token: 0x1700290B RID: 10507
		// (get) Token: 0x06008171 RID: 33137 RVA: 0x000F7910 File Offset: 0x000F5B10
		// (set) Token: 0x06008172 RID: 33138 RVA: 0x000F793C File Offset: 0x000F5B3C
		[ProtoMember(9, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700290C RID: 10508
		// (get) Token: 0x06008173 RID: 33139 RVA: 0x000F794C File Offset: 0x000F5B4C
		// (set) Token: 0x06008174 RID: 33140 RVA: 0x000F796C File Offset: 0x000F5B6C
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

		// Token: 0x06008175 RID: 33141 RVA: 0x000F79B0 File Offset: 0x000F5BB0
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06008176 RID: 33142 RVA: 0x000F79C8 File Offset: 0x000F5BC8
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x1700290D RID: 10509
		// (get) Token: 0x06008177 RID: 33143 RVA: 0x000F79D4 File Offset: 0x000F5BD4
		// (set) Token: 0x06008178 RID: 33144 RVA: 0x000F7A00 File Offset: 0x000F5C00
		[ProtoMember(10, IsRequired = false, Name = "win_score", DataFormat = DataFormat.TwosComplement)]
		public int win_score
		{
			get
			{
				return this._win_score ?? 0;
			}
			set
			{
				this._win_score = new int?(value);
			}
		}

		// Token: 0x1700290E RID: 10510
		// (get) Token: 0x06008179 RID: 33145 RVA: 0x000F7A10 File Offset: 0x000F5C10
		// (set) Token: 0x0600817A RID: 33146 RVA: 0x000F7A30 File Offset: 0x000F5C30
		[XmlIgnore]
		[Browsable(false)]
		public bool win_scoreSpecified
		{
			get
			{
				return this._win_score != null;
			}
			set
			{
				bool flag = value == (this._win_score == null);
				if (flag)
				{
					this._win_score = (value ? new int?(this.win_score) : null);
				}
			}
		}

		// Token: 0x0600817B RID: 33147 RVA: 0x000F7A74 File Offset: 0x000F5C74
		private bool ShouldSerializewin_score()
		{
			return this.win_scoreSpecified;
		}

		// Token: 0x0600817C RID: 33148 RVA: 0x000F7A8C File Offset: 0x000F5C8C
		private void Resetwin_score()
		{
			this.win_scoreSpecified = false;
		}

		// Token: 0x1700290F RID: 10511
		// (get) Token: 0x0600817D RID: 33149 RVA: 0x000F7A98 File Offset: 0x000F5C98
		// (set) Token: 0x0600817E RID: 33150 RVA: 0x000F7AC4 File Offset: 0x000F5CC4
		[ProtoMember(11, IsRequired = false, Name = "lose_score", DataFormat = DataFormat.TwosComplement)]
		public int lose_score
		{
			get
			{
				return this._lose_score ?? 0;
			}
			set
			{
				this._lose_score = new int?(value);
			}
		}

		// Token: 0x17002910 RID: 10512
		// (get) Token: 0x0600817F RID: 33151 RVA: 0x000F7AD4 File Offset: 0x000F5CD4
		// (set) Token: 0x06008180 RID: 33152 RVA: 0x000F7AF4 File Offset: 0x000F5CF4
		[XmlIgnore]
		[Browsable(false)]
		public bool lose_scoreSpecified
		{
			get
			{
				return this._lose_score != null;
			}
			set
			{
				bool flag = value == (this._lose_score == null);
				if (flag)
				{
					this._lose_score = (value ? new int?(this.lose_score) : null);
				}
			}
		}

		// Token: 0x06008181 RID: 33153 RVA: 0x000F7B38 File Offset: 0x000F5D38
		private bool ShouldSerializelose_score()
		{
			return this.lose_scoreSpecified;
		}

		// Token: 0x06008182 RID: 33154 RVA: 0x000F7B50 File Offset: 0x000F5D50
		private void Resetlose_score()
		{
			this.lose_scoreSpecified = false;
		}

		// Token: 0x17002911 RID: 10513
		// (get) Token: 0x06008183 RID: 33155 RVA: 0x000F7B5C File Offset: 0x000F5D5C
		// (set) Token: 0x06008184 RID: 33156 RVA: 0x000F7B88 File Offset: 0x000F5D88
		[ProtoMember(12, IsRequired = false, Name = "in_ready", DataFormat = DataFormat.Default)]
		public bool in_ready
		{
			get
			{
				return this._in_ready ?? false;
			}
			set
			{
				this._in_ready = new bool?(value);
			}
		}

		// Token: 0x17002912 RID: 10514
		// (get) Token: 0x06008185 RID: 33157 RVA: 0x000F7B98 File Offset: 0x000F5D98
		// (set) Token: 0x06008186 RID: 33158 RVA: 0x000F7BB8 File Offset: 0x000F5DB8
		[XmlIgnore]
		[Browsable(false)]
		public bool in_readySpecified
		{
			get
			{
				return this._in_ready != null;
			}
			set
			{
				bool flag = value == (this._in_ready == null);
				if (flag)
				{
					this._in_ready = (value ? new bool?(this.in_ready) : null);
				}
			}
		}

		// Token: 0x06008187 RID: 33159 RVA: 0x000F7BFC File Offset: 0x000F5DFC
		private bool ShouldSerializein_ready()
		{
			return this.in_readySpecified;
		}

		// Token: 0x06008188 RID: 33160 RVA: 0x000F7C14 File Offset: 0x000F5E14
		private void Resetin_ready()
		{
			this.in_readySpecified = false;
		}

		// Token: 0x06008189 RID: 33161 RVA: 0x000F7C20 File Offset: 0x000F5E20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E42 RID: 7746
		private uint? _roomid;

		// Token: 0x04001E43 RID: 7747
		private ulong? _guild1;

		// Token: 0x04001E44 RID: 7748
		private ulong? _guild2;

		// Token: 0x04001E45 RID: 7749
		private CrossGvgRoomState? _state;

		// Token: 0x04001E46 RID: 7750
		private ulong? _winguildid;

		// Token: 0x04001E47 RID: 7751
		private uint? _liveid;

		// Token: 0x04001E48 RID: 7752
		private uint? _sceneid;

		// Token: 0x04001E49 RID: 7753
		private uint? _gsline;

		// Token: 0x04001E4A RID: 7754
		private uint? _time;

		// Token: 0x04001E4B RID: 7755
		private int? _win_score;

		// Token: 0x04001E4C RID: 7756
		private int? _lose_score;

		// Token: 0x04001E4D RID: 7757
		private bool? _in_ready;

		// Token: 0x04001E4E RID: 7758
		private IExtension extensionObject;
	}
}
