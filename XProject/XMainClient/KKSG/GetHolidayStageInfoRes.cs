using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000398 RID: 920
	[ProtoContract(Name = "GetHolidayStageInfoRes")]
	[Serializable]
	public class GetHolidayStageInfoRes : IExtensible
	{
		// Token: 0x17000F57 RID: 3927
		// (get) Token: 0x060031A6 RID: 12710 RVA: 0x0005F9A8 File Offset: 0x0005DBA8
		// (set) Token: 0x060031A7 RID: 12711 RVA: 0x0005F9D4 File Offset: 0x0005DBD4
		[ProtoMember(1, IsRequired = false, Name = "holidayid", DataFormat = DataFormat.TwosComplement)]
		public uint holidayid
		{
			get
			{
				return this._holidayid ?? 0U;
			}
			set
			{
				this._holidayid = new uint?(value);
			}
		}

		// Token: 0x17000F58 RID: 3928
		// (get) Token: 0x060031A8 RID: 12712 RVA: 0x0005F9E4 File Offset: 0x0005DBE4
		// (set) Token: 0x060031A9 RID: 12713 RVA: 0x0005FA04 File Offset: 0x0005DC04
		[XmlIgnore]
		[Browsable(false)]
		public bool holidayidSpecified
		{
			get
			{
				return this._holidayid != null;
			}
			set
			{
				bool flag = value == (this._holidayid == null);
				if (flag)
				{
					this._holidayid = (value ? new uint?(this.holidayid) : null);
				}
			}
		}

		// Token: 0x060031AA RID: 12714 RVA: 0x0005FA48 File Offset: 0x0005DC48
		private bool ShouldSerializeholidayid()
		{
			return this.holidayidSpecified;
		}

		// Token: 0x060031AB RID: 12715 RVA: 0x0005FA60 File Offset: 0x0005DC60
		private void Resetholidayid()
		{
			this.holidayidSpecified = false;
		}

		// Token: 0x17000F59 RID: 3929
		// (get) Token: 0x060031AC RID: 12716 RVA: 0x0005FA6C File Offset: 0x0005DC6C
		// (set) Token: 0x060031AD RID: 12717 RVA: 0x0005FA98 File Offset: 0x0005DC98
		[ProtoMember(2, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000F5A RID: 3930
		// (get) Token: 0x060031AE RID: 12718 RVA: 0x0005FAA8 File Offset: 0x0005DCA8
		// (set) Token: 0x060031AF RID: 12719 RVA: 0x0005FAC8 File Offset: 0x0005DCC8
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

		// Token: 0x060031B0 RID: 12720 RVA: 0x0005FB0C File Offset: 0x0005DD0C
		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		// Token: 0x060031B1 RID: 12721 RVA: 0x0005FB24 File Offset: 0x0005DD24
		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		// Token: 0x17000F5B RID: 3931
		// (get) Token: 0x060031B2 RID: 12722 RVA: 0x0005FB30 File Offset: 0x0005DD30
		// (set) Token: 0x060031B3 RID: 12723 RVA: 0x0005FB5C File Offset: 0x0005DD5C
		[ProtoMember(3, IsRequired = false, Name = "lasttime", DataFormat = DataFormat.TwosComplement)]
		public uint lasttime
		{
			get
			{
				return this._lasttime ?? 0U;
			}
			set
			{
				this._lasttime = new uint?(value);
			}
		}

		// Token: 0x17000F5C RID: 3932
		// (get) Token: 0x060031B4 RID: 12724 RVA: 0x0005FB6C File Offset: 0x0005DD6C
		// (set) Token: 0x060031B5 RID: 12725 RVA: 0x0005FB8C File Offset: 0x0005DD8C
		[XmlIgnore]
		[Browsable(false)]
		public bool lasttimeSpecified
		{
			get
			{
				return this._lasttime != null;
			}
			set
			{
				bool flag = value == (this._lasttime == null);
				if (flag)
				{
					this._lasttime = (value ? new uint?(this.lasttime) : null);
				}
			}
		}

		// Token: 0x060031B6 RID: 12726 RVA: 0x0005FBD0 File Offset: 0x0005DDD0
		private bool ShouldSerializelasttime()
		{
			return this.lasttimeSpecified;
		}

		// Token: 0x060031B7 RID: 12727 RVA: 0x0005FBE8 File Offset: 0x0005DDE8
		private void Resetlasttime()
		{
			this.lasttimeSpecified = false;
		}

		// Token: 0x17000F5D RID: 3933
		// (get) Token: 0x060031B8 RID: 12728 RVA: 0x0005FBF4 File Offset: 0x0005DDF4
		// (set) Token: 0x060031B9 RID: 12729 RVA: 0x0005FC20 File Offset: 0x0005DE20
		[ProtoMember(4, IsRequired = false, Name = "havetimes", DataFormat = DataFormat.TwosComplement)]
		public uint havetimes
		{
			get
			{
				return this._havetimes ?? 0U;
			}
			set
			{
				this._havetimes = new uint?(value);
			}
		}

		// Token: 0x17000F5E RID: 3934
		// (get) Token: 0x060031BA RID: 12730 RVA: 0x0005FC30 File Offset: 0x0005DE30
		// (set) Token: 0x060031BB RID: 12731 RVA: 0x0005FC50 File Offset: 0x0005DE50
		[XmlIgnore]
		[Browsable(false)]
		public bool havetimesSpecified
		{
			get
			{
				return this._havetimes != null;
			}
			set
			{
				bool flag = value == (this._havetimes == null);
				if (flag)
				{
					this._havetimes = (value ? new uint?(this.havetimes) : null);
				}
			}
		}

		// Token: 0x060031BC RID: 12732 RVA: 0x0005FC94 File Offset: 0x0005DE94
		private bool ShouldSerializehavetimes()
		{
			return this.havetimesSpecified;
		}

		// Token: 0x060031BD RID: 12733 RVA: 0x0005FCAC File Offset: 0x0005DEAC
		private void Resethavetimes()
		{
			this.havetimesSpecified = false;
		}

		// Token: 0x060031BE RID: 12734 RVA: 0x0005FCB8 File Offset: 0x0005DEB8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C55 RID: 3157
		private uint? _holidayid;

		// Token: 0x04000C56 RID: 3158
		private uint? _sceneid;

		// Token: 0x04000C57 RID: 3159
		private uint? _lasttime;

		// Token: 0x04000C58 RID: 3160
		private uint? _havetimes;

		// Token: 0x04000C59 RID: 3161
		private IExtension extensionObject;
	}
}
