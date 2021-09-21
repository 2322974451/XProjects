using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003CA RID: 970
	[ProtoContract(Name = "ArgentaActivityRes")]
	[Serializable]
	public class ArgentaActivityRes : IExtensible
	{
		// Token: 0x17000FE8 RID: 4072
		// (get) Token: 0x060033A8 RID: 13224 RVA: 0x0006329C File Offset: 0x0006149C
		// (set) Token: 0x060033A9 RID: 13225 RVA: 0x000632C8 File Offset: 0x000614C8
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

		// Token: 0x17000FE9 RID: 4073
		// (get) Token: 0x060033AA RID: 13226 RVA: 0x000632D8 File Offset: 0x000614D8
		// (set) Token: 0x060033AB RID: 13227 RVA: 0x000632F8 File Offset: 0x000614F8
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

		// Token: 0x060033AC RID: 13228 RVA: 0x0006333C File Offset: 0x0006153C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060033AD RID: 13229 RVA: 0x00063354 File Offset: 0x00061554
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000FEA RID: 4074
		// (get) Token: 0x060033AE RID: 13230 RVA: 0x00063360 File Offset: 0x00061560
		// (set) Token: 0x060033AF RID: 13231 RVA: 0x0006338C File Offset: 0x0006158C
		[ProtoMember(2, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public uint leftTime
		{
			get
			{
				return this._leftTime ?? 0U;
			}
			set
			{
				this._leftTime = new uint?(value);
			}
		}

		// Token: 0x17000FEB RID: 4075
		// (get) Token: 0x060033B0 RID: 13232 RVA: 0x0006339C File Offset: 0x0006159C
		// (set) Token: 0x060033B1 RID: 13233 RVA: 0x000633BC File Offset: 0x000615BC
		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new uint?(this.leftTime) : null);
				}
			}
		}

		// Token: 0x060033B2 RID: 13234 RVA: 0x00063400 File Offset: 0x00061600
		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		// Token: 0x060033B3 RID: 13235 RVA: 0x00063418 File Offset: 0x00061618
		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		// Token: 0x17000FEC RID: 4076
		// (get) Token: 0x060033B4 RID: 13236 RVA: 0x00063424 File Offset: 0x00061624
		// (set) Token: 0x060033B5 RID: 13237 RVA: 0x00063450 File Offset: 0x00061650
		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x17000FED RID: 4077
		// (get) Token: 0x060033B6 RID: 13238 RVA: 0x00063460 File Offset: 0x00061660
		// (set) Token: 0x060033B7 RID: 13239 RVA: 0x00063480 File Offset: 0x00061680
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x060033B8 RID: 13240 RVA: 0x000634C4 File Offset: 0x000616C4
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x060033B9 RID: 13241 RVA: 0x000634DC File Offset: 0x000616DC
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17000FEE RID: 4078
		// (get) Token: 0x060033BA RID: 13242 RVA: 0x000634E8 File Offset: 0x000616E8
		[ProtoMember(4, Name = "getRewardIDs", DataFormat = DataFormat.TwosComplement)]
		public List<uint> getRewardIDs
		{
			get
			{
				return this._getRewardIDs;
			}
		}

		// Token: 0x060033BB RID: 13243 RVA: 0x00063500 File Offset: 0x00061700
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CD7 RID: 3287
		private ErrorCode? _errorcode;

		// Token: 0x04000CD8 RID: 3288
		private uint? _leftTime;

		// Token: 0x04000CD9 RID: 3289
		private uint? _level;

		// Token: 0x04000CDA RID: 3290
		private readonly List<uint> _getRewardIDs = new List<uint>();

		// Token: 0x04000CDB RID: 3291
		private IExtension extensionObject;
	}
}
