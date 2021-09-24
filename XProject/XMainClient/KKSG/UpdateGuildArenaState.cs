using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UpdateGuildArenaState")]
	[Serializable]
	public class UpdateGuildArenaState : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "warType", DataFormat = DataFormat.TwosComplement)]
		public uint warType
		{
			get
			{
				return this._warType ?? 0U;
			}
			set
			{
				this._warType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool warTypeSpecified
		{
			get
			{
				return this._warType != null;
			}
			set
			{
				bool flag = value == (this._warType == null);
				if (flag)
				{
					this._warType = (value ? new uint?(this.warType) : null);
				}
			}
		}

		private bool ShouldSerializewarType()
		{
			return this.warTypeSpecified;
		}

		private void ResetwarType()
		{
			this.warTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "battleId", DataFormat = DataFormat.TwosComplement)]
		public uint battleId
		{
			get
			{
				return this._battleId ?? 0U;
			}
			set
			{
				this._battleId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool battleIdSpecified
		{
			get
			{
				return this._battleId != null;
			}
			set
			{
				bool flag = value == (this._battleId == null);
				if (flag)
				{
					this._battleId = (value ? new uint?(this.battleId) : null);
				}
			}
		}

		private bool ShouldSerializebattleId()
		{
			return this.battleIdSpecified;
		}

		private void ResetbattleId()
		{
			this.battleIdSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
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
					this._state = (value ? new uint?(this.state) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _warType;

		private uint? _battleId;

		private uint? _state;

		private IExtension extensionObject;
	}
}
