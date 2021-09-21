using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000210 RID: 528
	[ProtoContract(Name = "ChangeRiskBoxStateArg")]
	[Serializable]
	public class ChangeRiskBoxStateArg : IExtensible
	{
		// Token: 0x17000953 RID: 2387
		// (get) Token: 0x06001DC9 RID: 7625 RVA: 0x0003A920 File Offset: 0x00038B20
		// (set) Token: 0x06001DCA RID: 7626 RVA: 0x0003A94C File Offset: 0x00038B4C
		[ProtoMember(1, IsRequired = false, Name = "destState", DataFormat = DataFormat.TwosComplement)]
		public RiskBoxState destState
		{
			get
			{
				return this._destState ?? RiskBoxState.RISK_BOX_LOCKED;
			}
			set
			{
				this._destState = new RiskBoxState?(value);
			}
		}

		// Token: 0x17000954 RID: 2388
		// (get) Token: 0x06001DCB RID: 7627 RVA: 0x0003A95C File Offset: 0x00038B5C
		// (set) Token: 0x06001DCC RID: 7628 RVA: 0x0003A97C File Offset: 0x00038B7C
		[XmlIgnore]
		[Browsable(false)]
		public bool destStateSpecified
		{
			get
			{
				return this._destState != null;
			}
			set
			{
				bool flag = value == (this._destState == null);
				if (flag)
				{
					this._destState = (value ? new RiskBoxState?(this.destState) : null);
				}
			}
		}

		// Token: 0x06001DCD RID: 7629 RVA: 0x0003A9C0 File Offset: 0x00038BC0
		private bool ShouldSerializedestState()
		{
			return this.destStateSpecified;
		}

		// Token: 0x06001DCE RID: 7630 RVA: 0x0003A9D8 File Offset: 0x00038BD8
		private void ResetdestState()
		{
			this.destStateSpecified = false;
		}

		// Token: 0x17000955 RID: 2389
		// (get) Token: 0x06001DCF RID: 7631 RVA: 0x0003A9E4 File Offset: 0x00038BE4
		// (set) Token: 0x06001DD0 RID: 7632 RVA: 0x0003AA10 File Offset: 0x00038C10
		[ProtoMember(2, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000956 RID: 2390
		// (get) Token: 0x06001DD1 RID: 7633 RVA: 0x0003AA20 File Offset: 0x00038C20
		// (set) Token: 0x06001DD2 RID: 7634 RVA: 0x0003AA40 File Offset: 0x00038C40
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

		// Token: 0x06001DD3 RID: 7635 RVA: 0x0003AA84 File Offset: 0x00038C84
		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		// Token: 0x06001DD4 RID: 7636 RVA: 0x0003AA9C File Offset: 0x00038C9C
		private void Resetslot()
		{
			this.slotSpecified = false;
		}

		// Token: 0x17000957 RID: 2391
		// (get) Token: 0x06001DD5 RID: 7637 RVA: 0x0003AAA8 File Offset: 0x00038CA8
		// (set) Token: 0x06001DD6 RID: 7638 RVA: 0x0003AAD4 File Offset: 0x00038CD4
		[ProtoMember(3, IsRequired = false, Name = "mapID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000958 RID: 2392
		// (get) Token: 0x06001DD7 RID: 7639 RVA: 0x0003AAE4 File Offset: 0x00038CE4
		// (set) Token: 0x06001DD8 RID: 7640 RVA: 0x0003AB04 File Offset: 0x00038D04
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

		// Token: 0x06001DD9 RID: 7641 RVA: 0x0003AB48 File Offset: 0x00038D48
		private bool ShouldSerializemapID()
		{
			return this.mapIDSpecified;
		}

		// Token: 0x06001DDA RID: 7642 RVA: 0x0003AB60 File Offset: 0x00038D60
		private void ResetmapID()
		{
			this.mapIDSpecified = false;
		}

		// Token: 0x06001DDB RID: 7643 RVA: 0x0003AB6C File Offset: 0x00038D6C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000771 RID: 1905
		private RiskBoxState? _destState;

		// Token: 0x04000772 RID: 1906
		private int? _slot;

		// Token: 0x04000773 RID: 1907
		private int? _mapID;

		// Token: 0x04000774 RID: 1908
		private IExtension extensionObject;
	}
}
