using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AchivementInfo")]
	[Serializable]
	public class AchivementInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "achivementID", DataFormat = DataFormat.TwosComplement)]
		public uint achivementID
		{
			get
			{
				return this._achivementID ?? 0U;
			}
			set
			{
				this._achivementID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool achivementIDSpecified
		{
			get
			{
				return this._achivementID != null;
			}
			set
			{
				bool flag = value == (this._achivementID == null);
				if (flag)
				{
					this._achivementID = (value ? new uint?(this.achivementID) : null);
				}
			}
		}

		private bool ShouldSerializeachivementID()
		{
			return this.achivementIDSpecified;
		}

		private void ResetachivementID()
		{
			this.achivementIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
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

		private uint? _achivementID;

		private uint? _state;

		private IExtension extensionObject;
	}
}
