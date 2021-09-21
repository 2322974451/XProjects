using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000476 RID: 1142
	[ProtoContract(Name = "GetMarriageRelationRes")]
	[Serializable]
	public class GetMarriageRelationRes : IExtensible
	{
		// Token: 0x17001240 RID: 4672
		// (get) Token: 0x06003B8B RID: 15243 RVA: 0x00071C68 File Offset: 0x0006FE68
		// (set) Token: 0x06003B8C RID: 15244 RVA: 0x00071C94 File Offset: 0x0006FE94
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

		// Token: 0x17001241 RID: 4673
		// (get) Token: 0x06003B8D RID: 15245 RVA: 0x00071CA4 File Offset: 0x0006FEA4
		// (set) Token: 0x06003B8E RID: 15246 RVA: 0x00071CC4 File Offset: 0x0006FEC4
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

		// Token: 0x06003B8F RID: 15247 RVA: 0x00071D08 File Offset: 0x0006FF08
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06003B90 RID: 15248 RVA: 0x00071D20 File Offset: 0x0006FF20
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17001242 RID: 4674
		// (get) Token: 0x06003B91 RID: 15249 RVA: 0x00071D2C File Offset: 0x0006FF2C
		[ProtoMember(2, Name = "infos", DataFormat = DataFormat.Default)]
		public List<RoleOutLookBrief> infos
		{
			get
			{
				return this._infos;
			}
		}

		// Token: 0x17001243 RID: 4675
		// (get) Token: 0x06003B92 RID: 15250 RVA: 0x00071D44 File Offset: 0x0006FF44
		// (set) Token: 0x06003B93 RID: 15251 RVA: 0x00071D70 File Offset: 0x0006FF70
		[ProtoMember(3, IsRequired = false, Name = "marriageStatus", DataFormat = DataFormat.TwosComplement)]
		public MarriageStatus marriageStatus
		{
			get
			{
				return this._marriageStatus ?? MarriageStatus.MarriageStatus_Null;
			}
			set
			{
				this._marriageStatus = new MarriageStatus?(value);
			}
		}

		// Token: 0x17001244 RID: 4676
		// (get) Token: 0x06003B94 RID: 15252 RVA: 0x00071D80 File Offset: 0x0006FF80
		// (set) Token: 0x06003B95 RID: 15253 RVA: 0x00071DA0 File Offset: 0x0006FFA0
		[XmlIgnore]
		[Browsable(false)]
		public bool marriageStatusSpecified
		{
			get
			{
				return this._marriageStatus != null;
			}
			set
			{
				bool flag = value == (this._marriageStatus == null);
				if (flag)
				{
					this._marriageStatus = (value ? new MarriageStatus?(this.marriageStatus) : null);
				}
			}
		}

		// Token: 0x06003B96 RID: 15254 RVA: 0x00071DE4 File Offset: 0x0006FFE4
		private bool ShouldSerializemarriageStatus()
		{
			return this.marriageStatusSpecified;
		}

		// Token: 0x06003B97 RID: 15255 RVA: 0x00071DFC File Offset: 0x0006FFFC
		private void ResetmarriageStatus()
		{
			this.marriageStatusSpecified = false;
		}

		// Token: 0x17001245 RID: 4677
		// (get) Token: 0x06003B98 RID: 15256 RVA: 0x00071E08 File Offset: 0x00070008
		// (set) Token: 0x06003B99 RID: 15257 RVA: 0x00071E34 File Offset: 0x00070034
		[ProtoMember(4, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeddingType type
		{
			get
			{
				return this._type ?? WeddingType.WeddingType_Normal;
			}
			set
			{
				this._type = new WeddingType?(value);
			}
		}

		// Token: 0x17001246 RID: 4678
		// (get) Token: 0x06003B9A RID: 15258 RVA: 0x00071E44 File Offset: 0x00070044
		// (set) Token: 0x06003B9B RID: 15259 RVA: 0x00071E64 File Offset: 0x00070064
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new WeddingType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003B9C RID: 15260 RVA: 0x00071EA8 File Offset: 0x000700A8
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003B9D RID: 15261 RVA: 0x00071EC0 File Offset: 0x000700C0
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001247 RID: 4679
		// (get) Token: 0x06003B9E RID: 15262 RVA: 0x00071ECC File Offset: 0x000700CC
		// (set) Token: 0x06003B9F RID: 15263 RVA: 0x00071EF8 File Offset: 0x000700F8
		[ProtoMember(5, IsRequired = false, Name = "leftDivorceTime", DataFormat = DataFormat.TwosComplement)]
		public int leftDivorceTime
		{
			get
			{
				return this._leftDivorceTime ?? 0;
			}
			set
			{
				this._leftDivorceTime = new int?(value);
			}
		}

		// Token: 0x17001248 RID: 4680
		// (get) Token: 0x06003BA0 RID: 15264 RVA: 0x00071F08 File Offset: 0x00070108
		// (set) Token: 0x06003BA1 RID: 15265 RVA: 0x00071F28 File Offset: 0x00070128
		[XmlIgnore]
		[Browsable(false)]
		public bool leftDivorceTimeSpecified
		{
			get
			{
				return this._leftDivorceTime != null;
			}
			set
			{
				bool flag = value == (this._leftDivorceTime == null);
				if (flag)
				{
					this._leftDivorceTime = (value ? new int?(this.leftDivorceTime) : null);
				}
			}
		}

		// Token: 0x06003BA2 RID: 15266 RVA: 0x00071F6C File Offset: 0x0007016C
		private bool ShouldSerializeleftDivorceTime()
		{
			return this.leftDivorceTimeSpecified;
		}

		// Token: 0x06003BA3 RID: 15267 RVA: 0x00071F84 File Offset: 0x00070184
		private void ResetleftDivorceTime()
		{
			this.leftDivorceTimeSpecified = false;
		}

		// Token: 0x17001249 RID: 4681
		// (get) Token: 0x06003BA4 RID: 15268 RVA: 0x00071F90 File Offset: 0x00070190
		// (set) Token: 0x06003BA5 RID: 15269 RVA: 0x00071FBD File Offset: 0x000701BD
		[ProtoMember(6, IsRequired = false, Name = "applyDivorceID", DataFormat = DataFormat.TwosComplement)]
		public ulong applyDivorceID
		{
			get
			{
				return this._applyDivorceID ?? 0UL;
			}
			set
			{
				this._applyDivorceID = new ulong?(value);
			}
		}

		// Token: 0x1700124A RID: 4682
		// (get) Token: 0x06003BA6 RID: 15270 RVA: 0x00071FCC File Offset: 0x000701CC
		// (set) Token: 0x06003BA7 RID: 15271 RVA: 0x00071FEC File Offset: 0x000701EC
		[XmlIgnore]
		[Browsable(false)]
		public bool applyDivorceIDSpecified
		{
			get
			{
				return this._applyDivorceID != null;
			}
			set
			{
				bool flag = value == (this._applyDivorceID == null);
				if (flag)
				{
					this._applyDivorceID = (value ? new ulong?(this.applyDivorceID) : null);
				}
			}
		}

		// Token: 0x06003BA8 RID: 15272 RVA: 0x00072030 File Offset: 0x00070230
		private bool ShouldSerializeapplyDivorceID()
		{
			return this.applyDivorceIDSpecified;
		}

		// Token: 0x06003BA9 RID: 15273 RVA: 0x00072048 File Offset: 0x00070248
		private void ResetapplyDivorceID()
		{
			this.applyDivorceIDSpecified = false;
		}

		// Token: 0x1700124B RID: 4683
		// (get) Token: 0x06003BAA RID: 15274 RVA: 0x00072054 File Offset: 0x00070254
		// (set) Token: 0x06003BAB RID: 15275 RVA: 0x00072080 File Offset: 0x00070280
		[ProtoMember(7, IsRequired = false, Name = "coupleOfflineTime", DataFormat = DataFormat.TwosComplement)]
		public int coupleOfflineTime
		{
			get
			{
				return this._coupleOfflineTime ?? 0;
			}
			set
			{
				this._coupleOfflineTime = new int?(value);
			}
		}

		// Token: 0x1700124C RID: 4684
		// (get) Token: 0x06003BAC RID: 15276 RVA: 0x00072090 File Offset: 0x00070290
		// (set) Token: 0x06003BAD RID: 15277 RVA: 0x000720B0 File Offset: 0x000702B0
		[XmlIgnore]
		[Browsable(false)]
		public bool coupleOfflineTimeSpecified
		{
			get
			{
				return this._coupleOfflineTime != null;
			}
			set
			{
				bool flag = value == (this._coupleOfflineTime == null);
				if (flag)
				{
					this._coupleOfflineTime = (value ? new int?(this.coupleOfflineTime) : null);
				}
			}
		}

		// Token: 0x06003BAE RID: 15278 RVA: 0x000720F4 File Offset: 0x000702F4
		private bool ShouldSerializecoupleOfflineTime()
		{
			return this.coupleOfflineTimeSpecified;
		}

		// Token: 0x06003BAF RID: 15279 RVA: 0x0007210C File Offset: 0x0007030C
		private void ResetcoupleOfflineTime()
		{
			this.coupleOfflineTimeSpecified = false;
		}

		// Token: 0x1700124D RID: 4685
		// (get) Token: 0x06003BB0 RID: 15280 RVA: 0x00072118 File Offset: 0x00070318
		// (set) Token: 0x06003BB1 RID: 15281 RVA: 0x00072130 File Offset: 0x00070330
		[ProtoMember(8, IsRequired = false, Name = "marriageLevel", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MarriageLevelInfo marriageLevel
		{
			get
			{
				return this._marriageLevel;
			}
			set
			{
				this._marriageLevel = value;
			}
		}

		// Token: 0x06003BB2 RID: 15282 RVA: 0x0007213C File Offset: 0x0007033C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000ED2 RID: 3794
		private ErrorCode? _error;

		// Token: 0x04000ED3 RID: 3795
		private readonly List<RoleOutLookBrief> _infos = new List<RoleOutLookBrief>();

		// Token: 0x04000ED4 RID: 3796
		private MarriageStatus? _marriageStatus;

		// Token: 0x04000ED5 RID: 3797
		private WeddingType? _type;

		// Token: 0x04000ED6 RID: 3798
		private int? _leftDivorceTime;

		// Token: 0x04000ED7 RID: 3799
		private ulong? _applyDivorceID;

		// Token: 0x04000ED8 RID: 3800
		private int? _coupleOfflineTime;

		// Token: 0x04000ED9 RID: 3801
		private MarriageLevelInfo _marriageLevel = null;

		// Token: 0x04000EDA RID: 3802
		private IExtension extensionObject;
	}
}
