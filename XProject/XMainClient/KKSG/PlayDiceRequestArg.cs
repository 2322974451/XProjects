using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200020D RID: 525
	[ProtoContract(Name = "PlayDiceRequestArg")]
	[Serializable]
	public class PlayDiceRequestArg : IExtensible
	{
		// Token: 0x17000949 RID: 2377
		// (get) Token: 0x06001DA5 RID: 7589 RVA: 0x0003A4EC File Offset: 0x000386EC
		// (set) Token: 0x06001DA6 RID: 7590 RVA: 0x0003A518 File Offset: 0x00038718
		[ProtoMember(1, IsRequired = false, Name = "mapid", DataFormat = DataFormat.TwosComplement)]
		public int mapid
		{
			get
			{
				return this._mapid ?? 0;
			}
			set
			{
				this._mapid = new int?(value);
			}
		}

		// Token: 0x1700094A RID: 2378
		// (get) Token: 0x06001DA7 RID: 7591 RVA: 0x0003A528 File Offset: 0x00038728
		// (set) Token: 0x06001DA8 RID: 7592 RVA: 0x0003A548 File Offset: 0x00038748
		[XmlIgnore]
		[Browsable(false)]
		public bool mapidSpecified
		{
			get
			{
				return this._mapid != null;
			}
			set
			{
				bool flag = value == (this._mapid == null);
				if (flag)
				{
					this._mapid = (value ? new int?(this.mapid) : null);
				}
			}
		}

		// Token: 0x06001DA9 RID: 7593 RVA: 0x0003A58C File Offset: 0x0003878C
		private bool ShouldSerializemapid()
		{
			return this.mapidSpecified;
		}

		// Token: 0x06001DAA RID: 7594 RVA: 0x0003A5A4 File Offset: 0x000387A4
		private void Resetmapid()
		{
			this.mapidSpecified = false;
		}

		// Token: 0x1700094B RID: 2379
		// (get) Token: 0x06001DAB RID: 7595 RVA: 0x0003A5B0 File Offset: 0x000387B0
		// (set) Token: 0x06001DAC RID: 7596 RVA: 0x0003A5DC File Offset: 0x000387DC
		[ProtoMember(2, IsRequired = false, Name = "randValue", DataFormat = DataFormat.TwosComplement)]
		public int randValue
		{
			get
			{
				return this._randValue ?? 0;
			}
			set
			{
				this._randValue = new int?(value);
			}
		}

		// Token: 0x1700094C RID: 2380
		// (get) Token: 0x06001DAD RID: 7597 RVA: 0x0003A5EC File Offset: 0x000387EC
		// (set) Token: 0x06001DAE RID: 7598 RVA: 0x0003A60C File Offset: 0x0003880C
		[XmlIgnore]
		[Browsable(false)]
		public bool randValueSpecified
		{
			get
			{
				return this._randValue != null;
			}
			set
			{
				bool flag = value == (this._randValue == null);
				if (flag)
				{
					this._randValue = (value ? new int?(this.randValue) : null);
				}
			}
		}

		// Token: 0x06001DAF RID: 7599 RVA: 0x0003A650 File Offset: 0x00038850
		private bool ShouldSerializerandValue()
		{
			return this.randValueSpecified;
		}

		// Token: 0x06001DB0 RID: 7600 RVA: 0x0003A668 File Offset: 0x00038868
		private void ResetrandValue()
		{
			this.randValueSpecified = false;
		}

		// Token: 0x06001DB1 RID: 7601 RVA: 0x0003A674 File Offset: 0x00038874
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000769 RID: 1897
		private int? _mapid;

		// Token: 0x0400076A RID: 1898
		private int? _randValue;

		// Token: 0x0400076B RID: 1899
		private IExtension extensionObject;
	}
}
