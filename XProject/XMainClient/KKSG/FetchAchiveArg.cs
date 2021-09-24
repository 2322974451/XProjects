using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FetchAchiveArg")]
	[Serializable]
	public class FetchAchiveArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "AchivementID", DataFormat = DataFormat.TwosComplement)]
		public uint AchivementID
		{
			get
			{
				return this._AchivementID ?? 0U;
			}
			set
			{
				this._AchivementID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool AchivementIDSpecified
		{
			get
			{
				return this._AchivementID != null;
			}
			set
			{
				bool flag = value == (this._AchivementID == null);
				if (flag)
				{
					this._AchivementID = (value ? new uint?(this.AchivementID) : null);
				}
			}
		}

		private bool ShouldSerializeAchivementID()
		{
			return this.AchivementIDSpecified;
		}

		private void ResetAchivementID()
		{
			this.AchivementIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _AchivementID;

		private IExtension extensionObject;
	}
}
