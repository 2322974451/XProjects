using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003D5 RID: 981
	[ProtoContract(Name = "ArenaStarReqRes")]
	[Serializable]
	public class ArenaStarReqRes : IExtensible
	{
		// Token: 0x17001012 RID: 4114
		// (get) Token: 0x06003438 RID: 13368 RVA: 0x000642DC File Offset: 0x000624DC
		// (set) Token: 0x06003439 RID: 13369 RVA: 0x00064308 File Offset: 0x00062508
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17001013 RID: 4115
		// (get) Token: 0x0600343A RID: 13370 RVA: 0x00064318 File Offset: 0x00062518
		// (set) Token: 0x0600343B RID: 13371 RVA: 0x00064338 File Offset: 0x00062538
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x0600343C RID: 13372 RVA: 0x0006437C File Offset: 0x0006257C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600343D RID: 13373 RVA: 0x00064394 File Offset: 0x00062594
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17001014 RID: 4116
		// (get) Token: 0x0600343E RID: 13374 RVA: 0x000643A0 File Offset: 0x000625A0
		[ProtoMember(2, Name = "toproledata", DataFormat = DataFormat.Default)]
		public List<ArenaStarTopRoleData> toproledata
		{
			get
			{
				return this._toproledata;
			}
		}

		// Token: 0x17001015 RID: 4117
		// (get) Token: 0x0600343F RID: 13375 RVA: 0x000643B8 File Offset: 0x000625B8
		// (set) Token: 0x06003440 RID: 13376 RVA: 0x000643E4 File Offset: 0x000625E4
		[ProtoMember(3, IsRequired = false, Name = "seasonbegintime", DataFormat = DataFormat.TwosComplement)]
		public uint seasonbegintime
		{
			get
			{
				return this._seasonbegintime ?? 0U;
			}
			set
			{
				this._seasonbegintime = new uint?(value);
			}
		}

		// Token: 0x17001016 RID: 4118
		// (get) Token: 0x06003441 RID: 13377 RVA: 0x000643F4 File Offset: 0x000625F4
		// (set) Token: 0x06003442 RID: 13378 RVA: 0x00064414 File Offset: 0x00062614
		[XmlIgnore]
		[Browsable(false)]
		public bool seasonbegintimeSpecified
		{
			get
			{
				return this._seasonbegintime != null;
			}
			set
			{
				bool flag = value == (this._seasonbegintime == null);
				if (flag)
				{
					this._seasonbegintime = (value ? new uint?(this.seasonbegintime) : null);
				}
			}
		}

		// Token: 0x06003443 RID: 13379 RVA: 0x00064458 File Offset: 0x00062658
		private bool ShouldSerializeseasonbegintime()
		{
			return this.seasonbegintimeSpecified;
		}

		// Token: 0x06003444 RID: 13380 RVA: 0x00064470 File Offset: 0x00062670
		private void Resetseasonbegintime()
		{
			this.seasonbegintimeSpecified = false;
		}

		// Token: 0x17001017 RID: 4119
		// (get) Token: 0x06003445 RID: 13381 RVA: 0x0006447C File Offset: 0x0006267C
		// (set) Token: 0x06003446 RID: 13382 RVA: 0x000644A8 File Offset: 0x000626A8
		[ProtoMember(4, IsRequired = false, Name = "seasonendtime", DataFormat = DataFormat.TwosComplement)]
		public uint seasonendtime
		{
			get
			{
				return this._seasonendtime ?? 0U;
			}
			set
			{
				this._seasonendtime = new uint?(value);
			}
		}

		// Token: 0x17001018 RID: 4120
		// (get) Token: 0x06003447 RID: 13383 RVA: 0x000644B8 File Offset: 0x000626B8
		// (set) Token: 0x06003448 RID: 13384 RVA: 0x000644D8 File Offset: 0x000626D8
		[XmlIgnore]
		[Browsable(false)]
		public bool seasonendtimeSpecified
		{
			get
			{
				return this._seasonendtime != null;
			}
			set
			{
				bool flag = value == (this._seasonendtime == null);
				if (flag)
				{
					this._seasonendtime = (value ? new uint?(this.seasonendtime) : null);
				}
			}
		}

		// Token: 0x06003449 RID: 13385 RVA: 0x0006451C File Offset: 0x0006271C
		private bool ShouldSerializeseasonendtime()
		{
			return this.seasonendtimeSpecified;
		}

		// Token: 0x0600344A RID: 13386 RVA: 0x00064534 File Offset: 0x00062734
		private void Resetseasonendtime()
		{
			this.seasonendtimeSpecified = false;
		}

		// Token: 0x17001019 RID: 4121
		// (get) Token: 0x0600344B RID: 13387 RVA: 0x00064540 File Offset: 0x00062740
		// (set) Token: 0x0600344C RID: 13388 RVA: 0x0006456C File Offset: 0x0006276C
		[ProtoMember(5, IsRequired = false, Name = "season_num", DataFormat = DataFormat.TwosComplement)]
		public uint season_num
		{
			get
			{
				return this._season_num ?? 0U;
			}
			set
			{
				this._season_num = new uint?(value);
			}
		}

		// Token: 0x1700101A RID: 4122
		// (get) Token: 0x0600344D RID: 13389 RVA: 0x0006457C File Offset: 0x0006277C
		// (set) Token: 0x0600344E RID: 13390 RVA: 0x0006459C File Offset: 0x0006279C
		[XmlIgnore]
		[Browsable(false)]
		public bool season_numSpecified
		{
			get
			{
				return this._season_num != null;
			}
			set
			{
				bool flag = value == (this._season_num == null);
				if (flag)
				{
					this._season_num = (value ? new uint?(this.season_num) : null);
				}
			}
		}

		// Token: 0x0600344F RID: 13391 RVA: 0x000645E0 File Offset: 0x000627E0
		private bool ShouldSerializeseason_num()
		{
			return this.season_numSpecified;
		}

		// Token: 0x06003450 RID: 13392 RVA: 0x000645F8 File Offset: 0x000627F8
		private void Resetseason_num()
		{
			this.season_numSpecified = false;
		}

		// Token: 0x06003451 RID: 13393 RVA: 0x00064604 File Offset: 0x00062804
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CF8 RID: 3320
		private ErrorCode? _errorcode;

		// Token: 0x04000CF9 RID: 3321
		private readonly List<ArenaStarTopRoleData> _toproledata = new List<ArenaStarTopRoleData>();

		// Token: 0x04000CFA RID: 3322
		private uint? _seasonbegintime;

		// Token: 0x04000CFB RID: 3323
		private uint? _seasonendtime;

		// Token: 0x04000CFC RID: 3324
		private uint? _season_num;

		// Token: 0x04000CFD RID: 3325
		private IExtension extensionObject;
	}
}
