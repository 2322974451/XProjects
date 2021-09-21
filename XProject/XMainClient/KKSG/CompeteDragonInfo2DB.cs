using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200067E RID: 1662
	[ProtoContract(Name = "CompeteDragonInfo2DB")]
	[Serializable]
	public class CompeteDragonInfo2DB : IExtensible
	{
		// Token: 0x170021B2 RID: 8626
		// (get) Token: 0x06006A7D RID: 27261 RVA: 0x000CBA4C File Offset: 0x000C9C4C
		// (set) Token: 0x06006A7E RID: 27262 RVA: 0x000CBA78 File Offset: 0x000C9C78
		[ProtoMember(1, IsRequired = false, Name = "updateDay", DataFormat = DataFormat.TwosComplement)]
		public int updateDay
		{
			get
			{
				return this._updateDay ?? 0;
			}
			set
			{
				this._updateDay = new int?(value);
			}
		}

		// Token: 0x170021B3 RID: 8627
		// (get) Token: 0x06006A7F RID: 27263 RVA: 0x000CBA88 File Offset: 0x000C9C88
		// (set) Token: 0x06006A80 RID: 27264 RVA: 0x000CBAA8 File Offset: 0x000C9CA8
		[XmlIgnore]
		[Browsable(false)]
		public bool updateDaySpecified
		{
			get
			{
				return this._updateDay != null;
			}
			set
			{
				bool flag = value == (this._updateDay == null);
				if (flag)
				{
					this._updateDay = (value ? new int?(this.updateDay) : null);
				}
			}
		}

		// Token: 0x06006A81 RID: 27265 RVA: 0x000CBAEC File Offset: 0x000C9CEC
		private bool ShouldSerializeupdateDay()
		{
			return this.updateDaySpecified;
		}

		// Token: 0x06006A82 RID: 27266 RVA: 0x000CBB04 File Offset: 0x000C9D04
		private void ResetupdateDay()
		{
			this.updateDaySpecified = false;
		}

		// Token: 0x170021B4 RID: 8628
		// (get) Token: 0x06006A83 RID: 27267 RVA: 0x000CBB10 File Offset: 0x000C9D10
		// (set) Token: 0x06006A84 RID: 27268 RVA: 0x000CBB3C File Offset: 0x000C9D3C
		[ProtoMember(2, IsRequired = false, Name = "throughCount", DataFormat = DataFormat.TwosComplement)]
		public uint throughCount
		{
			get
			{
				return this._throughCount ?? 0U;
			}
			set
			{
				this._throughCount = new uint?(value);
			}
		}

		// Token: 0x170021B5 RID: 8629
		// (get) Token: 0x06006A85 RID: 27269 RVA: 0x000CBB4C File Offset: 0x000C9D4C
		// (set) Token: 0x06006A86 RID: 27270 RVA: 0x000CBB6C File Offset: 0x000C9D6C
		[XmlIgnore]
		[Browsable(false)]
		public bool throughCountSpecified
		{
			get
			{
				return this._throughCount != null;
			}
			set
			{
				bool flag = value == (this._throughCount == null);
				if (flag)
				{
					this._throughCount = (value ? new uint?(this.throughCount) : null);
				}
			}
		}

		// Token: 0x06006A87 RID: 27271 RVA: 0x000CBBB0 File Offset: 0x000C9DB0
		private bool ShouldSerializethroughCount()
		{
			return this.throughCountSpecified;
		}

		// Token: 0x06006A88 RID: 27272 RVA: 0x000CBBC8 File Offset: 0x000C9DC8
		private void ResetthroughCount()
		{
			this.throughCountSpecified = false;
		}

		// Token: 0x170021B6 RID: 8630
		// (get) Token: 0x06006A89 RID: 27273 RVA: 0x000CBBD4 File Offset: 0x000C9DD4
		// (set) Token: 0x06006A8A RID: 27274 RVA: 0x000CBC00 File Offset: 0x000C9E00
		[ProtoMember(3, IsRequired = false, Name = "getRewardCount", DataFormat = DataFormat.TwosComplement)]
		public uint getRewardCount
		{
			get
			{
				return this._getRewardCount ?? 0U;
			}
			set
			{
				this._getRewardCount = new uint?(value);
			}
		}

		// Token: 0x170021B7 RID: 8631
		// (get) Token: 0x06006A8B RID: 27275 RVA: 0x000CBC10 File Offset: 0x000C9E10
		// (set) Token: 0x06006A8C RID: 27276 RVA: 0x000CBC30 File Offset: 0x000C9E30
		[XmlIgnore]
		[Browsable(false)]
		public bool getRewardCountSpecified
		{
			get
			{
				return this._getRewardCount != null;
			}
			set
			{
				bool flag = value == (this._getRewardCount == null);
				if (flag)
				{
					this._getRewardCount = (value ? new uint?(this.getRewardCount) : null);
				}
			}
		}

		// Token: 0x06006A8D RID: 27277 RVA: 0x000CBC74 File Offset: 0x000C9E74
		private bool ShouldSerializegetRewardCount()
		{
			return this.getRewardCountSpecified;
		}

		// Token: 0x06006A8E RID: 27278 RVA: 0x000CBC8C File Offset: 0x000C9E8C
		private void ResetgetRewardCount()
		{
			this.getRewardCountSpecified = false;
		}

		// Token: 0x06006A8F RID: 27279 RVA: 0x000CBC98 File Offset: 0x000C9E98
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019A5 RID: 6565
		private int? _updateDay;

		// Token: 0x040019A6 RID: 6566
		private uint? _throughCount;

		// Token: 0x040019A7 RID: 6567
		private uint? _getRewardCount;

		// Token: 0x040019A8 RID: 6568
		private IExtension extensionObject;
	}
}
