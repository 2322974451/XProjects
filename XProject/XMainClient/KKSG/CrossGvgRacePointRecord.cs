using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000741 RID: 1857
	[ProtoContract(Name = "CrossGvgRacePointRecord")]
	[Serializable]
	public class CrossGvgRacePointRecord : IExtensible
	{
		// Token: 0x170028F0 RID: 10480
		// (get) Token: 0x0600811F RID: 33055 RVA: 0x000F6ED8 File Offset: 0x000F50D8
		// (set) Token: 0x06008120 RID: 33056 RVA: 0x000F6F04 File Offset: 0x000F5104
		[ProtoMember(1, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170028F1 RID: 10481
		// (get) Token: 0x06008121 RID: 33057 RVA: 0x000F6F14 File Offset: 0x000F5114
		// (set) Token: 0x06008122 RID: 33058 RVA: 0x000F6F34 File Offset: 0x000F5134
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

		// Token: 0x06008123 RID: 33059 RVA: 0x000F6F78 File Offset: 0x000F5178
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06008124 RID: 33060 RVA: 0x000F6F90 File Offset: 0x000F5190
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170028F2 RID: 10482
		// (get) Token: 0x06008125 RID: 33061 RVA: 0x000F6F9C File Offset: 0x000F519C
		// (set) Token: 0x06008126 RID: 33062 RVA: 0x000F6FB4 File Offset: 0x000F51B4
		[ProtoMember(2, IsRequired = false, Name = "opponent", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CrossGvgGuildInfo opponent
		{
			get
			{
				return this._opponent;
			}
			set
			{
				this._opponent = value;
			}
		}

		// Token: 0x170028F3 RID: 10483
		// (get) Token: 0x06008127 RID: 33063 RVA: 0x000F6FC0 File Offset: 0x000F51C0
		// (set) Token: 0x06008128 RID: 33064 RVA: 0x000F6FEC File Offset: 0x000F51EC
		[ProtoMember(3, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170028F4 RID: 10484
		// (get) Token: 0x06008129 RID: 33065 RVA: 0x000F6FFC File Offset: 0x000F51FC
		// (set) Token: 0x0600812A RID: 33066 RVA: 0x000F701C File Offset: 0x000F521C
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

		// Token: 0x0600812B RID: 33067 RVA: 0x000F7060 File Offset: 0x000F5260
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x0600812C RID: 33068 RVA: 0x000F7078 File Offset: 0x000F5278
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x170028F5 RID: 10485
		// (get) Token: 0x0600812D RID: 33069 RVA: 0x000F7084 File Offset: 0x000F5284
		// (set) Token: 0x0600812E RID: 33070 RVA: 0x000F70B0 File Offset: 0x000F52B0
		[ProtoMember(4, IsRequired = false, Name = "iswin", DataFormat = DataFormat.Default)]
		public bool iswin
		{
			get
			{
				return this._iswin ?? false;
			}
			set
			{
				this._iswin = new bool?(value);
			}
		}

		// Token: 0x170028F6 RID: 10486
		// (get) Token: 0x0600812F RID: 33071 RVA: 0x000F70C0 File Offset: 0x000F52C0
		// (set) Token: 0x06008130 RID: 33072 RVA: 0x000F70E0 File Offset: 0x000F52E0
		[XmlIgnore]
		[Browsable(false)]
		public bool iswinSpecified
		{
			get
			{
				return this._iswin != null;
			}
			set
			{
				bool flag = value == (this._iswin == null);
				if (flag)
				{
					this._iswin = (value ? new bool?(this.iswin) : null);
				}
			}
		}

		// Token: 0x06008131 RID: 33073 RVA: 0x000F7124 File Offset: 0x000F5324
		private bool ShouldSerializeiswin()
		{
			return this.iswinSpecified;
		}

		// Token: 0x06008132 RID: 33074 RVA: 0x000F713C File Offset: 0x000F533C
		private void Resetiswin()
		{
			this.iswinSpecified = false;
		}

		// Token: 0x170028F7 RID: 10487
		// (get) Token: 0x06008133 RID: 33075 RVA: 0x000F7148 File Offset: 0x000F5348
		// (set) Token: 0x06008134 RID: 33076 RVA: 0x000F7174 File Offset: 0x000F5374
		[ProtoMember(5, IsRequired = false, Name = "addscore", DataFormat = DataFormat.TwosComplement)]
		public uint addscore
		{
			get
			{
				return this._addscore ?? 0U;
			}
			set
			{
				this._addscore = new uint?(value);
			}
		}

		// Token: 0x170028F8 RID: 10488
		// (get) Token: 0x06008135 RID: 33077 RVA: 0x000F7184 File Offset: 0x000F5384
		// (set) Token: 0x06008136 RID: 33078 RVA: 0x000F71A4 File Offset: 0x000F53A4
		[XmlIgnore]
		[Browsable(false)]
		public bool addscoreSpecified
		{
			get
			{
				return this._addscore != null;
			}
			set
			{
				bool flag = value == (this._addscore == null);
				if (flag)
				{
					this._addscore = (value ? new uint?(this.addscore) : null);
				}
			}
		}

		// Token: 0x06008137 RID: 33079 RVA: 0x000F71E8 File Offset: 0x000F53E8
		private bool ShouldSerializeaddscore()
		{
			return this.addscoreSpecified;
		}

		// Token: 0x06008138 RID: 33080 RVA: 0x000F7200 File Offset: 0x000F5400
		private void Resetaddscore()
		{
			this.addscoreSpecified = false;
		}

		// Token: 0x170028F9 RID: 10489
		// (get) Token: 0x06008139 RID: 33081 RVA: 0x000F720C File Offset: 0x000F540C
		// (set) Token: 0x0600813A RID: 33082 RVA: 0x000F7238 File Offset: 0x000F5438
		[ProtoMember(6, IsRequired = false, Name = "roomid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170028FA RID: 10490
		// (get) Token: 0x0600813B RID: 33083 RVA: 0x000F7248 File Offset: 0x000F5448
		// (set) Token: 0x0600813C RID: 33084 RVA: 0x000F7268 File Offset: 0x000F5468
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

		// Token: 0x0600813D RID: 33085 RVA: 0x000F72AC File Offset: 0x000F54AC
		private bool ShouldSerializeroomid()
		{
			return this.roomidSpecified;
		}

		// Token: 0x0600813E RID: 33086 RVA: 0x000F72C4 File Offset: 0x000F54C4
		private void Resetroomid()
		{
			this.roomidSpecified = false;
		}

		// Token: 0x0600813F RID: 33087 RVA: 0x000F72D0 File Offset: 0x000F54D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E3B RID: 7739
		private uint? _time;

		// Token: 0x04001E3C RID: 7740
		private CrossGvgGuildInfo _opponent = null;

		// Token: 0x04001E3D RID: 7741
		private CrossGvgRoomState? _state;

		// Token: 0x04001E3E RID: 7742
		private bool? _iswin;

		// Token: 0x04001E3F RID: 7743
		private uint? _addscore;

		// Token: 0x04001E40 RID: 7744
		private uint? _roomid;

		// Token: 0x04001E41 RID: 7745
		private IExtension extensionObject;
	}
}
