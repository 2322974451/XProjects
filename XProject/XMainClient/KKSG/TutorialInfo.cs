using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TutorialInfo")]
	[Serializable]
	public class TutorialInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "tutorialID", DataFormat = DataFormat.TwosComplement)]
		public uint tutorialID
		{
			get
			{
				return this._tutorialID ?? 0U;
			}
			set
			{
				this._tutorialID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tutorialIDSpecified
		{
			get
			{
				return this._tutorialID != null;
			}
			set
			{
				bool flag = value == (this._tutorialID == null);
				if (flag)
				{
					this._tutorialID = (value ? new uint?(this.tutorialID) : null);
				}
			}
		}

		private bool ShouldSerializetutorialID()
		{
			return this.tutorialIDSpecified;
		}

		private void ResettutorialID()
		{
			this.tutorialIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _tutorialID;

		private IExtension extensionObject;
	}
}
