using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200020C RID: 524
	[ProtoContract(Name = "PlayDiceNtfData")]
	[Serializable]
	public class PlayDiceNtfData : IExtensible
	{
		// Token: 0x17000943 RID: 2371
		// (get) Token: 0x06001D91 RID: 7569 RVA: 0x0003A280 File Offset: 0x00038480
		// (set) Token: 0x06001D92 RID: 7570 RVA: 0x0003A2AC File Offset: 0x000384AC
		[ProtoMember(1, IsRequired = false, Name = "isDiceFull", DataFormat = DataFormat.Default)]
		public bool isDiceFull
		{
			get
			{
				return this._isDiceFull ?? false;
			}
			set
			{
				this._isDiceFull = new bool?(value);
			}
		}

		// Token: 0x17000944 RID: 2372
		// (get) Token: 0x06001D93 RID: 7571 RVA: 0x0003A2BC File Offset: 0x000384BC
		// (set) Token: 0x06001D94 RID: 7572 RVA: 0x0003A2DC File Offset: 0x000384DC
		[XmlIgnore]
		[Browsable(false)]
		public bool isDiceFullSpecified
		{
			get
			{
				return this._isDiceFull != null;
			}
			set
			{
				bool flag = value == (this._isDiceFull == null);
				if (flag)
				{
					this._isDiceFull = (value ? new bool?(this.isDiceFull) : null);
				}
			}
		}

		// Token: 0x06001D95 RID: 7573 RVA: 0x0003A320 File Offset: 0x00038520
		private bool ShouldSerializeisDiceFull()
		{
			return this.isDiceFullSpecified;
		}

		// Token: 0x06001D96 RID: 7574 RVA: 0x0003A338 File Offset: 0x00038538
		private void ResetisDiceFull()
		{
			this.isDiceFullSpecified = false;
		}

		// Token: 0x17000945 RID: 2373
		// (get) Token: 0x06001D97 RID: 7575 RVA: 0x0003A344 File Offset: 0x00038544
		// (set) Token: 0x06001D98 RID: 7576 RVA: 0x0003A370 File Offset: 0x00038570
		[ProtoMember(2, IsRequired = false, Name = "mapID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000946 RID: 2374
		// (get) Token: 0x06001D99 RID: 7577 RVA: 0x0003A380 File Offset: 0x00038580
		// (set) Token: 0x06001D9A RID: 7578 RVA: 0x0003A3A0 File Offset: 0x000385A0
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

		// Token: 0x06001D9B RID: 7579 RVA: 0x0003A3E4 File Offset: 0x000385E4
		private bool ShouldSerializemapID()
		{
			return this.mapIDSpecified;
		}

		// Token: 0x06001D9C RID: 7580 RVA: 0x0003A3FC File Offset: 0x000385FC
		private void ResetmapID()
		{
			this.mapIDSpecified = false;
		}

		// Token: 0x17000947 RID: 2375
		// (get) Token: 0x06001D9D RID: 7581 RVA: 0x0003A408 File Offset: 0x00038608
		// (set) Token: 0x06001D9E RID: 7582 RVA: 0x0003A434 File Offset: 0x00038634
		[ProtoMember(3, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public int slot
		{
			get
			{
				return this._slot ?? 0;
			}
			set
			{
				this._slot = new int?(value);
			}
		}

		// Token: 0x17000948 RID: 2376
		// (get) Token: 0x06001D9F RID: 7583 RVA: 0x0003A444 File Offset: 0x00038644
		// (set) Token: 0x06001DA0 RID: 7584 RVA: 0x0003A464 File Offset: 0x00038664
		[XmlIgnore]
		[Browsable(false)]
		public bool slotSpecified
		{
			get
			{
				return this._slot != null;
			}
			set
			{
				bool flag = value == (this._slot == null);
				if (flag)
				{
					this._slot = (value ? new int?(this.slot) : null);
				}
			}
		}

		// Token: 0x06001DA1 RID: 7585 RVA: 0x0003A4A8 File Offset: 0x000386A8
		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		// Token: 0x06001DA2 RID: 7586 RVA: 0x0003A4C0 File Offset: 0x000386C0
		private void Resetslot()
		{
			this.slotSpecified = false;
		}

		// Token: 0x06001DA3 RID: 7587 RVA: 0x0003A4CC File Offset: 0x000386CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000765 RID: 1893
		private bool? _isDiceFull;

		// Token: 0x04000766 RID: 1894
		private int? _mapID;

		// Token: 0x04000767 RID: 1895
		private int? _slot;

		// Token: 0x04000768 RID: 1896
		private IExtension extensionObject;
	}
}
