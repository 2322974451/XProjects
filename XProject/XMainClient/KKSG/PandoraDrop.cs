using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005EC RID: 1516
	[ProtoContract(Name = "PandoraDrop")]
	[Serializable]
	public class PandoraDrop : IExtensible
	{
		// Token: 0x17001BFD RID: 7165
		// (get) Token: 0x060059AF RID: 22959 RVA: 0x000AAAF0 File Offset: 0x000A8CF0
		// (set) Token: 0x060059B0 RID: 22960 RVA: 0x000AAB1C File Offset: 0x000A8D1C
		[ProtoMember(1, IsRequired = false, Name = "pandoraDropID", DataFormat = DataFormat.TwosComplement)]
		public uint pandoraDropID
		{
			get
			{
				return this._pandoraDropID ?? 0U;
			}
			set
			{
				this._pandoraDropID = new uint?(value);
			}
		}

		// Token: 0x17001BFE RID: 7166
		// (get) Token: 0x060059B1 RID: 22961 RVA: 0x000AAB2C File Offset: 0x000A8D2C
		// (set) Token: 0x060059B2 RID: 22962 RVA: 0x000AAB4C File Offset: 0x000A8D4C
		[XmlIgnore]
		[Browsable(false)]
		public bool pandoraDropIDSpecified
		{
			get
			{
				return this._pandoraDropID != null;
			}
			set
			{
				bool flag = value == (this._pandoraDropID == null);
				if (flag)
				{
					this._pandoraDropID = (value ? new uint?(this.pandoraDropID) : null);
				}
			}
		}

		// Token: 0x060059B3 RID: 22963 RVA: 0x000AAB90 File Offset: 0x000A8D90
		private bool ShouldSerializepandoraDropID()
		{
			return this.pandoraDropIDSpecified;
		}

		// Token: 0x060059B4 RID: 22964 RVA: 0x000AABA8 File Offset: 0x000A8DA8
		private void ResetpandoraDropID()
		{
			this.pandoraDropIDSpecified = false;
		}

		// Token: 0x17001BFF RID: 7167
		// (get) Token: 0x060059B5 RID: 22965 RVA: 0x000AABB4 File Offset: 0x000A8DB4
		// (set) Token: 0x060059B6 RID: 22966 RVA: 0x000AABE0 File Offset: 0x000A8DE0
		[ProtoMember(2, IsRequired = false, Name = "betterDropTimes", DataFormat = DataFormat.TwosComplement)]
		public uint betterDropTimes
		{
			get
			{
				return this._betterDropTimes ?? 0U;
			}
			set
			{
				this._betterDropTimes = new uint?(value);
			}
		}

		// Token: 0x17001C00 RID: 7168
		// (get) Token: 0x060059B7 RID: 22967 RVA: 0x000AABF0 File Offset: 0x000A8DF0
		// (set) Token: 0x060059B8 RID: 22968 RVA: 0x000AAC10 File Offset: 0x000A8E10
		[XmlIgnore]
		[Browsable(false)]
		public bool betterDropTimesSpecified
		{
			get
			{
				return this._betterDropTimes != null;
			}
			set
			{
				bool flag = value == (this._betterDropTimes == null);
				if (flag)
				{
					this._betterDropTimes = (value ? new uint?(this.betterDropTimes) : null);
				}
			}
		}

		// Token: 0x060059B9 RID: 22969 RVA: 0x000AAC54 File Offset: 0x000A8E54
		private bool ShouldSerializebetterDropTimes()
		{
			return this.betterDropTimesSpecified;
		}

		// Token: 0x060059BA RID: 22970 RVA: 0x000AAC6C File Offset: 0x000A8E6C
		private void ResetbetterDropTimes()
		{
			this.betterDropTimesSpecified = false;
		}

		// Token: 0x17001C01 RID: 7169
		// (get) Token: 0x060059BB RID: 22971 RVA: 0x000AAC78 File Offset: 0x000A8E78
		// (set) Token: 0x060059BC RID: 22972 RVA: 0x000AACA4 File Offset: 0x000A8EA4
		[ProtoMember(3, IsRequired = false, Name = "noUsedBestDropTimes", DataFormat = DataFormat.TwosComplement)]
		public uint noUsedBestDropTimes
		{
			get
			{
				return this._noUsedBestDropTimes ?? 0U;
			}
			set
			{
				this._noUsedBestDropTimes = new uint?(value);
			}
		}

		// Token: 0x17001C02 RID: 7170
		// (get) Token: 0x060059BD RID: 22973 RVA: 0x000AACB4 File Offset: 0x000A8EB4
		// (set) Token: 0x060059BE RID: 22974 RVA: 0x000AACD4 File Offset: 0x000A8ED4
		[XmlIgnore]
		[Browsable(false)]
		public bool noUsedBestDropTimesSpecified
		{
			get
			{
				return this._noUsedBestDropTimes != null;
			}
			set
			{
				bool flag = value == (this._noUsedBestDropTimes == null);
				if (flag)
				{
					this._noUsedBestDropTimes = (value ? new uint?(this.noUsedBestDropTimes) : null);
				}
			}
		}

		// Token: 0x060059BF RID: 22975 RVA: 0x000AAD18 File Offset: 0x000A8F18
		private bool ShouldSerializenoUsedBestDropTimes()
		{
			return this.noUsedBestDropTimesSpecified;
		}

		// Token: 0x060059C0 RID: 22976 RVA: 0x000AAD30 File Offset: 0x000A8F30
		private void ResetnoUsedBestDropTimes()
		{
			this.noUsedBestDropTimesSpecified = false;
		}

		// Token: 0x17001C03 RID: 7171
		// (get) Token: 0x060059C1 RID: 22977 RVA: 0x000AAD3C File Offset: 0x000A8F3C
		// (set) Token: 0x060059C2 RID: 22978 RVA: 0x000AAD68 File Offset: 0x000A8F68
		[ProtoMember(4, IsRequired = false, Name = "nextBetterDropTimes", DataFormat = DataFormat.TwosComplement)]
		public uint nextBetterDropTimes
		{
			get
			{
				return this._nextBetterDropTimes ?? 0U;
			}
			set
			{
				this._nextBetterDropTimes = new uint?(value);
			}
		}

		// Token: 0x17001C04 RID: 7172
		// (get) Token: 0x060059C3 RID: 22979 RVA: 0x000AAD78 File Offset: 0x000A8F78
		// (set) Token: 0x060059C4 RID: 22980 RVA: 0x000AAD98 File Offset: 0x000A8F98
		[XmlIgnore]
		[Browsable(false)]
		public bool nextBetterDropTimesSpecified
		{
			get
			{
				return this._nextBetterDropTimes != null;
			}
			set
			{
				bool flag = value == (this._nextBetterDropTimes == null);
				if (flag)
				{
					this._nextBetterDropTimes = (value ? new uint?(this.nextBetterDropTimes) : null);
				}
			}
		}

		// Token: 0x060059C5 RID: 22981 RVA: 0x000AADDC File Offset: 0x000A8FDC
		private bool ShouldSerializenextBetterDropTimes()
		{
			return this.nextBetterDropTimesSpecified;
		}

		// Token: 0x060059C6 RID: 22982 RVA: 0x000AADF4 File Offset: 0x000A8FF4
		private void ResetnextBetterDropTimes()
		{
			this.nextBetterDropTimesSpecified = false;
		}

		// Token: 0x17001C05 RID: 7173
		// (get) Token: 0x060059C7 RID: 22983 RVA: 0x000AAE00 File Offset: 0x000A9000
		// (set) Token: 0x060059C8 RID: 22984 RVA: 0x000AAE2C File Offset: 0x000A902C
		[ProtoMember(5, IsRequired = false, Name = "noUsedNextBestDropTimes", DataFormat = DataFormat.TwosComplement)]
		public uint noUsedNextBestDropTimes
		{
			get
			{
				return this._noUsedNextBestDropTimes ?? 0U;
			}
			set
			{
				this._noUsedNextBestDropTimes = new uint?(value);
			}
		}

		// Token: 0x17001C06 RID: 7174
		// (get) Token: 0x060059C9 RID: 22985 RVA: 0x000AAE3C File Offset: 0x000A903C
		// (set) Token: 0x060059CA RID: 22986 RVA: 0x000AAE5C File Offset: 0x000A905C
		[XmlIgnore]
		[Browsable(false)]
		public bool noUsedNextBestDropTimesSpecified
		{
			get
			{
				return this._noUsedNextBestDropTimes != null;
			}
			set
			{
				bool flag = value == (this._noUsedNextBestDropTimes == null);
				if (flag)
				{
					this._noUsedNextBestDropTimes = (value ? new uint?(this.noUsedNextBestDropTimes) : null);
				}
			}
		}

		// Token: 0x060059CB RID: 22987 RVA: 0x000AAEA0 File Offset: 0x000A90A0
		private bool ShouldSerializenoUsedNextBestDropTimes()
		{
			return this.noUsedNextBestDropTimesSpecified;
		}

		// Token: 0x060059CC RID: 22988 RVA: 0x000AAEB8 File Offset: 0x000A90B8
		private void ResetnoUsedNextBestDropTimes()
		{
			this.noUsedNextBestDropTimesSpecified = false;
		}

		// Token: 0x17001C07 RID: 7175
		// (get) Token: 0x060059CD RID: 22989 RVA: 0x000AAEC4 File Offset: 0x000A90C4
		[ProtoMember(6, Name = "bestDropTimes", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bestDropTimes
		{
			get
			{
				return this._bestDropTimes;
			}
		}

		// Token: 0x17001C08 RID: 7176
		// (get) Token: 0x060059CE RID: 22990 RVA: 0x000AAEDC File Offset: 0x000A90DC
		[ProtoMember(7, Name = "nextBestDropTimes", DataFormat = DataFormat.TwosComplement)]
		public List<uint> nextBestDropTimes
		{
			get
			{
				return this._nextBestDropTimes;
			}
		}

		// Token: 0x060059CF RID: 22991 RVA: 0x000AAEF4 File Offset: 0x000A90F4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040015CF RID: 5583
		private uint? _pandoraDropID;

		// Token: 0x040015D0 RID: 5584
		private uint? _betterDropTimes;

		// Token: 0x040015D1 RID: 5585
		private uint? _noUsedBestDropTimes;

		// Token: 0x040015D2 RID: 5586
		private uint? _nextBetterDropTimes;

		// Token: 0x040015D3 RID: 5587
		private uint? _noUsedNextBestDropTimes;

		// Token: 0x040015D4 RID: 5588
		private readonly List<uint> _bestDropTimes = new List<uint>();

		// Token: 0x040015D5 RID: 5589
		private readonly List<uint> _nextBestDropTimes = new List<uint>();

		// Token: 0x040015D6 RID: 5590
		private IExtension extensionObject;
	}
}
