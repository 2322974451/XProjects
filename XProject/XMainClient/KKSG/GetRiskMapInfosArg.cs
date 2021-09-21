using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200020A RID: 522
	[ProtoContract(Name = "GetRiskMapInfosArg")]
	[Serializable]
	public class GetRiskMapInfosArg : IExtensible
	{
		// Token: 0x1700093A RID: 2362
		// (get) Token: 0x06001D73 RID: 7539 RVA: 0x00039EFC File Offset: 0x000380FC
		// (set) Token: 0x06001D74 RID: 7540 RVA: 0x00039F28 File Offset: 0x00038128
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

		// Token: 0x1700093B RID: 2363
		// (get) Token: 0x06001D75 RID: 7541 RVA: 0x00039F38 File Offset: 0x00038138
		// (set) Token: 0x06001D76 RID: 7542 RVA: 0x00039F58 File Offset: 0x00038158
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

		// Token: 0x06001D77 RID: 7543 RVA: 0x00039F9C File Offset: 0x0003819C
		private bool ShouldSerializemapID()
		{
			return this.mapIDSpecified;
		}

		// Token: 0x06001D78 RID: 7544 RVA: 0x00039FB4 File Offset: 0x000381B4
		private void ResetmapID()
		{
			this.mapIDSpecified = false;
		}

		// Token: 0x1700093C RID: 2364
		// (get) Token: 0x06001D79 RID: 7545 RVA: 0x00039FC0 File Offset: 0x000381C0
		// (set) Token: 0x06001D7A RID: 7546 RVA: 0x00039FEC File Offset: 0x000381EC
		[ProtoMember(2, IsRequired = false, Name = "isRefresh", DataFormat = DataFormat.Default)]
		public bool isRefresh
		{
			get
			{
				return this._isRefresh ?? false;
			}
			set
			{
				this._isRefresh = new bool?(value);
			}
		}

		// Token: 0x1700093D RID: 2365
		// (get) Token: 0x06001D7B RID: 7547 RVA: 0x00039FFC File Offset: 0x000381FC
		// (set) Token: 0x06001D7C RID: 7548 RVA: 0x0003A01C File Offset: 0x0003821C
		[XmlIgnore]
		[Browsable(false)]
		public bool isRefreshSpecified
		{
			get
			{
				return this._isRefresh != null;
			}
			set
			{
				bool flag = value == (this._isRefresh == null);
				if (flag)
				{
					this._isRefresh = (value ? new bool?(this.isRefresh) : null);
				}
			}
		}

		// Token: 0x06001D7D RID: 7549 RVA: 0x0003A060 File Offset: 0x00038260
		private bool ShouldSerializeisRefresh()
		{
			return this.isRefreshSpecified;
		}

		// Token: 0x06001D7E RID: 7550 RVA: 0x0003A078 File Offset: 0x00038278
		private void ResetisRefresh()
		{
			this.isRefreshSpecified = false;
		}

		// Token: 0x1700093E RID: 2366
		// (get) Token: 0x06001D7F RID: 7551 RVA: 0x0003A084 File Offset: 0x00038284
		// (set) Token: 0x06001D80 RID: 7552 RVA: 0x0003A0B0 File Offset: 0x000382B0
		[ProtoMember(3, IsRequired = false, Name = "onlyCountInfo", DataFormat = DataFormat.Default)]
		public bool onlyCountInfo
		{
			get
			{
				return this._onlyCountInfo ?? false;
			}
			set
			{
				this._onlyCountInfo = new bool?(value);
			}
		}

		// Token: 0x1700093F RID: 2367
		// (get) Token: 0x06001D81 RID: 7553 RVA: 0x0003A0C0 File Offset: 0x000382C0
		// (set) Token: 0x06001D82 RID: 7554 RVA: 0x0003A0E0 File Offset: 0x000382E0
		[XmlIgnore]
		[Browsable(false)]
		public bool onlyCountInfoSpecified
		{
			get
			{
				return this._onlyCountInfo != null;
			}
			set
			{
				bool flag = value == (this._onlyCountInfo == null);
				if (flag)
				{
					this._onlyCountInfo = (value ? new bool?(this.onlyCountInfo) : null);
				}
			}
		}

		// Token: 0x06001D83 RID: 7555 RVA: 0x0003A124 File Offset: 0x00038324
		private bool ShouldSerializeonlyCountInfo()
		{
			return this.onlyCountInfoSpecified;
		}

		// Token: 0x06001D84 RID: 7556 RVA: 0x0003A13C File Offset: 0x0003833C
		private void ResetonlyCountInfo()
		{
			this.onlyCountInfoSpecified = false;
		}

		// Token: 0x06001D85 RID: 7557 RVA: 0x0003A148 File Offset: 0x00038348
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400075E RID: 1886
		private int? _mapID;

		// Token: 0x0400075F RID: 1887
		private bool? _isRefresh;

		// Token: 0x04000760 RID: 1888
		private bool? _onlyCountInfo;

		// Token: 0x04000761 RID: 1889
		private IExtension extensionObject;
	}
}
