using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001A3 RID: 419
	[ProtoContract(Name = "SynGuildArenaBattleInfo")]
	[Serializable]
	public class SynGuildArenaBattleInfo : IExtensible
	{
		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x060018D6 RID: 6358 RVA: 0x00031614 File Offset: 0x0002F814
		// (set) Token: 0x060018D7 RID: 6359 RVA: 0x00031640 File Offset: 0x0002F840
		[ProtoMember(1, IsRequired = false, Name = "warType", DataFormat = DataFormat.TwosComplement)]
		public uint warType
		{
			get
			{
				return this._warType ?? 0U;
			}
			set
			{
				this._warType = new uint?(value);
			}
		}

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x060018D8 RID: 6360 RVA: 0x00031650 File Offset: 0x0002F850
		// (set) Token: 0x060018D9 RID: 6361 RVA: 0x00031670 File Offset: 0x0002F870
		[XmlIgnore]
		[Browsable(false)]
		public bool warTypeSpecified
		{
			get
			{
				return this._warType != null;
			}
			set
			{
				bool flag = value == (this._warType == null);
				if (flag)
				{
					this._warType = (value ? new uint?(this.warType) : null);
				}
			}
		}

		// Token: 0x060018DA RID: 6362 RVA: 0x000316B4 File Offset: 0x0002F8B4
		private bool ShouldSerializewarType()
		{
			return this.warTypeSpecified;
		}

		// Token: 0x060018DB RID: 6363 RVA: 0x000316CC File Offset: 0x0002F8CC
		private void ResetwarType()
		{
			this.warTypeSpecified = false;
		}

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x060018DC RID: 6364 RVA: 0x000316D8 File Offset: 0x0002F8D8
		[ProtoMember(2, Name = "arenaBattleInfo", DataFormat = DataFormat.Default)]
		public List<GuildArenaGroupData> arenaBattleInfo
		{
			get
			{
				return this._arenaBattleInfo;
			}
		}

		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x060018DD RID: 6365 RVA: 0x000316F0 File Offset: 0x0002F8F0
		// (set) Token: 0x060018DE RID: 6366 RVA: 0x0003171C File Offset: 0x0002F91C
		[ProtoMember(3, IsRequired = false, Name = "timestate", DataFormat = DataFormat.TwosComplement)]
		public GuildArenaState timestate
		{
			get
			{
				return this._timestate ?? GuildArenaState.GUILD_ARENA_NOT_BEGIN;
			}
			set
			{
				this._timestate = new GuildArenaState?(value);
			}
		}

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x060018DF RID: 6367 RVA: 0x0003172C File Offset: 0x0002F92C
		// (set) Token: 0x060018E0 RID: 6368 RVA: 0x0003174C File Offset: 0x0002F94C
		[XmlIgnore]
		[Browsable(false)]
		public bool timestateSpecified
		{
			get
			{
				return this._timestate != null;
			}
			set
			{
				bool flag = value == (this._timestate == null);
				if (flag)
				{
					this._timestate = (value ? new GuildArenaState?(this.timestate) : null);
				}
			}
		}

		// Token: 0x060018E1 RID: 6369 RVA: 0x00031790 File Offset: 0x0002F990
		private bool ShouldSerializetimestate()
		{
			return this.timestateSpecified;
		}

		// Token: 0x060018E2 RID: 6370 RVA: 0x000317A8 File Offset: 0x0002F9A8
		private void Resettimestate()
		{
			this.timestateSpecified = false;
		}

		// Token: 0x170007DA RID: 2010
		// (get) Token: 0x060018E3 RID: 6371 RVA: 0x000317B4 File Offset: 0x0002F9B4
		// (set) Token: 0x060018E4 RID: 6372 RVA: 0x000317E0 File Offset: 0x0002F9E0
		[ProtoMember(4, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x170007DB RID: 2011
		// (get) Token: 0x060018E5 RID: 6373 RVA: 0x000317F0 File Offset: 0x0002F9F0
		// (set) Token: 0x060018E6 RID: 6374 RVA: 0x00031810 File Offset: 0x0002FA10
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
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x060018E7 RID: 6375 RVA: 0x00031854 File Offset: 0x0002FA54
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x060018E8 RID: 6376 RVA: 0x0003186C File Offset: 0x0002FA6C
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x060018E9 RID: 6377 RVA: 0x00031878 File Offset: 0x0002FA78
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000629 RID: 1577
		private uint? _warType;

		// Token: 0x0400062A RID: 1578
		private readonly List<GuildArenaGroupData> _arenaBattleInfo = new List<GuildArenaGroupData>();

		// Token: 0x0400062B RID: 1579
		private GuildArenaState? _timestate;

		// Token: 0x0400062C RID: 1580
		private uint? _state;

		// Token: 0x0400062D RID: 1581
		private IExtension extensionObject;
	}
}
