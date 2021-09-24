using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiskBoxInfo")]
	[Serializable]
	public class RiskBoxInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public RiskBoxState state
		{
			get
			{
				return this._state ?? RiskBoxState.RISK_BOX_LOCKED;
			}
			set
			{
				this._state = new RiskBoxState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new RiskBoxState?(this.state) : null);
				}
			}
		}

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public int leftTime
		{
			get
			{
				return this._leftTime ?? 0;
			}
			set
			{
				this._leftTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new int?(this.leftTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "item", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief item
		{
			get
			{
				return this._item;
			}
			set
			{
				this._item = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "beginTime", DataFormat = DataFormat.TwosComplement)]
		public int beginTime
		{
			get
			{
				return this._beginTime ?? 0;
			}
			set
			{
				this._beginTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool beginTimeSpecified
		{
			get
			{
				return this._beginTime != null;
			}
			set
			{
				bool flag = value == (this._beginTime == null);
				if (flag)
				{
					this._beginTime = (value ? new int?(this.beginTime) : null);
				}
			}
		}

		private bool ShouldSerializebeginTime()
		{
			return this.beginTimeSpecified;
		}

		private void ResetbeginTime()
		{
			this.beginTimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RiskBoxState? _state;

		private int? _leftTime;

		private ItemBrief _item = null;

		private int? _beginTime;

		private int? _slot;

		private IExtension extensionObject;
	}
}
