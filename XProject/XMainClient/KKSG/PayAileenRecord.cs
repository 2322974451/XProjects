using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000621 RID: 1569
	[ProtoContract(Name = "PayAileenRecord")]
	[Serializable]
	public class PayAileenRecord : IExtensible
	{
		// Token: 0x17001E33 RID: 7731
		// (get) Token: 0x06005FFE RID: 24574 RVA: 0x000B7150 File Offset: 0x000B5350
		// (set) Token: 0x06005FFF RID: 24575 RVA: 0x000B7171 File Offset: 0x000B5371
		[ProtoMember(1, IsRequired = false, Name = "paramID", DataFormat = DataFormat.Default)]
		public string paramID
		{
			get
			{
				return this._paramID ?? "";
			}
			set
			{
				this._paramID = value;
			}
		}

		// Token: 0x17001E34 RID: 7732
		// (get) Token: 0x06006000 RID: 24576 RVA: 0x000B717C File Offset: 0x000B537C
		// (set) Token: 0x06006001 RID: 24577 RVA: 0x000B7198 File Offset: 0x000B5398
		[XmlIgnore]
		[Browsable(false)]
		public bool paramIDSpecified
		{
			get
			{
				return this._paramID != null;
			}
			set
			{
				bool flag = value == (this._paramID == null);
				if (flag)
				{
					this._paramID = (value ? this.paramID : null);
				}
			}
		}

		// Token: 0x06006002 RID: 24578 RVA: 0x000B71C8 File Offset: 0x000B53C8
		private bool ShouldSerializeparamID()
		{
			return this.paramIDSpecified;
		}

		// Token: 0x06006003 RID: 24579 RVA: 0x000B71E0 File Offset: 0x000B53E0
		private void ResetparamID()
		{
			this.paramIDSpecified = false;
		}

		// Token: 0x17001E35 RID: 7733
		// (get) Token: 0x06006004 RID: 24580 RVA: 0x000B71EC File Offset: 0x000B53EC
		// (set) Token: 0x06006005 RID: 24581 RVA: 0x000B7218 File Offset: 0x000B5418
		[ProtoMember(2, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public int itemID
		{
			get
			{
				return this._itemID ?? 0;
			}
			set
			{
				this._itemID = new int?(value);
			}
		}

		// Token: 0x17001E36 RID: 7734
		// (get) Token: 0x06006006 RID: 24582 RVA: 0x000B7228 File Offset: 0x000B5428
		// (set) Token: 0x06006007 RID: 24583 RVA: 0x000B7248 File Offset: 0x000B5448
		[XmlIgnore]
		[Browsable(false)]
		public bool itemIDSpecified
		{
			get
			{
				return this._itemID != null;
			}
			set
			{
				bool flag = value == (this._itemID == null);
				if (flag)
				{
					this._itemID = (value ? new int?(this.itemID) : null);
				}
			}
		}

		// Token: 0x06006008 RID: 24584 RVA: 0x000B728C File Offset: 0x000B548C
		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		// Token: 0x06006009 RID: 24585 RVA: 0x000B72A4 File Offset: 0x000B54A4
		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		// Token: 0x17001E37 RID: 7735
		// (get) Token: 0x0600600A RID: 24586 RVA: 0x000B72B0 File Offset: 0x000B54B0
		// (set) Token: 0x0600600B RID: 24587 RVA: 0x000B72DC File Offset: 0x000B54DC
		[ProtoMember(3, IsRequired = false, Name = "lastBuyTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastBuyTime
		{
			get
			{
				return this._lastBuyTime ?? 0U;
			}
			set
			{
				this._lastBuyTime = new uint?(value);
			}
		}

		// Token: 0x17001E38 RID: 7736
		// (get) Token: 0x0600600C RID: 24588 RVA: 0x000B72EC File Offset: 0x000B54EC
		// (set) Token: 0x0600600D RID: 24589 RVA: 0x000B730C File Offset: 0x000B550C
		[XmlIgnore]
		[Browsable(false)]
		public bool lastBuyTimeSpecified
		{
			get
			{
				return this._lastBuyTime != null;
			}
			set
			{
				bool flag = value == (this._lastBuyTime == null);
				if (flag)
				{
					this._lastBuyTime = (value ? new uint?(this.lastBuyTime) : null);
				}
			}
		}

		// Token: 0x0600600E RID: 24590 RVA: 0x000B7350 File Offset: 0x000B5550
		private bool ShouldSerializelastBuyTime()
		{
			return this.lastBuyTimeSpecified;
		}

		// Token: 0x0600600F RID: 24591 RVA: 0x000B7368 File Offset: 0x000B5568
		private void ResetlastBuyTime()
		{
			this.lastBuyTimeSpecified = false;
		}

		// Token: 0x17001E39 RID: 7737
		// (get) Token: 0x06006010 RID: 24592 RVA: 0x000B7374 File Offset: 0x000B5574
		// (set) Token: 0x06006011 RID: 24593 RVA: 0x000B738C File Offset: 0x000B558C
		[ProtoMember(4, IsRequired = false, Name = "detail", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PaytssInfo detail
		{
			get
			{
				return this._detail;
			}
			set
			{
				this._detail = value;
			}
		}

		// Token: 0x17001E3A RID: 7738
		// (get) Token: 0x06006012 RID: 24594 RVA: 0x000B7398 File Offset: 0x000B5598
		// (set) Token: 0x06006013 RID: 24595 RVA: 0x000B73C4 File Offset: 0x000B55C4
		[ProtoMember(5, IsRequired = false, Name = "lastdelivertime", DataFormat = DataFormat.TwosComplement)]
		public uint lastdelivertime
		{
			get
			{
				return this._lastdelivertime ?? 0U;
			}
			set
			{
				this._lastdelivertime = new uint?(value);
			}
		}

		// Token: 0x17001E3B RID: 7739
		// (get) Token: 0x06006014 RID: 24596 RVA: 0x000B73D4 File Offset: 0x000B55D4
		// (set) Token: 0x06006015 RID: 24597 RVA: 0x000B73F4 File Offset: 0x000B55F4
		[XmlIgnore]
		[Browsable(false)]
		public bool lastdelivertimeSpecified
		{
			get
			{
				return this._lastdelivertime != null;
			}
			set
			{
				bool flag = value == (this._lastdelivertime == null);
				if (flag)
				{
					this._lastdelivertime = (value ? new uint?(this.lastdelivertime) : null);
				}
			}
		}

		// Token: 0x06006016 RID: 24598 RVA: 0x000B7438 File Offset: 0x000B5638
		private bool ShouldSerializelastdelivertime()
		{
			return this.lastdelivertimeSpecified;
		}

		// Token: 0x06006017 RID: 24599 RVA: 0x000B7450 File Offset: 0x000B5650
		private void Resetlastdelivertime()
		{
			this.lastdelivertimeSpecified = false;
		}

		// Token: 0x06006018 RID: 24600 RVA: 0x000B745C File Offset: 0x000B565C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001753 RID: 5971
		private string _paramID;

		// Token: 0x04001754 RID: 5972
		private int? _itemID;

		// Token: 0x04001755 RID: 5973
		private uint? _lastBuyTime;

		// Token: 0x04001756 RID: 5974
		private PaytssInfo _detail = null;

		// Token: 0x04001757 RID: 5975
		private uint? _lastdelivertime;

		// Token: 0x04001758 RID: 5976
		private IExtension extensionObject;
	}
}
