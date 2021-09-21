using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000637 RID: 1591
	[ProtoContract(Name = "RoleRiskInfo")]
	[Serializable]
	public class RoleRiskInfo : IExtensible
	{
		// Token: 0x17001ED3 RID: 7891
		// (get) Token: 0x060061E8 RID: 25064 RVA: 0x000BAC7C File Offset: 0x000B8E7C
		// (set) Token: 0x060061E9 RID: 25065 RVA: 0x000BACA8 File Offset: 0x000B8EA8
		[ProtoMember(1, IsRequired = false, Name = "mapID", DataFormat = DataFormat.TwosComplement)]
		public int mapID
		{
			get
			{
				return this._mapID ?? 0;
			}
			set
			{
				this._mapID = new int?(value);
			}
		}

		// Token: 0x17001ED4 RID: 7892
		// (get) Token: 0x060061EA RID: 25066 RVA: 0x000BACB8 File Offset: 0x000B8EB8
		// (set) Token: 0x060061EB RID: 25067 RVA: 0x000BACD8 File Offset: 0x000B8ED8
		[XmlIgnore]
		[Browsable(false)]
		public bool mapIDSpecified
		{
			get
			{
				return this._mapID != null;
			}
			set
			{
				bool flag = value == (this._mapID == null);
				if (flag)
				{
					this._mapID = (value ? new int?(this.mapID) : null);
				}
			}
		}

		// Token: 0x060061EC RID: 25068 RVA: 0x000BAD1C File Offset: 0x000B8F1C
		private bool ShouldSerializemapID()
		{
			return this.mapIDSpecified;
		}

		// Token: 0x060061ED RID: 25069 RVA: 0x000BAD34 File Offset: 0x000B8F34
		private void ResetmapID()
		{
			this.mapIDSpecified = false;
		}

		// Token: 0x17001ED5 RID: 7893
		// (get) Token: 0x060061EE RID: 25070 RVA: 0x000BAD40 File Offset: 0x000B8F40
		// (set) Token: 0x060061EF RID: 25071 RVA: 0x000BAD6C File Offset: 0x000B8F6C
		[ProtoMember(2, IsRequired = false, Name = "gridType", DataFormat = DataFormat.TwosComplement)]
		public int gridType
		{
			get
			{
				return this._gridType ?? 0;
			}
			set
			{
				this._gridType = new int?(value);
			}
		}

		// Token: 0x17001ED6 RID: 7894
		// (get) Token: 0x060061F0 RID: 25072 RVA: 0x000BAD7C File Offset: 0x000B8F7C
		// (set) Token: 0x060061F1 RID: 25073 RVA: 0x000BAD9C File Offset: 0x000B8F9C
		[XmlIgnore]
		[Browsable(false)]
		public bool gridTypeSpecified
		{
			get
			{
				return this._gridType != null;
			}
			set
			{
				bool flag = value == (this._gridType == null);
				if (flag)
				{
					this._gridType = (value ? new int?(this.gridType) : null);
				}
			}
		}

		// Token: 0x060061F2 RID: 25074 RVA: 0x000BADE0 File Offset: 0x000B8FE0
		private bool ShouldSerializegridType()
		{
			return this.gridTypeSpecified;
		}

		// Token: 0x060061F3 RID: 25075 RVA: 0x000BADF8 File Offset: 0x000B8FF8
		private void ResetgridType()
		{
			this.gridTypeSpecified = false;
		}

		// Token: 0x17001ED7 RID: 7895
		// (get) Token: 0x060061F4 RID: 25076 RVA: 0x000BAE04 File Offset: 0x000B9004
		// (set) Token: 0x060061F5 RID: 25077 RVA: 0x000BAE30 File Offset: 0x000B9030
		[ProtoMember(3, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001ED8 RID: 7896
		// (get) Token: 0x060061F6 RID: 25078 RVA: 0x000BAE40 File Offset: 0x000B9040
		// (set) Token: 0x060061F7 RID: 25079 RVA: 0x000BAE60 File Offset: 0x000B9060
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

		// Token: 0x060061F8 RID: 25080 RVA: 0x000BAEA4 File Offset: 0x000B90A4
		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		// Token: 0x060061F9 RID: 25081 RVA: 0x000BAEBC File Offset: 0x000B90BC
		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		// Token: 0x17001ED9 RID: 7897
		// (get) Token: 0x060061FA RID: 25082 RVA: 0x000BAEC8 File Offset: 0x000B90C8
		// (set) Token: 0x060061FB RID: 25083 RVA: 0x000BAEF4 File Offset: 0x000B90F4
		[ProtoMember(4, IsRequired = false, Name = "canBuy", DataFormat = DataFormat.Default)]
		public bool canBuy
		{
			get
			{
				return this._canBuy ?? false;
			}
			set
			{
				this._canBuy = new bool?(value);
			}
		}

		// Token: 0x17001EDA RID: 7898
		// (get) Token: 0x060061FC RID: 25084 RVA: 0x000BAF04 File Offset: 0x000B9104
		// (set) Token: 0x060061FD RID: 25085 RVA: 0x000BAF24 File Offset: 0x000B9124
		[XmlIgnore]
		[Browsable(false)]
		public bool canBuySpecified
		{
			get
			{
				return this._canBuy != null;
			}
			set
			{
				bool flag = value == (this._canBuy == null);
				if (flag)
				{
					this._canBuy = (value ? new bool?(this.canBuy) : null);
				}
			}
		}

		// Token: 0x060061FE RID: 25086 RVA: 0x000BAF68 File Offset: 0x000B9168
		private bool ShouldSerializecanBuy()
		{
			return this.canBuySpecified;
		}

		// Token: 0x060061FF RID: 25087 RVA: 0x000BAF80 File Offset: 0x000B9180
		private void ResetcanBuy()
		{
			this.canBuySpecified = false;
		}

		// Token: 0x06006200 RID: 25088 RVA: 0x000BAF8C File Offset: 0x000B918C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017C3 RID: 6083
		private int? _mapID;

		// Token: 0x040017C4 RID: 6084
		private int? _gridType;

		// Token: 0x040017C5 RID: 6085
		private int? _sceneID;

		// Token: 0x040017C6 RID: 6086
		private bool? _canBuy;

		// Token: 0x040017C7 RID: 6087
		private IExtension extensionObject;
	}
}
