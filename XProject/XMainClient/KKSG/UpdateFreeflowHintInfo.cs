using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UpdateFreeflowHintInfo")]
	[Serializable]
	public class UpdateFreeflowHintInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "hint_time", DataFormat = DataFormat.TwosComplement)]
		public uint hint_time
		{
			get
			{
				return this._hint_time ?? 0U;
			}
			set
			{
				this._hint_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hint_timeSpecified
		{
			get
			{
				return this._hint_time != null;
			}
			set
			{
				bool flag = value == (this._hint_time == null);
				if (flag)
				{
					this._hint_time = (value ? new uint?(this.hint_time) : null);
				}
			}
		}

		private bool ShouldSerializehint_time()
		{
			return this.hint_timeSpecified;
		}

		private void Resethint_time()
		{
			this.hint_timeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _hint_time;

		private IExtension extensionObject;
	}
}
