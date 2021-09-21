using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200073E RID: 1854
	[ProtoContract(Name = "RiftGuildRankInfo")]
	[Serializable]
	public class RiftGuildRankInfo : IExtensible
	{
		// Token: 0x170028CD RID: 10445
		// (get) Token: 0x060080B1 RID: 32945 RVA: 0x000F6190 File Offset: 0x000F4390
		// (set) Token: 0x060080B2 RID: 32946 RVA: 0x000F61A8 File Offset: 0x000F43A8
		[ProtoMember(1, IsRequired = false, Name = "roleInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleBriefInfo roleInfo
		{
			get
			{
				return this._roleInfo;
			}
			set
			{
				this._roleInfo = value;
			}
		}

		// Token: 0x170028CE RID: 10446
		// (get) Token: 0x060080B3 RID: 32947 RVA: 0x000F61B4 File Offset: 0x000F43B4
		// (set) Token: 0x060080B4 RID: 32948 RVA: 0x000F61E0 File Offset: 0x000F43E0
		[ProtoMember(2, IsRequired = false, Name = "riftFloor", DataFormat = DataFormat.TwosComplement)]
		public int riftFloor
		{
			get
			{
				return this._riftFloor ?? 0;
			}
			set
			{
				this._riftFloor = new int?(value);
			}
		}

		// Token: 0x170028CF RID: 10447
		// (get) Token: 0x060080B5 RID: 32949 RVA: 0x000F61F0 File Offset: 0x000F43F0
		// (set) Token: 0x060080B6 RID: 32950 RVA: 0x000F6210 File Offset: 0x000F4410
		[XmlIgnore]
		[Browsable(false)]
		public bool riftFloorSpecified
		{
			get
			{
				return this._riftFloor != null;
			}
			set
			{
				bool flag = value == (this._riftFloor == null);
				if (flag)
				{
					this._riftFloor = (value ? new int?(this.riftFloor) : null);
				}
			}
		}

		// Token: 0x060080B7 RID: 32951 RVA: 0x000F6254 File Offset: 0x000F4454
		private bool ShouldSerializeriftFloor()
		{
			return this.riftFloorSpecified;
		}

		// Token: 0x060080B8 RID: 32952 RVA: 0x000F626C File Offset: 0x000F446C
		private void ResetriftFloor()
		{
			this.riftFloorSpecified = false;
		}

		// Token: 0x170028D0 RID: 10448
		// (get) Token: 0x060080B9 RID: 32953 RVA: 0x000F6278 File Offset: 0x000F4478
		// (set) Token: 0x060080BA RID: 32954 RVA: 0x000F62A4 File Offset: 0x000F44A4
		[ProtoMember(3, IsRequired = false, Name = "riftStar", DataFormat = DataFormat.TwosComplement)]
		public int riftStar
		{
			get
			{
				return this._riftStar ?? 0;
			}
			set
			{
				this._riftStar = new int?(value);
			}
		}

		// Token: 0x170028D1 RID: 10449
		// (get) Token: 0x060080BB RID: 32955 RVA: 0x000F62B4 File Offset: 0x000F44B4
		// (set) Token: 0x060080BC RID: 32956 RVA: 0x000F62D4 File Offset: 0x000F44D4
		[XmlIgnore]
		[Browsable(false)]
		public bool riftStarSpecified
		{
			get
			{
				return this._riftStar != null;
			}
			set
			{
				bool flag = value == (this._riftStar == null);
				if (flag)
				{
					this._riftStar = (value ? new int?(this.riftStar) : null);
				}
			}
		}

		// Token: 0x060080BD RID: 32957 RVA: 0x000F6318 File Offset: 0x000F4518
		private bool ShouldSerializeriftStar()
		{
			return this.riftStarSpecified;
		}

		// Token: 0x060080BE RID: 32958 RVA: 0x000F6330 File Offset: 0x000F4530
		private void ResetriftStar()
		{
			this.riftStarSpecified = false;
		}

		// Token: 0x170028D2 RID: 10450
		// (get) Token: 0x060080BF RID: 32959 RVA: 0x000F633C File Offset: 0x000F453C
		// (set) Token: 0x060080C0 RID: 32960 RVA: 0x000F6368 File Offset: 0x000F4568
		[ProtoMember(4, IsRequired = false, Name = "costTime", DataFormat = DataFormat.TwosComplement)]
		public int costTime
		{
			get
			{
				return this._costTime ?? 0;
			}
			set
			{
				this._costTime = new int?(value);
			}
		}

		// Token: 0x170028D3 RID: 10451
		// (get) Token: 0x060080C1 RID: 32961 RVA: 0x000F6378 File Offset: 0x000F4578
		// (set) Token: 0x060080C2 RID: 32962 RVA: 0x000F6398 File Offset: 0x000F4598
		[XmlIgnore]
		[Browsable(false)]
		public bool costTimeSpecified
		{
			get
			{
				return this._costTime != null;
			}
			set
			{
				bool flag = value == (this._costTime == null);
				if (flag)
				{
					this._costTime = (value ? new int?(this.costTime) : null);
				}
			}
		}

		// Token: 0x060080C3 RID: 32963 RVA: 0x000F63DC File Offset: 0x000F45DC
		private bool ShouldSerializecostTime()
		{
			return this.costTimeSpecified;
		}

		// Token: 0x060080C4 RID: 32964 RVA: 0x000F63F4 File Offset: 0x000F45F4
		private void ResetcostTime()
		{
			this.costTimeSpecified = false;
		}

		// Token: 0x170028D4 RID: 10452
		// (get) Token: 0x060080C5 RID: 32965 RVA: 0x000F6400 File Offset: 0x000F4600
		// (set) Token: 0x060080C6 RID: 32966 RVA: 0x000F642C File Offset: 0x000F462C
		[ProtoMember(5, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public int sceneID
		{
			get
			{
				return this._sceneID ?? 0;
			}
			set
			{
				this._sceneID = new int?(value);
			}
		}

		// Token: 0x170028D5 RID: 10453
		// (get) Token: 0x060080C7 RID: 32967 RVA: 0x000F643C File Offset: 0x000F463C
		// (set) Token: 0x060080C8 RID: 32968 RVA: 0x000F645C File Offset: 0x000F465C
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new int?(this.sceneID) : null);
				}
			}
		}

		// Token: 0x060080C9 RID: 32969 RVA: 0x000F64A0 File Offset: 0x000F46A0
		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		// Token: 0x060080CA RID: 32970 RVA: 0x000F64B8 File Offset: 0x000F46B8
		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		// Token: 0x060080CB RID: 32971 RVA: 0x000F64C4 File Offset: 0x000F46C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E26 RID: 7718
		private RoleBriefInfo _roleInfo = null;

		// Token: 0x04001E27 RID: 7719
		private int? _riftFloor;

		// Token: 0x04001E28 RID: 7720
		private int? _riftStar;

		// Token: 0x04001E29 RID: 7721
		private int? _costTime;

		// Token: 0x04001E2A RID: 7722
		private int? _sceneID;

		// Token: 0x04001E2B RID: 7723
		private IExtension extensionObject;
	}
}
