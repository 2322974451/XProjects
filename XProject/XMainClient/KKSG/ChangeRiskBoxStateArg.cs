using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChangeRiskBoxStateArg")]
	[Serializable]
	public class ChangeRiskBoxStateArg : IExtensible
	{

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

		private bool ShouldSerializedestState()
		{
			return this.destStateSpecified;
		}

		private void ResetdestState()
		{
			this.destStateSpecified = false;
		}

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

		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		private void Resetslot()
		{
			this.slotSpecified = false;
		}

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

		private bool ShouldSerializemapID()
		{
			return this.mapIDSpecified;
		}

		private void ResetmapID()
		{
			this.mapIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RiskBoxState? _destState;

		private int? _slot;

		private int? _mapID;

		private IExtension extensionObject;
	}
}
