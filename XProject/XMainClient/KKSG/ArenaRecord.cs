using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005F8 RID: 1528
	[ProtoContract(Name = "ArenaRecord")]
	[Serializable]
	public class ArenaRecord : IExtensible
	{
		// Token: 0x17001C6D RID: 7277
		// (get) Token: 0x06005AEE RID: 23278 RVA: 0x000AD244 File Offset: 0x000AB444
		// (set) Token: 0x06005AEF RID: 23279 RVA: 0x000AD270 File Offset: 0x000AB470
		[ProtoMember(1, IsRequired = false, Name = "OptimalRank", DataFormat = DataFormat.TwosComplement)]
		public uint OptimalRank
		{
			get
			{
				return this._OptimalRank ?? 0U;
			}
			set
			{
				this._OptimalRank = new uint?(value);
			}
		}

		// Token: 0x17001C6E RID: 7278
		// (get) Token: 0x06005AF0 RID: 23280 RVA: 0x000AD280 File Offset: 0x000AB480
		// (set) Token: 0x06005AF1 RID: 23281 RVA: 0x000AD2A0 File Offset: 0x000AB4A0
		[XmlIgnore]
		[Browsable(false)]
		public bool OptimalRankSpecified
		{
			get
			{
				return this._OptimalRank != null;
			}
			set
			{
				bool flag = value == (this._OptimalRank == null);
				if (flag)
				{
					this._OptimalRank = (value ? new uint?(this.OptimalRank) : null);
				}
			}
		}

		// Token: 0x06005AF2 RID: 23282 RVA: 0x000AD2E4 File Offset: 0x000AB4E4
		private bool ShouldSerializeOptimalRank()
		{
			return this.OptimalRankSpecified;
		}

		// Token: 0x06005AF3 RID: 23283 RVA: 0x000AD2FC File Offset: 0x000AB4FC
		private void ResetOptimalRank()
		{
			this.OptimalRankSpecified = false;
		}

		// Token: 0x17001C6F RID: 7279
		// (get) Token: 0x06005AF4 RID: 23284 RVA: 0x000AD308 File Offset: 0x000AB508
		// (set) Token: 0x06005AF5 RID: 23285 RVA: 0x000AD334 File Offset: 0x000AB534
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

		// Token: 0x17001C70 RID: 7280
		// (get) Token: 0x06005AF6 RID: 23286 RVA: 0x000AD344 File Offset: 0x000AB544
		// (set) Token: 0x06005AF7 RID: 23287 RVA: 0x000AD364 File Offset: 0x000AB564
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

		// Token: 0x06005AF8 RID: 23288 RVA: 0x000AD3A8 File Offset: 0x000AB5A8
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06005AF9 RID: 23289 RVA: 0x000AD3C0 File Offset: 0x000AB5C0
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x17001C71 RID: 7281
		// (get) Token: 0x06005AFA RID: 23290 RVA: 0x000AD3CC File Offset: 0x000AB5CC
		// (set) Token: 0x06005AFB RID: 23291 RVA: 0x000AD3F8 File Offset: 0x000AB5F8
		[ProtoMember(3, IsRequired = false, Name = "dayupdate", DataFormat = DataFormat.TwosComplement)]
		public uint dayupdate
		{
			get
			{
				return this._dayupdate ?? 0U;
			}
			set
			{
				this._dayupdate = new uint?(value);
			}
		}

		// Token: 0x17001C72 RID: 7282
		// (get) Token: 0x06005AFC RID: 23292 RVA: 0x000AD408 File Offset: 0x000AB608
		// (set) Token: 0x06005AFD RID: 23293 RVA: 0x000AD428 File Offset: 0x000AB628
		[XmlIgnore]
		[Browsable(false)]
		public bool dayupdateSpecified
		{
			get
			{
				return this._dayupdate != null;
			}
			set
			{
				bool flag = value == (this._dayupdate == null);
				if (flag)
				{
					this._dayupdate = (value ? new uint?(this.dayupdate) : null);
				}
			}
		}

		// Token: 0x06005AFE RID: 23294 RVA: 0x000AD46C File Offset: 0x000AB66C
		private bool ShouldSerializedayupdate()
		{
			return this.dayupdateSpecified;
		}

		// Token: 0x06005AFF RID: 23295 RVA: 0x000AD484 File Offset: 0x000AB684
		private void Resetdayupdate()
		{
			this.dayupdateSpecified = false;
		}

		// Token: 0x17001C73 RID: 7283
		// (get) Token: 0x06005B00 RID: 23296 RVA: 0x000AD490 File Offset: 0x000AB690
		[ProtoMember(4, Name = "pointreward", DataFormat = DataFormat.TwosComplement)]
		public List<uint> pointreward
		{
			get
			{
				return this._pointreward;
			}
		}

		// Token: 0x17001C74 RID: 7284
		// (get) Token: 0x06005B01 RID: 23297 RVA: 0x000AD4A8 File Offset: 0x000AB6A8
		[ProtoMember(5, Name = "rankreward", DataFormat = DataFormat.TwosComplement)]
		public List<uint> rankreward
		{
			get
			{
				return this._rankreward;
			}
		}

		// Token: 0x06005B02 RID: 23298 RVA: 0x000AD4C0 File Offset: 0x000AB6C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400161E RID: 5662
		private uint? _OptimalRank;

		// Token: 0x0400161F RID: 5663
		private uint? _point;

		// Token: 0x04001620 RID: 5664
		private uint? _dayupdate;

		// Token: 0x04001621 RID: 5665
		private readonly List<uint> _pointreward = new List<uint>();

		// Token: 0x04001622 RID: 5666
		private readonly List<uint> _rankreward = new List<uint>();

		// Token: 0x04001623 RID: 5667
		private IExtension extensionObject;
	}
}
