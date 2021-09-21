using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000094 RID: 148
	[ProtoContract(Name = "GuildMemberInfo")]
	[Serializable]
	public class GuildMemberInfo : IExtensible
	{
		// Token: 0x1700031E RID: 798
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x00014A80 File Offset: 0x00012C80
		// (set) Token: 0x0600097D RID: 2429 RVA: 0x00014AAD File Offset: 0x00012CAD
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

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x00014ABC File Offset: 0x00012CBC
		// (set) Token: 0x0600097F RID: 2431 RVA: 0x00014ADC File Offset: 0x00012CDC
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

		// Token: 0x06000980 RID: 2432 RVA: 0x00014B20 File Offset: 0x00012D20
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x00014B38 File Offset: 0x00012D38
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x00014B44 File Offset: 0x00012D44
		// (set) Token: 0x06000983 RID: 2435 RVA: 0x00014B70 File Offset: 0x00012D70
		[ProtoMember(2, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public int position
		{
			get
			{
				return this._position ?? 0;
			}
			set
			{
				this._position = new int?(value);
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x00014B80 File Offset: 0x00012D80
		// (set) Token: 0x06000985 RID: 2437 RVA: 0x00014BA0 File Offset: 0x00012DA0
		[XmlIgnore]
		[Browsable(false)]
		public bool positionSpecified
		{
			get
			{
				return this._position != null;
			}
			set
			{
				bool flag = value == (this._position == null);
				if (flag)
				{
					this._position = (value ? new int?(this.position) : null);
				}
			}
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x00014BE4 File Offset: 0x00012DE4
		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x00014BFC File Offset: 0x00012DFC
		private void Resetposition()
		{
			this.positionSpecified = false;
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x00014C08 File Offset: 0x00012E08
		// (set) Token: 0x06000989 RID: 2441 RVA: 0x00014C34 File Offset: 0x00012E34
		[ProtoMember(3, IsRequired = false, Name = "contribute", DataFormat = DataFormat.TwosComplement)]
		public int contribute
		{
			get
			{
				return this._contribute ?? 0;
			}
			set
			{
				this._contribute = new int?(value);
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x00014C44 File Offset: 0x00012E44
		// (set) Token: 0x0600098B RID: 2443 RVA: 0x00014C64 File Offset: 0x00012E64
		[XmlIgnore]
		[Browsable(false)]
		public bool contributeSpecified
		{
			get
			{
				return this._contribute != null;
			}
			set
			{
				bool flag = value == (this._contribute == null);
				if (flag)
				{
					this._contribute = (value ? new int?(this.contribute) : null);
				}
			}
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x00014CA8 File Offset: 0x00012EA8
		private bool ShouldSerializecontribute()
		{
			return this.contributeSpecified;
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00014CC0 File Offset: 0x00012EC0
		private void Resetcontribute()
		{
			this.contributeSpecified = false;
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x0600098E RID: 2446 RVA: 0x00014CCC File Offset: 0x00012ECC
		// (set) Token: 0x0600098F RID: 2447 RVA: 0x00014CF8 File Offset: 0x00012EF8
		[ProtoMember(4, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public uint updateTime
		{
			get
			{
				return this._updateTime ?? 0U;
			}
			set
			{
				this._updateTime = new uint?(value);
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000990 RID: 2448 RVA: 0x00014D08 File Offset: 0x00012F08
		// (set) Token: 0x06000991 RID: 2449 RVA: 0x00014D28 File Offset: 0x00012F28
		[XmlIgnore]
		[Browsable(false)]
		public bool updateTimeSpecified
		{
			get
			{
				return this._updateTime != null;
			}
			set
			{
				bool flag = value == (this._updateTime == null);
				if (flag)
				{
					this._updateTime = (value ? new uint?(this.updateTime) : null);
				}
			}
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x00014D6C File Offset: 0x00012F6C
		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x00014D84 File Offset: 0x00012F84
		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x00014D90 File Offset: 0x00012F90
		// (set) Token: 0x06000995 RID: 2453 RVA: 0x00014DBC File Offset: 0x00012FBC
		[ProtoMember(5, IsRequired = false, Name = "groupFightContribute", DataFormat = DataFormat.TwosComplement)]
		public uint groupFightContribute
		{
			get
			{
				return this._groupFightContribute ?? 0U;
			}
			set
			{
				this._groupFightContribute = new uint?(value);
			}
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000996 RID: 2454 RVA: 0x00014DCC File Offset: 0x00012FCC
		// (set) Token: 0x06000997 RID: 2455 RVA: 0x00014DEC File Offset: 0x00012FEC
		[XmlIgnore]
		[Browsable(false)]
		public bool groupFightContributeSpecified
		{
			get
			{
				return this._groupFightContribute != null;
			}
			set
			{
				bool flag = value == (this._groupFightContribute == null);
				if (flag)
				{
					this._groupFightContribute = (value ? new uint?(this.groupFightContribute) : null);
				}
			}
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x00014E30 File Offset: 0x00013030
		private bool ShouldSerializegroupFightContribute()
		{
			return this.groupFightContributeSpecified;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x00014E48 File Offset: 0x00013048
		private void ResetgroupFightContribute()
		{
			this.groupFightContributeSpecified = false;
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x0600099A RID: 2458 RVA: 0x00014E54 File Offset: 0x00013054
		// (set) Token: 0x0600099B RID: 2459 RVA: 0x00014E80 File Offset: 0x00013080
		[ProtoMember(6, IsRequired = false, Name = "joinTime", DataFormat = DataFormat.TwosComplement)]
		public uint joinTime
		{
			get
			{
				return this._joinTime ?? 0U;
			}
			set
			{
				this._joinTime = new uint?(value);
			}
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x0600099C RID: 2460 RVA: 0x00014E90 File Offset: 0x00013090
		// (set) Token: 0x0600099D RID: 2461 RVA: 0x00014EB0 File Offset: 0x000130B0
		[XmlIgnore]
		[Browsable(false)]
		public bool joinTimeSpecified
		{
			get
			{
				return this._joinTime != null;
			}
			set
			{
				bool flag = value == (this._joinTime == null);
				if (flag)
				{
					this._joinTime = (value ? new uint?(this.joinTime) : null);
				}
			}
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x00014EF4 File Offset: 0x000130F4
		private bool ShouldSerializejoinTime()
		{
			return this.joinTimeSpecified;
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x00014F0C File Offset: 0x0001310C
		private void ResetjoinTime()
		{
			this.joinTimeSpecified = false;
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x060009A0 RID: 2464 RVA: 0x00014F18 File Offset: 0x00013118
		// (set) Token: 0x060009A1 RID: 2465 RVA: 0x00014F44 File Offset: 0x00013144
		[ProtoMember(7, IsRequired = false, Name = "bind_status", DataFormat = DataFormat.TwosComplement)]
		public GuildBindStatus bind_status
		{
			get
			{
				return this._bind_status ?? GuildBindStatus.GBS_NotBind;
			}
			set
			{
				this._bind_status = new GuildBindStatus?(value);
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x060009A2 RID: 2466 RVA: 0x00014F54 File Offset: 0x00013154
		// (set) Token: 0x060009A3 RID: 2467 RVA: 0x00014F74 File Offset: 0x00013174
		[XmlIgnore]
		[Browsable(false)]
		public bool bind_statusSpecified
		{
			get
			{
				return this._bind_status != null;
			}
			set
			{
				bool flag = value == (this._bind_status == null);
				if (flag)
				{
					this._bind_status = (value ? new GuildBindStatus?(this.bind_status) : null);
				}
			}
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x00014FB8 File Offset: 0x000131B8
		private bool ShouldSerializebind_status()
		{
			return this.bind_statusSpecified;
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x00014FD0 File Offset: 0x000131D0
		private void Resetbind_status()
		{
			this.bind_statusSpecified = false;
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x060009A6 RID: 2470 RVA: 0x00014FDC File Offset: 0x000131DC
		// (set) Token: 0x060009A7 RID: 2471 RVA: 0x00015008 File Offset: 0x00013208
		[ProtoMember(8, IsRequired = false, Name = "update_bind_time", DataFormat = DataFormat.TwosComplement)]
		public uint update_bind_time
		{
			get
			{
				return this._update_bind_time ?? 0U;
			}
			set
			{
				this._update_bind_time = new uint?(value);
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x060009A8 RID: 2472 RVA: 0x00015018 File Offset: 0x00013218
		// (set) Token: 0x060009A9 RID: 2473 RVA: 0x00015038 File Offset: 0x00013238
		[XmlIgnore]
		[Browsable(false)]
		public bool update_bind_timeSpecified
		{
			get
			{
				return this._update_bind_time != null;
			}
			set
			{
				bool flag = value == (this._update_bind_time == null);
				if (flag)
				{
					this._update_bind_time = (value ? new uint?(this.update_bind_time) : null);
				}
			}
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0001507C File Offset: 0x0001327C
		private bool ShouldSerializeupdate_bind_time()
		{
			return this.update_bind_timeSpecified;
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x00015094 File Offset: 0x00013294
		private void Resetupdate_bind_time()
		{
			this.update_bind_timeSpecified = false;
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x060009AC RID: 2476 RVA: 0x000150A0 File Offset: 0x000132A0
		// (set) Token: 0x060009AD RID: 2477 RVA: 0x000150CC File Offset: 0x000132CC
		[ProtoMember(9, IsRequired = false, Name = "weeklyschoolpoint", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x060009AE RID: 2478 RVA: 0x000150DC File Offset: 0x000132DC
		// (set) Token: 0x060009AF RID: 2479 RVA: 0x000150FC File Offset: 0x000132FC
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

		// Token: 0x060009B0 RID: 2480 RVA: 0x00015140 File Offset: 0x00013340
		private bool ShouldSerializeweeklyschoolpoint()
		{
			return this.weeklyschoolpointSpecified;
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x00015158 File Offset: 0x00013358
		private void Resetweeklyschoolpoint()
		{
			this.weeklyschoolpointSpecified = false;
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x00015164 File Offset: 0x00013364
		// (set) Token: 0x060009B3 RID: 2483 RVA: 0x00015190 File Offset: 0x00013390
		[ProtoMember(10, IsRequired = false, Name = "weeklyschooltime", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyschooltime
		{
			get
			{
				return this._weeklyschooltime ?? 0U;
			}
			set
			{
				this._weeklyschooltime = new uint?(value);
			}
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x060009B4 RID: 2484 RVA: 0x000151A0 File Offset: 0x000133A0
		// (set) Token: 0x060009B5 RID: 2485 RVA: 0x000151C0 File Offset: 0x000133C0
		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyschooltimeSpecified
		{
			get
			{
				return this._weeklyschooltime != null;
			}
			set
			{
				bool flag = value == (this._weeklyschooltime == null);
				if (flag)
				{
					this._weeklyschooltime = (value ? new uint?(this.weeklyschooltime) : null);
				}
			}
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x00015204 File Offset: 0x00013404
		private bool ShouldSerializeweeklyschooltime()
		{
			return this.weeklyschooltimeSpecified;
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x0001521C File Offset: 0x0001341C
		private void Resetweeklyschooltime()
		{
			this.weeklyschooltimeSpecified = false;
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x060009B8 RID: 2488 RVA: 0x00015228 File Offset: 0x00013428
		// (set) Token: 0x060009B9 RID: 2489 RVA: 0x00015254 File Offset: 0x00013454
		[ProtoMember(11, IsRequired = false, Name = "weeklyhallpoint", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x060009BA RID: 2490 RVA: 0x00015264 File Offset: 0x00013464
		// (set) Token: 0x060009BB RID: 2491 RVA: 0x00015284 File Offset: 0x00013484
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

		// Token: 0x060009BC RID: 2492 RVA: 0x000152C8 File Offset: 0x000134C8
		private bool ShouldSerializeweeklyhallpoint()
		{
			return this.weeklyhallpointSpecified;
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x000152E0 File Offset: 0x000134E0
		private void Resetweeklyhallpoint()
		{
			this.weeklyhallpointSpecified = false;
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x060009BE RID: 2494 RVA: 0x000152EC File Offset: 0x000134EC
		// (set) Token: 0x060009BF RID: 2495 RVA: 0x00015318 File Offset: 0x00013518
		[ProtoMember(12, IsRequired = false, Name = "weeklyhalltime", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyhalltime
		{
			get
			{
				return this._weeklyhalltime ?? 0U;
			}
			set
			{
				this._weeklyhalltime = new uint?(value);
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x00015328 File Offset: 0x00013528
		// (set) Token: 0x060009C1 RID: 2497 RVA: 0x00015348 File Offset: 0x00013548
		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyhalltimeSpecified
		{
			get
			{
				return this._weeklyhalltime != null;
			}
			set
			{
				bool flag = value == (this._weeklyhalltime == null);
				if (flag)
				{
					this._weeklyhalltime = (value ? new uint?(this.weeklyhalltime) : null);
				}
			}
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x0001538C File Offset: 0x0001358C
		private bool ShouldSerializeweeklyhalltime()
		{
			return this.weeklyhalltimeSpecified;
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x000153A4 File Offset: 0x000135A4
		private void Resetweeklyhalltime()
		{
			this.weeklyhalltimeSpecified = false;
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x060009C4 RID: 2500 RVA: 0x000153B0 File Offset: 0x000135B0
		[ProtoMember(13, Name = "itemlist", DataFormat = DataFormat.Default)]
		public List<GuildZiCaiItemData> itemlist
		{
			get
			{
				return this._itemlist;
			}
		}

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x060009C5 RID: 2501 RVA: 0x000153C8 File Offset: 0x000135C8
		// (set) Token: 0x060009C6 RID: 2502 RVA: 0x000153F4 File Offset: 0x000135F4
		[ProtoMember(14, IsRequired = false, Name = "weeklyhuntcount", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyhuntcount
		{
			get
			{
				return this._weeklyhuntcount ?? 0U;
			}
			set
			{
				this._weeklyhuntcount = new uint?(value);
			}
		}

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x060009C7 RID: 2503 RVA: 0x00015404 File Offset: 0x00013604
		// (set) Token: 0x060009C8 RID: 2504 RVA: 0x00015424 File Offset: 0x00013624
		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyhuntcountSpecified
		{
			get
			{
				return this._weeklyhuntcount != null;
			}
			set
			{
				bool flag = value == (this._weeklyhuntcount == null);
				if (flag)
				{
					this._weeklyhuntcount = (value ? new uint?(this.weeklyhuntcount) : null);
				}
			}
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x00015468 File Offset: 0x00013668
		private bool ShouldSerializeweeklyhuntcount()
		{
			return this.weeklyhuntcountSpecified;
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x00015480 File Offset: 0x00013680
		private void Resetweeklyhuntcount()
		{
			this.weeklyhuntcountSpecified = false;
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x060009CB RID: 2507 RVA: 0x0001548C File Offset: 0x0001368C
		// (set) Token: 0x060009CC RID: 2508 RVA: 0x000154B8 File Offset: 0x000136B8
		[ProtoMember(15, IsRequired = false, Name = "weeklyhunttime", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyhunttime
		{
			get
			{
				return this._weeklyhunttime ?? 0U;
			}
			set
			{
				this._weeklyhunttime = new uint?(value);
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x060009CD RID: 2509 RVA: 0x000154C8 File Offset: 0x000136C8
		// (set) Token: 0x060009CE RID: 2510 RVA: 0x000154E8 File Offset: 0x000136E8
		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyhunttimeSpecified
		{
			get
			{
				return this._weeklyhunttime != null;
			}
			set
			{
				bool flag = value == (this._weeklyhunttime == null);
				if (flag)
				{
					this._weeklyhunttime = (value ? new uint?(this.weeklyhunttime) : null);
				}
			}
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0001552C File Offset: 0x0001372C
		private bool ShouldSerializeweeklyhunttime()
		{
			return this.weeklyhunttimeSpecified;
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x00015544 File Offset: 0x00013744
		private void Resetweeklyhunttime()
		{
			this.weeklyhunttimeSpecified = false;
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00015550 File Offset: 0x00013750
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000277 RID: 631
		private ulong? _roleid;

		// Token: 0x04000278 RID: 632
		private int? _position;

		// Token: 0x04000279 RID: 633
		private int? _contribute;

		// Token: 0x0400027A RID: 634
		private uint? _updateTime;

		// Token: 0x0400027B RID: 635
		private uint? _groupFightContribute;

		// Token: 0x0400027C RID: 636
		private uint? _joinTime;

		// Token: 0x0400027D RID: 637
		private GuildBindStatus? _bind_status;

		// Token: 0x0400027E RID: 638
		private uint? _update_bind_time;

		// Token: 0x0400027F RID: 639
		private uint? _weeklyschoolpoint;

		// Token: 0x04000280 RID: 640
		private uint? _weeklyschooltime;

		// Token: 0x04000281 RID: 641
		private uint? _weeklyhallpoint;

		// Token: 0x04000282 RID: 642
		private uint? _weeklyhalltime;

		// Token: 0x04000283 RID: 643
		private readonly List<GuildZiCaiItemData> _itemlist = new List<GuildZiCaiItemData>();

		// Token: 0x04000284 RID: 644
		private uint? _weeklyhuntcount;

		// Token: 0x04000285 RID: 645
		private uint? _weeklyhunttime;

		// Token: 0x04000286 RID: 646
		private IExtension extensionObject;
	}
}
