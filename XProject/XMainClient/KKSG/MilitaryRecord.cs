using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003B8 RID: 952
	[ProtoContract(Name = "MilitaryRecord")]
	[Serializable]
	public class MilitaryRecord : IExtensible
	{
		// Token: 0x17000FA6 RID: 4006
		// (get) Token: 0x060032C4 RID: 12996 RVA: 0x00061970 File Offset: 0x0005FB70
		// (set) Token: 0x060032C5 RID: 12997 RVA: 0x0006199C File Offset: 0x0005FB9C
		[ProtoMember(1, IsRequired = false, Name = "military_rank", DataFormat = DataFormat.TwosComplement)]
		public uint military_rank
		{
			get
			{
				return this._military_rank ?? 0U;
			}
			set
			{
				this._military_rank = new uint?(value);
			}
		}

		// Token: 0x17000FA7 RID: 4007
		// (get) Token: 0x060032C6 RID: 12998 RVA: 0x000619AC File Offset: 0x0005FBAC
		// (set) Token: 0x060032C7 RID: 12999 RVA: 0x000619CC File Offset: 0x0005FBCC
		[XmlIgnore]
		[Browsable(false)]
		public bool military_rankSpecified
		{
			get
			{
				return this._military_rank != null;
			}
			set
			{
				bool flag = value == (this._military_rank == null);
				if (flag)
				{
					this._military_rank = (value ? new uint?(this.military_rank) : null);
				}
			}
		}

		// Token: 0x060032C8 RID: 13000 RVA: 0x00061A10 File Offset: 0x0005FC10
		private bool ShouldSerializemilitary_rank()
		{
			return this.military_rankSpecified;
		}

		// Token: 0x060032C9 RID: 13001 RVA: 0x00061A28 File Offset: 0x0005FC28
		private void Resetmilitary_rank()
		{
			this.military_rankSpecified = false;
		}

		// Token: 0x17000FA8 RID: 4008
		// (get) Token: 0x060032CA RID: 13002 RVA: 0x00061A34 File Offset: 0x0005FC34
		// (set) Token: 0x060032CB RID: 13003 RVA: 0x00061A60 File Offset: 0x0005FC60
		[ProtoMember(2, IsRequired = false, Name = "military_rank_his", DataFormat = DataFormat.TwosComplement)]
		public uint military_rank_his
		{
			get
			{
				return this._military_rank_his ?? 0U;
			}
			set
			{
				this._military_rank_his = new uint?(value);
			}
		}

		// Token: 0x17000FA9 RID: 4009
		// (get) Token: 0x060032CC RID: 13004 RVA: 0x00061A70 File Offset: 0x0005FC70
		// (set) Token: 0x060032CD RID: 13005 RVA: 0x00061A90 File Offset: 0x0005FC90
		[XmlIgnore]
		[Browsable(false)]
		public bool military_rank_hisSpecified
		{
			get
			{
				return this._military_rank_his != null;
			}
			set
			{
				bool flag = value == (this._military_rank_his == null);
				if (flag)
				{
					this._military_rank_his = (value ? new uint?(this.military_rank_his) : null);
				}
			}
		}

		// Token: 0x060032CE RID: 13006 RVA: 0x00061AD4 File Offset: 0x0005FCD4
		private bool ShouldSerializemilitary_rank_his()
		{
			return this.military_rank_hisSpecified;
		}

		// Token: 0x060032CF RID: 13007 RVA: 0x00061AEC File Offset: 0x0005FCEC
		private void Resetmilitary_rank_his()
		{
			this.military_rank_hisSpecified = false;
		}

		// Token: 0x17000FAA RID: 4010
		// (get) Token: 0x060032D0 RID: 13008 RVA: 0x00061AF8 File Offset: 0x0005FCF8
		// (set) Token: 0x060032D1 RID: 13009 RVA: 0x00061B24 File Offset: 0x0005FD24
		[ProtoMember(3, IsRequired = false, Name = "military_exploit", DataFormat = DataFormat.TwosComplement)]
		public uint military_exploit
		{
			get
			{
				return this._military_exploit ?? 0U;
			}
			set
			{
				this._military_exploit = new uint?(value);
			}
		}

		// Token: 0x17000FAB RID: 4011
		// (get) Token: 0x060032D2 RID: 13010 RVA: 0x00061B34 File Offset: 0x0005FD34
		// (set) Token: 0x060032D3 RID: 13011 RVA: 0x00061B54 File Offset: 0x0005FD54
		[XmlIgnore]
		[Browsable(false)]
		public bool military_exploitSpecified
		{
			get
			{
				return this._military_exploit != null;
			}
			set
			{
				bool flag = value == (this._military_exploit == null);
				if (flag)
				{
					this._military_exploit = (value ? new uint?(this.military_exploit) : null);
				}
			}
		}

		// Token: 0x060032D4 RID: 13012 RVA: 0x00061B98 File Offset: 0x0005FD98
		private bool ShouldSerializemilitary_exploit()
		{
			return this.military_exploitSpecified;
		}

		// Token: 0x060032D5 RID: 13013 RVA: 0x00061BB0 File Offset: 0x0005FDB0
		private void Resetmilitary_exploit()
		{
			this.military_exploitSpecified = false;
		}

		// Token: 0x17000FAC RID: 4012
		// (get) Token: 0x060032D6 RID: 13014 RVA: 0x00061BBC File Offset: 0x0005FDBC
		// (set) Token: 0x060032D7 RID: 13015 RVA: 0x00061BE8 File Offset: 0x0005FDE8
		[ProtoMember(4, IsRequired = false, Name = "military_exploit_his", DataFormat = DataFormat.TwosComplement)]
		public uint military_exploit_his
		{
			get
			{
				return this._military_exploit_his ?? 0U;
			}
			set
			{
				this._military_exploit_his = new uint?(value);
			}
		}

		// Token: 0x17000FAD RID: 4013
		// (get) Token: 0x060032D8 RID: 13016 RVA: 0x00061BF8 File Offset: 0x0005FDF8
		// (set) Token: 0x060032D9 RID: 13017 RVA: 0x00061C18 File Offset: 0x0005FE18
		[XmlIgnore]
		[Browsable(false)]
		public bool military_exploit_hisSpecified
		{
			get
			{
				return this._military_exploit_his != null;
			}
			set
			{
				bool flag = value == (this._military_exploit_his == null);
				if (flag)
				{
					this._military_exploit_his = (value ? new uint?(this.military_exploit_his) : null);
				}
			}
		}

		// Token: 0x060032DA RID: 13018 RVA: 0x00061C5C File Offset: 0x0005FE5C
		private bool ShouldSerializemilitary_exploit_his()
		{
			return this.military_exploit_hisSpecified;
		}

		// Token: 0x060032DB RID: 13019 RVA: 0x00061C74 File Offset: 0x0005FE74
		private void Resetmilitary_exploit_his()
		{
			this.military_exploit_hisSpecified = false;
		}

		// Token: 0x17000FAE RID: 4014
		// (get) Token: 0x060032DC RID: 13020 RVA: 0x00061C80 File Offset: 0x0005FE80
		// (set) Token: 0x060032DD RID: 13021 RVA: 0x00061CAC File Offset: 0x0005FEAC
		[ProtoMember(5, IsRequired = false, Name = "last_update_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_update_time
		{
			get
			{
				return this._last_update_time ?? 0U;
			}
			set
			{
				this._last_update_time = new uint?(value);
			}
		}

		// Token: 0x17000FAF RID: 4015
		// (get) Token: 0x060032DE RID: 13022 RVA: 0x00061CBC File Offset: 0x0005FEBC
		// (set) Token: 0x060032DF RID: 13023 RVA: 0x00061CDC File Offset: 0x0005FEDC
		[XmlIgnore]
		[Browsable(false)]
		public bool last_update_timeSpecified
		{
			get
			{
				return this._last_update_time != null;
			}
			set
			{
				bool flag = value == (this._last_update_time == null);
				if (flag)
				{
					this._last_update_time = (value ? new uint?(this.last_update_time) : null);
				}
			}
		}

		// Token: 0x060032E0 RID: 13024 RVA: 0x00061D20 File Offset: 0x0005FF20
		private bool ShouldSerializelast_update_time()
		{
			return this.last_update_timeSpecified;
		}

		// Token: 0x060032E1 RID: 13025 RVA: 0x00061D38 File Offset: 0x0005FF38
		private void Resetlast_update_time()
		{
			this.last_update_timeSpecified = false;
		}

		// Token: 0x17000FB0 RID: 4016
		// (get) Token: 0x060032E2 RID: 13026 RVA: 0x00061D44 File Offset: 0x0005FF44
		[ProtoMember(6, Name = "achieve_rank", DataFormat = DataFormat.TwosComplement)]
		public List<uint> achieve_rank
		{
			get
			{
				return this._achieve_rank;
			}
		}

		// Token: 0x060032E3 RID: 13027 RVA: 0x00061D5C File Offset: 0x0005FF5C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CA2 RID: 3234
		private uint? _military_rank;

		// Token: 0x04000CA3 RID: 3235
		private uint? _military_rank_his;

		// Token: 0x04000CA4 RID: 3236
		private uint? _military_exploit;

		// Token: 0x04000CA5 RID: 3237
		private uint? _military_exploit_his;

		// Token: 0x04000CA6 RID: 3238
		private uint? _last_update_time;

		// Token: 0x04000CA7 RID: 3239
		private readonly List<uint> _achieve_rank = new List<uint>();

		// Token: 0x04000CA8 RID: 3240
		private IExtension extensionObject;
	}
}
