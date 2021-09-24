using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LargeRoomLoginParam")]
	[Serializable]
	public class LargeRoomLoginParam : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "speaker", DataFormat = DataFormat.Default)]
		public bool speaker
		{
			get
			{
				return this._speaker ?? false;
			}
			set
			{
				this._speaker = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool speakerSpecified
		{
			get
			{
				return this._speaker != null;
			}
			set
			{
				bool flag = value == (this._speaker == null);
				if (flag)
				{
					this._speaker = (value ? new bool?(this.speaker) : null);
				}
			}
		}

		private bool ShouldSerializespeaker()
		{
			return this.speakerSpecified;
		}

		private void Resetspeaker()
		{
			this.speakerSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _speaker;

		private IExtension extensionObject;
	}
}
