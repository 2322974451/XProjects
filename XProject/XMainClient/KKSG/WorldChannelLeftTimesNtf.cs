using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WorldChannelLeftTimesNtf")]
	[Serializable]
	public class WorldChannelLeftTimesNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "leftTimes", DataFormat = DataFormat.TwosComplement)]
		public uint leftTimes
		{
			get
			{
				return this._leftTimes ?? 0U;
			}
			set
			{
				this._leftTimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimesSpecified
		{
			get
			{
				return this._leftTimes != null;
			}
			set
			{
				bool flag = value == (this._leftTimes == null);
				if (flag)
				{
					this._leftTimes = (value ? new uint?(this.leftTimes) : null);
				}
			}
		}

		private bool ShouldSerializeleftTimes()
		{
			return this.leftTimesSpecified;
		}

		private void ResetleftTimes()
		{
			this.leftTimesSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _leftTimes;

		private IExtension extensionObject;
	}
}
