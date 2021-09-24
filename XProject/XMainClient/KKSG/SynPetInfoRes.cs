using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SynPetInfoRes")]
	[Serializable]
	public class SynPetInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "mood", DataFormat = DataFormat.TwosComplement)]
		public uint mood
		{
			get
			{
				return this._mood ?? 0U;
			}
			set
			{
				this._mood = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool moodSpecified
		{
			get
			{
				return this._mood != null;
			}
			set
			{
				bool flag = value == (this._mood == null);
				if (flag)
				{
					this._mood = (value ? new uint?(this.mood) : null);
				}
			}
		}

		private bool ShouldSerializemood()
		{
			return this.moodSpecified;
		}

		private void Resetmood()
		{
			this.moodSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "hungry", DataFormat = DataFormat.TwosComplement)]
		public uint hungry
		{
			get
			{
				return this._hungry ?? 0U;
			}
			set
			{
				this._hungry = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hungrySpecified
		{
			get
			{
				return this._hungry != null;
			}
			set
			{
				bool flag = value == (this._hungry == null);
				if (flag)
				{
					this._hungry = (value ? new uint?(this.hungry) : null);
				}
			}
		}

		private bool ShouldSerializehungry()
		{
			return this.hungrySpecified;
		}

		private void Resethungry()
		{
			this.hungrySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _mood;

		private uint? _hungry;

		private IExtension extensionObject;
	}
}
