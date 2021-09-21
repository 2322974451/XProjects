using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200064A RID: 1610
	[ProtoContract(Name = "BackFlowShopData")]
	[Serializable]
	public class BackFlowShopData : IExtensible
	{
		// Token: 0x17001F94 RID: 8084
		// (get) Token: 0x06006420 RID: 25632 RVA: 0x000BF18C File Offset: 0x000BD38C
		// (set) Token: 0x06006421 RID: 25633 RVA: 0x000BF1B8 File Offset: 0x000BD3B8
		[ProtoMember(1, IsRequired = false, Name = "lastUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastUpdateTime
		{
			get
			{
				return this._lastUpdateTime ?? 0U;
			}
			set
			{
				this._lastUpdateTime = new uint?(value);
			}
		}

		// Token: 0x17001F95 RID: 8085
		// (get) Token: 0x06006422 RID: 25634 RVA: 0x000BF1C8 File Offset: 0x000BD3C8
		// (set) Token: 0x06006423 RID: 25635 RVA: 0x000BF1E8 File Offset: 0x000BD3E8
		[XmlIgnore]
		[Browsable(false)]
		public bool lastUpdateTimeSpecified
		{
			get
			{
				return this._lastUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._lastUpdateTime == null);
				if (flag)
				{
					this._lastUpdateTime = (value ? new uint?(this.lastUpdateTime) : null);
				}
			}
		}

		// Token: 0x06006424 RID: 25636 RVA: 0x000BF22C File Offset: 0x000BD42C
		private bool ShouldSerializelastUpdateTime()
		{
			return this.lastUpdateTimeSpecified;
		}

		// Token: 0x06006425 RID: 25637 RVA: 0x000BF244 File Offset: 0x000BD444
		private void ResetlastUpdateTime()
		{
			this.lastUpdateTimeSpecified = false;
		}

		// Token: 0x17001F96 RID: 8086
		// (get) Token: 0x06006426 RID: 25638 RVA: 0x000BF250 File Offset: 0x000BD450
		[ProtoMember(2, Name = "goods", DataFormat = DataFormat.Default)]
		public List<BackFlowShopGood> goods
		{
			get
			{
				return this._goods;
			}
		}

		// Token: 0x17001F97 RID: 8087
		// (get) Token: 0x06006427 RID: 25639 RVA: 0x000BF268 File Offset: 0x000BD468
		// (set) Token: 0x06006428 RID: 25640 RVA: 0x000BF294 File Offset: 0x000BD494
		[ProtoMember(3, IsRequired = false, Name = "freshCount", DataFormat = DataFormat.TwosComplement)]
		public uint freshCount
		{
			get
			{
				return this._freshCount ?? 0U;
			}
			set
			{
				this._freshCount = new uint?(value);
			}
		}

		// Token: 0x17001F98 RID: 8088
		// (get) Token: 0x06006429 RID: 25641 RVA: 0x000BF2A4 File Offset: 0x000BD4A4
		// (set) Token: 0x0600642A RID: 25642 RVA: 0x000BF2C4 File Offset: 0x000BD4C4
		[XmlIgnore]
		[Browsable(false)]
		public bool freshCountSpecified
		{
			get
			{
				return this._freshCount != null;
			}
			set
			{
				bool flag = value == (this._freshCount == null);
				if (flag)
				{
					this._freshCount = (value ? new uint?(this.freshCount) : null);
				}
			}
		}

		// Token: 0x0600642B RID: 25643 RVA: 0x000BF308 File Offset: 0x000BD508
		private bool ShouldSerializefreshCount()
		{
			return this.freshCountSpecified;
		}

		// Token: 0x0600642C RID: 25644 RVA: 0x000BF320 File Offset: 0x000BD520
		private void ResetfreshCount()
		{
			this.freshCountSpecified = false;
		}

		// Token: 0x0600642D RID: 25645 RVA: 0x000BF32C File Offset: 0x000BD52C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001846 RID: 6214
		private uint? _lastUpdateTime;

		// Token: 0x04001847 RID: 6215
		private readonly List<BackFlowShopGood> _goods = new List<BackFlowShopGood>();

		// Token: 0x04001848 RID: 6216
		private uint? _freshCount;

		// Token: 0x04001849 RID: 6217
		private IExtension extensionObject;
	}
}
