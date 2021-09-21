using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000675 RID: 1653
	[ProtoContract(Name = "BattleFieldData")]
	[Serializable]
	public class BattleFieldData : IExtensible
	{
		// Token: 0x17002163 RID: 8547
		// (get) Token: 0x0600698F RID: 27023 RVA: 0x000C9D14 File Offset: 0x000C7F14
		// (set) Token: 0x06006990 RID: 27024 RVA: 0x000C9D40 File Offset: 0x000C7F40
		[ProtoMember(1, IsRequired = false, Name = "firstrankcount", DataFormat = DataFormat.TwosComplement)]
		public uint firstrankcount
		{
			get
			{
				return this._firstrankcount ?? 0U;
			}
			set
			{
				this._firstrankcount = new uint?(value);
			}
		}

		// Token: 0x17002164 RID: 8548
		// (get) Token: 0x06006991 RID: 27025 RVA: 0x000C9D50 File Offset: 0x000C7F50
		// (set) Token: 0x06006992 RID: 27026 RVA: 0x000C9D70 File Offset: 0x000C7F70
		[XmlIgnore]
		[Browsable(false)]
		public bool firstrankcountSpecified
		{
			get
			{
				return this._firstrankcount != null;
			}
			set
			{
				bool flag = value == (this._firstrankcount == null);
				if (flag)
				{
					this._firstrankcount = (value ? new uint?(this.firstrankcount) : null);
				}
			}
		}

		// Token: 0x06006993 RID: 27027 RVA: 0x000C9DB4 File Offset: 0x000C7FB4
		private bool ShouldSerializefirstrankcount()
		{
			return this.firstrankcountSpecified;
		}

		// Token: 0x06006994 RID: 27028 RVA: 0x000C9DCC File Offset: 0x000C7FCC
		private void Resetfirstrankcount()
		{
			this.firstrankcountSpecified = false;
		}

		// Token: 0x17002165 RID: 8549
		// (get) Token: 0x06006995 RID: 27029 RVA: 0x000C9DD8 File Offset: 0x000C7FD8
		// (set) Token: 0x06006996 RID: 27030 RVA: 0x000C9E04 File Offset: 0x000C8004
		[ProtoMember(2, IsRequired = false, Name = "totalkillcount", DataFormat = DataFormat.TwosComplement)]
		public uint totalkillcount
		{
			get
			{
				return this._totalkillcount ?? 0U;
			}
			set
			{
				this._totalkillcount = new uint?(value);
			}
		}

		// Token: 0x17002166 RID: 8550
		// (get) Token: 0x06006997 RID: 27031 RVA: 0x000C9E14 File Offset: 0x000C8014
		// (set) Token: 0x06006998 RID: 27032 RVA: 0x000C9E34 File Offset: 0x000C8034
		[XmlIgnore]
		[Browsable(false)]
		public bool totalkillcountSpecified
		{
			get
			{
				return this._totalkillcount != null;
			}
			set
			{
				bool flag = value == (this._totalkillcount == null);
				if (flag)
				{
					this._totalkillcount = (value ? new uint?(this.totalkillcount) : null);
				}
			}
		}

		// Token: 0x06006999 RID: 27033 RVA: 0x000C9E78 File Offset: 0x000C8078
		private bool ShouldSerializetotalkillcount()
		{
			return this.totalkillcountSpecified;
		}

		// Token: 0x0600699A RID: 27034 RVA: 0x000C9E90 File Offset: 0x000C8090
		private void Resettotalkillcount()
		{
			this.totalkillcountSpecified = false;
		}

		// Token: 0x17002167 RID: 8551
		// (get) Token: 0x0600699B RID: 27035 RVA: 0x000C9E9C File Offset: 0x000C809C
		[ProtoMember(3, Name = "point", DataFormat = DataFormat.Default)]
		public List<BattleFieldPoint> point
		{
			get
			{
				return this._point;
			}
		}

		// Token: 0x17002168 RID: 8552
		// (get) Token: 0x0600699C RID: 27036 RVA: 0x000C9EB4 File Offset: 0x000C80B4
		// (set) Token: 0x0600699D RID: 27037 RVA: 0x000C9EE0 File Offset: 0x000C80E0
		[ProtoMember(4, IsRequired = false, Name = "lastupdatetime", DataFormat = DataFormat.TwosComplement)]
		public uint lastupdatetime
		{
			get
			{
				return this._lastupdatetime ?? 0U;
			}
			set
			{
				this._lastupdatetime = new uint?(value);
			}
		}

		// Token: 0x17002169 RID: 8553
		// (get) Token: 0x0600699E RID: 27038 RVA: 0x000C9EF0 File Offset: 0x000C80F0
		// (set) Token: 0x0600699F RID: 27039 RVA: 0x000C9F10 File Offset: 0x000C8110
		[XmlIgnore]
		[Browsable(false)]
		public bool lastupdatetimeSpecified
		{
			get
			{
				return this._lastupdatetime != null;
			}
			set
			{
				bool flag = value == (this._lastupdatetime == null);
				if (flag)
				{
					this._lastupdatetime = (value ? new uint?(this.lastupdatetime) : null);
				}
			}
		}

		// Token: 0x060069A0 RID: 27040 RVA: 0x000C9F54 File Offset: 0x000C8154
		private bool ShouldSerializelastupdatetime()
		{
			return this.lastupdatetimeSpecified;
		}

		// Token: 0x060069A1 RID: 27041 RVA: 0x000C9F6C File Offset: 0x000C816C
		private void Resetlastupdatetime()
		{
			this.lastupdatetimeSpecified = false;
		}

		// Token: 0x1700216A RID: 8554
		// (get) Token: 0x060069A2 RID: 27042 RVA: 0x000C9F78 File Offset: 0x000C8178
		// (set) Token: 0x060069A3 RID: 27043 RVA: 0x000C9F90 File Offset: 0x000C8190
		[ProtoMember(5, IsRequired = false, Name = "hell", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HellDropInfoAll hell
		{
			get
			{
				return this._hell;
			}
			set
			{
				this._hell = value;
			}
		}

		// Token: 0x1700216B RID: 8555
		// (get) Token: 0x060069A4 RID: 27044 RVA: 0x000C9F9C File Offset: 0x000C819C
		// (set) Token: 0x060069A5 RID: 27045 RVA: 0x000C9FC8 File Offset: 0x000C81C8
		[ProtoMember(6, IsRequired = false, Name = "weekpoint", DataFormat = DataFormat.TwosComplement)]
		public uint weekpoint
		{
			get
			{
				return this._weekpoint ?? 0U;
			}
			set
			{
				this._weekpoint = new uint?(value);
			}
		}

		// Token: 0x1700216C RID: 8556
		// (get) Token: 0x060069A6 RID: 27046 RVA: 0x000C9FD8 File Offset: 0x000C81D8
		// (set) Token: 0x060069A7 RID: 27047 RVA: 0x000C9FF8 File Offset: 0x000C81F8
		[XmlIgnore]
		[Browsable(false)]
		public bool weekpointSpecified
		{
			get
			{
				return this._weekpoint != null;
			}
			set
			{
				bool flag = value == (this._weekpoint == null);
				if (flag)
				{
					this._weekpoint = (value ? new uint?(this.weekpoint) : null);
				}
			}
		}

		// Token: 0x060069A8 RID: 27048 RVA: 0x000CA03C File Offset: 0x000C823C
		private bool ShouldSerializeweekpoint()
		{
			return this.weekpointSpecified;
		}

		// Token: 0x060069A9 RID: 27049 RVA: 0x000CA054 File Offset: 0x000C8254
		private void Resetweekpoint()
		{
			this.weekpointSpecified = false;
		}

		// Token: 0x1700216D RID: 8557
		// (get) Token: 0x060069AA RID: 27050 RVA: 0x000CA060 File Offset: 0x000C8260
		// (set) Token: 0x060069AB RID: 27051 RVA: 0x000CA08C File Offset: 0x000C828C
		[ProtoMember(7, IsRequired = false, Name = "dayupdatetime", DataFormat = DataFormat.TwosComplement)]
		public uint dayupdatetime
		{
			get
			{
				return this._dayupdatetime ?? 0U;
			}
			set
			{
				this._dayupdatetime = new uint?(value);
			}
		}

		// Token: 0x1700216E RID: 8558
		// (get) Token: 0x060069AC RID: 27052 RVA: 0x000CA09C File Offset: 0x000C829C
		// (set) Token: 0x060069AD RID: 27053 RVA: 0x000CA0BC File Offset: 0x000C82BC
		[XmlIgnore]
		[Browsable(false)]
		public bool dayupdatetimeSpecified
		{
			get
			{
				return this._dayupdatetime != null;
			}
			set
			{
				bool flag = value == (this._dayupdatetime == null);
				if (flag)
				{
					this._dayupdatetime = (value ? new uint?(this.dayupdatetime) : null);
				}
			}
		}

		// Token: 0x060069AE RID: 27054 RVA: 0x000CA100 File Offset: 0x000C8300
		private bool ShouldSerializedayupdatetime()
		{
			return this.dayupdatetimeSpecified;
		}

		// Token: 0x060069AF RID: 27055 RVA: 0x000CA118 File Offset: 0x000C8318
		private void Resetdayupdatetime()
		{
			this.dayupdatetimeSpecified = false;
		}

		// Token: 0x1700216F RID: 8559
		// (get) Token: 0x060069B0 RID: 27056 RVA: 0x000CA124 File Offset: 0x000C8324
		// (set) Token: 0x060069B1 RID: 27057 RVA: 0x000CA150 File Offset: 0x000C8350
		[ProtoMember(8, IsRequired = false, Name = "version", DataFormat = DataFormat.TwosComplement)]
		public uint version
		{
			get
			{
				return this._version ?? 0U;
			}
			set
			{
				this._version = new uint?(value);
			}
		}

		// Token: 0x17002170 RID: 8560
		// (get) Token: 0x060069B2 RID: 27058 RVA: 0x000CA160 File Offset: 0x000C8360
		// (set) Token: 0x060069B3 RID: 27059 RVA: 0x000CA180 File Offset: 0x000C8380
		[XmlIgnore]
		[Browsable(false)]
		public bool versionSpecified
		{
			get
			{
				return this._version != null;
			}
			set
			{
				bool flag = value == (this._version == null);
				if (flag)
				{
					this._version = (value ? new uint?(this.version) : null);
				}
			}
		}

		// Token: 0x060069B4 RID: 27060 RVA: 0x000CA1C4 File Offset: 0x000C83C4
		private bool ShouldSerializeversion()
		{
			return this.versionSpecified;
		}

		// Token: 0x060069B5 RID: 27061 RVA: 0x000CA1DC File Offset: 0x000C83DC
		private void Resetversion()
		{
			this.versionSpecified = false;
		}

		// Token: 0x060069B6 RID: 27062 RVA: 0x000CA1E8 File Offset: 0x000C83E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001970 RID: 6512
		private uint? _firstrankcount;

		// Token: 0x04001971 RID: 6513
		private uint? _totalkillcount;

		// Token: 0x04001972 RID: 6514
		private readonly List<BattleFieldPoint> _point = new List<BattleFieldPoint>();

		// Token: 0x04001973 RID: 6515
		private uint? _lastupdatetime;

		// Token: 0x04001974 RID: 6516
		private HellDropInfoAll _hell = null;

		// Token: 0x04001975 RID: 6517
		private uint? _weekpoint;

		// Token: 0x04001976 RID: 6518
		private uint? _dayupdatetime;

		// Token: 0x04001977 RID: 6519
		private uint? _version;

		// Token: 0x04001978 RID: 6520
		private IExtension extensionObject;
	}
}
