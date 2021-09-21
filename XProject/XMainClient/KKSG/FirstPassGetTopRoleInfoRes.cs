using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001E5 RID: 485
	[ProtoContract(Name = "FirstPassGetTopRoleInfoRes")]
	[Serializable]
	public class FirstPassGetTopRoleInfoRes : IExtensible
	{
		// Token: 0x170008BB RID: 2235
		// (get) Token: 0x06001BD5 RID: 7125 RVA: 0x00036EF8 File Offset: 0x000350F8
		// (set) Token: 0x06001BD6 RID: 7126 RVA: 0x00036F24 File Offset: 0x00035124
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x170008BC RID: 2236
		// (get) Token: 0x06001BD7 RID: 7127 RVA: 0x00036F34 File Offset: 0x00035134
		// (set) Token: 0x06001BD8 RID: 7128 RVA: 0x00036F54 File Offset: 0x00035154
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06001BD9 RID: 7129 RVA: 0x00036F98 File Offset: 0x00035198
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001BDA RID: 7130 RVA: 0x00036FB0 File Offset: 0x000351B0
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x170008BD RID: 2237
		// (get) Token: 0x06001BDB RID: 7131 RVA: 0x00036FBC File Offset: 0x000351BC
		[ProtoMember(2, Name = "infos", DataFormat = DataFormat.Default)]
		public List<UnitAppearance> infos
		{
			get
			{
				return this._infos;
			}
		}

		// Token: 0x170008BE RID: 2238
		// (get) Token: 0x06001BDC RID: 7132 RVA: 0x00036FD4 File Offset: 0x000351D4
		// (set) Token: 0x06001BDD RID: 7133 RVA: 0x00037000 File Offset: 0x00035200
		[ProtoMember(3, IsRequired = false, Name = "commendNum", DataFormat = DataFormat.TwosComplement)]
		public int commendNum
		{
			get
			{
				return this._commendNum ?? 0;
			}
			set
			{
				this._commendNum = new int?(value);
			}
		}

		// Token: 0x170008BF RID: 2239
		// (get) Token: 0x06001BDE RID: 7134 RVA: 0x00037010 File Offset: 0x00035210
		// (set) Token: 0x06001BDF RID: 7135 RVA: 0x00037030 File Offset: 0x00035230
		[XmlIgnore]
		[Browsable(false)]
		public bool commendNumSpecified
		{
			get
			{
				return this._commendNum != null;
			}
			set
			{
				bool flag = value == (this._commendNum == null);
				if (flag)
				{
					this._commendNum = (value ? new int?(this.commendNum) : null);
				}
			}
		}

		// Token: 0x06001BE0 RID: 7136 RVA: 0x00037074 File Offset: 0x00035274
		private bool ShouldSerializecommendNum()
		{
			return this.commendNumSpecified;
		}

		// Token: 0x06001BE1 RID: 7137 RVA: 0x0003708C File Offset: 0x0003528C
		private void ResetcommendNum()
		{
			this.commendNumSpecified = false;
		}

		// Token: 0x170008C0 RID: 2240
		// (get) Token: 0x06001BE2 RID: 7138 RVA: 0x00037098 File Offset: 0x00035298
		// (set) Token: 0x06001BE3 RID: 7139 RVA: 0x000370C4 File Offset: 0x000352C4
		[ProtoMember(4, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public int time
		{
			get
			{
				return this._time ?? 0;
			}
			set
			{
				this._time = new int?(value);
			}
		}

		// Token: 0x170008C1 RID: 2241
		// (get) Token: 0x06001BE4 RID: 7140 RVA: 0x000370D4 File Offset: 0x000352D4
		// (set) Token: 0x06001BE5 RID: 7141 RVA: 0x000370F4 File Offset: 0x000352F4
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
					this._time = (value ? new int?(this.time) : null);
				}
			}
		}

		// Token: 0x06001BE6 RID: 7142 RVA: 0x00037138 File Offset: 0x00035338
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06001BE7 RID: 7143 RVA: 0x00037150 File Offset: 0x00035350
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170008C2 RID: 2242
		// (get) Token: 0x06001BE8 RID: 7144 RVA: 0x0003715C File Offset: 0x0003535C
		// (set) Token: 0x06001BE9 RID: 7145 RVA: 0x00037188 File Offset: 0x00035388
		[ProtoMember(5, IsRequired = false, Name = "starLevel", DataFormat = DataFormat.TwosComplement)]
		public int starLevel
		{
			get
			{
				return this._starLevel ?? 0;
			}
			set
			{
				this._starLevel = new int?(value);
			}
		}

		// Token: 0x170008C3 RID: 2243
		// (get) Token: 0x06001BEA RID: 7146 RVA: 0x00037198 File Offset: 0x00035398
		// (set) Token: 0x06001BEB RID: 7147 RVA: 0x000371B8 File Offset: 0x000353B8
		[XmlIgnore]
		[Browsable(false)]
		public bool starLevelSpecified
		{
			get
			{
				return this._starLevel != null;
			}
			set
			{
				bool flag = value == (this._starLevel == null);
				if (flag)
				{
					this._starLevel = (value ? new int?(this.starLevel) : null);
				}
			}
		}

		// Token: 0x06001BEC RID: 7148 RVA: 0x000371FC File Offset: 0x000353FC
		private bool ShouldSerializestarLevel()
		{
			return this.starLevelSpecified;
		}

		// Token: 0x06001BED RID: 7149 RVA: 0x00037214 File Offset: 0x00035414
		private void ResetstarLevel()
		{
			this.starLevelSpecified = false;
		}

		// Token: 0x06001BEE RID: 7150 RVA: 0x00037220 File Offset: 0x00035420
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006EE RID: 1774
		private ErrorCode? _error;

		// Token: 0x040006EF RID: 1775
		private readonly List<UnitAppearance> _infos = new List<UnitAppearance>();

		// Token: 0x040006F0 RID: 1776
		private int? _commendNum;

		// Token: 0x040006F1 RID: 1777
		private int? _time;

		// Token: 0x040006F2 RID: 1778
		private int? _starLevel;

		// Token: 0x040006F3 RID: 1779
		private IExtension extensionObject;
	}
}
