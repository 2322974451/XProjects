using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200051E RID: 1310
	[ProtoContract(Name = "BackFlowActivityOperationRes")]
	[Serializable]
	public class BackFlowActivityOperationRes : IExtensible
	{
		// Token: 0x1700148F RID: 5263
		// (get) Token: 0x06004349 RID: 17225 RVA: 0x0008001C File Offset: 0x0007E21C
		// (set) Token: 0x0600434A RID: 17226 RVA: 0x00080048 File Offset: 0x0007E248
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

		// Token: 0x17001490 RID: 5264
		// (get) Token: 0x0600434B RID: 17227 RVA: 0x00080058 File Offset: 0x0007E258
		// (set) Token: 0x0600434C RID: 17228 RVA: 0x00080078 File Offset: 0x0007E278
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

		// Token: 0x0600434D RID: 17229 RVA: 0x000800BC File Offset: 0x0007E2BC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600434E RID: 17230 RVA: 0x000800D4 File Offset: 0x0007E2D4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17001491 RID: 5265
		// (get) Token: 0x0600434F RID: 17231 RVA: 0x000800E0 File Offset: 0x0007E2E0
		// (set) Token: 0x06004350 RID: 17232 RVA: 0x0008010C File Offset: 0x0007E30C
		[ProtoMember(2, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x17001492 RID: 5266
		// (get) Token: 0x06004351 RID: 17233 RVA: 0x0008011C File Offset: 0x0007E31C
		// (set) Token: 0x06004352 RID: 17234 RVA: 0x0008013C File Offset: 0x0007E33C
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x06004353 RID: 17235 RVA: 0x00080180 File Offset: 0x0007E380
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06004354 RID: 17236 RVA: 0x00080198 File Offset: 0x0007E398
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x17001493 RID: 5267
		// (get) Token: 0x06004355 RID: 17237 RVA: 0x000801A4 File Offset: 0x0007E3A4
		[ProtoMember(3, Name = "alreadyGet", DataFormat = DataFormat.TwosComplement)]
		public List<uint> alreadyGet
		{
			get
			{
				return this._alreadyGet;
			}
		}

		// Token: 0x17001494 RID: 5268
		// (get) Token: 0x06004356 RID: 17238 RVA: 0x000801BC File Offset: 0x0007E3BC
		// (set) Token: 0x06004357 RID: 17239 RVA: 0x000801D4 File Offset: 0x0007E3D4
		[ProtoMember(4, IsRequired = false, Name = "shop", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BackFlowShopData shop
		{
			get
			{
				return this._shop;
			}
			set
			{
				this._shop = value;
			}
		}

		// Token: 0x17001495 RID: 5269
		// (get) Token: 0x06004358 RID: 17240 RVA: 0x000801E0 File Offset: 0x0007E3E0
		// (set) Token: 0x06004359 RID: 17241 RVA: 0x0008020C File Offset: 0x0007E40C
		[ProtoMember(5, IsRequired = false, Name = "shopLeftTime", DataFormat = DataFormat.TwosComplement)]
		public uint shopLeftTime
		{
			get
			{
				return this._shopLeftTime ?? 0U;
			}
			set
			{
				this._shopLeftTime = new uint?(value);
			}
		}

		// Token: 0x17001496 RID: 5270
		// (get) Token: 0x0600435A RID: 17242 RVA: 0x0008021C File Offset: 0x0007E41C
		// (set) Token: 0x0600435B RID: 17243 RVA: 0x0008023C File Offset: 0x0007E43C
		[XmlIgnore]
		[Browsable(false)]
		public bool shopLeftTimeSpecified
		{
			get
			{
				return this._shopLeftTime != null;
			}
			set
			{
				bool flag = value == (this._shopLeftTime == null);
				if (flag)
				{
					this._shopLeftTime = (value ? new uint?(this.shopLeftTime) : null);
				}
			}
		}

		// Token: 0x0600435C RID: 17244 RVA: 0x00080280 File Offset: 0x0007E480
		private bool ShouldSerializeshopLeftTime()
		{
			return this.shopLeftTimeSpecified;
		}

		// Token: 0x0600435D RID: 17245 RVA: 0x00080298 File Offset: 0x0007E498
		private void ResetshopLeftTime()
		{
			this.shopLeftTimeSpecified = false;
		}

		// Token: 0x17001497 RID: 5271
		// (get) Token: 0x0600435E RID: 17246 RVA: 0x000802A4 File Offset: 0x0007E4A4
		// (set) Token: 0x0600435F RID: 17247 RVA: 0x000802D0 File Offset: 0x0007E4D0
		[ProtoMember(6, IsRequired = false, Name = "activityLeftTime", DataFormat = DataFormat.TwosComplement)]
		public uint activityLeftTime
		{
			get
			{
				return this._activityLeftTime ?? 0U;
			}
			set
			{
				this._activityLeftTime = new uint?(value);
			}
		}

		// Token: 0x17001498 RID: 5272
		// (get) Token: 0x06004360 RID: 17248 RVA: 0x000802E0 File Offset: 0x0007E4E0
		// (set) Token: 0x06004361 RID: 17249 RVA: 0x00080300 File Offset: 0x0007E500
		[XmlIgnore]
		[Browsable(false)]
		public bool activityLeftTimeSpecified
		{
			get
			{
				return this._activityLeftTime != null;
			}
			set
			{
				bool flag = value == (this._activityLeftTime == null);
				if (flag)
				{
					this._activityLeftTime = (value ? new uint?(this.activityLeftTime) : null);
				}
			}
		}

		// Token: 0x06004362 RID: 17250 RVA: 0x00080344 File Offset: 0x0007E544
		private bool ShouldSerializeactivityLeftTime()
		{
			return this.activityLeftTimeSpecified;
		}

		// Token: 0x06004363 RID: 17251 RVA: 0x0008035C File Offset: 0x0007E55C
		private void ResetactivityLeftTime()
		{
			this.activityLeftTimeSpecified = false;
		}

		// Token: 0x17001499 RID: 5273
		// (get) Token: 0x06004364 RID: 17252 RVA: 0x00080368 File Offset: 0x0007E568
		// (set) Token: 0x06004365 RID: 17253 RVA: 0x00080394 File Offset: 0x0007E594
		[ProtoMember(7, IsRequired = false, Name = "leftSmallDragonCount", DataFormat = DataFormat.TwosComplement)]
		public uint leftSmallDragonCount
		{
			get
			{
				return this._leftSmallDragonCount ?? 0U;
			}
			set
			{
				this._leftSmallDragonCount = new uint?(value);
			}
		}

		// Token: 0x1700149A RID: 5274
		// (get) Token: 0x06004366 RID: 17254 RVA: 0x000803A4 File Offset: 0x0007E5A4
		// (set) Token: 0x06004367 RID: 17255 RVA: 0x000803C4 File Offset: 0x0007E5C4
		[XmlIgnore]
		[Browsable(false)]
		public bool leftSmallDragonCountSpecified
		{
			get
			{
				return this._leftSmallDragonCount != null;
			}
			set
			{
				bool flag = value == (this._leftSmallDragonCount == null);
				if (flag)
				{
					this._leftSmallDragonCount = (value ? new uint?(this.leftSmallDragonCount) : null);
				}
			}
		}

		// Token: 0x06004368 RID: 17256 RVA: 0x00080408 File Offset: 0x0007E608
		private bool ShouldSerializeleftSmallDragonCount()
		{
			return this.leftSmallDragonCountSpecified;
		}

		// Token: 0x06004369 RID: 17257 RVA: 0x00080420 File Offset: 0x0007E620
		private void ResetleftSmallDragonCount()
		{
			this.leftSmallDragonCountSpecified = false;
		}

		// Token: 0x1700149B RID: 5275
		// (get) Token: 0x0600436A RID: 17258 RVA: 0x0008042C File Offset: 0x0007E62C
		// (set) Token: 0x0600436B RID: 17259 RVA: 0x00080458 File Offset: 0x0007E658
		[ProtoMember(8, IsRequired = false, Name = "leftNestCount", DataFormat = DataFormat.TwosComplement)]
		public uint leftNestCount
		{
			get
			{
				return this._leftNestCount ?? 0U;
			}
			set
			{
				this._leftNestCount = new uint?(value);
			}
		}

		// Token: 0x1700149C RID: 5276
		// (get) Token: 0x0600436C RID: 17260 RVA: 0x00080468 File Offset: 0x0007E668
		// (set) Token: 0x0600436D RID: 17261 RVA: 0x00080488 File Offset: 0x0007E688
		[XmlIgnore]
		[Browsable(false)]
		public bool leftNestCountSpecified
		{
			get
			{
				return this._leftNestCount != null;
			}
			set
			{
				bool flag = value == (this._leftNestCount == null);
				if (flag)
				{
					this._leftNestCount = (value ? new uint?(this.leftNestCount) : null);
				}
			}
		}

		// Token: 0x0600436E RID: 17262 RVA: 0x000804CC File Offset: 0x0007E6CC
		private bool ShouldSerializeleftNestCount()
		{
			return this.leftNestCountSpecified;
		}

		// Token: 0x0600436F RID: 17263 RVA: 0x000804E4 File Offset: 0x0007E6E4
		private void ResetleftNestCount()
		{
			this.leftNestCountSpecified = false;
		}

		// Token: 0x06004370 RID: 17264 RVA: 0x000804F0 File Offset: 0x0007E6F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010C6 RID: 4294
		private ErrorCode? _errorcode;

		// Token: 0x040010C7 RID: 4295
		private uint? _point;

		// Token: 0x040010C8 RID: 4296
		private readonly List<uint> _alreadyGet = new List<uint>();

		// Token: 0x040010C9 RID: 4297
		private BackFlowShopData _shop = null;

		// Token: 0x040010CA RID: 4298
		private uint? _shopLeftTime;

		// Token: 0x040010CB RID: 4299
		private uint? _activityLeftTime;

		// Token: 0x040010CC RID: 4300
		private uint? _leftSmallDragonCount;

		// Token: 0x040010CD RID: 4301
		private uint? _leftNestCount;

		// Token: 0x040010CE RID: 4302
		private IExtension extensionObject;
	}
}
