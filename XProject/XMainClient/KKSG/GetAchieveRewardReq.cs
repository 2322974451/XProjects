using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetAchieveRewardReq")]
	[Serializable]
	public class GetAchieveRewardReq : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "achieveID", DataFormat = DataFormat.TwosComplement)]
		public uint achieveID
		{
			get
			{
				return this._achieveID ?? 0U;
			}
			set
			{
				this._achieveID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool achieveIDSpecified
		{
			get
			{
				return this._achieveID != null;
			}
			set
			{
				bool flag = value == (this._achieveID == null);
				if (flag)
				{
					this._achieveID = (value ? new uint?(this.achieveID) : null);
				}
			}
		}

		private bool ShouldSerializeachieveID()
		{
			return this.achieveIDSpecified;
		}

		private void ResetachieveID()
		{
			this.achieveIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _achieveID;

		private IExtension extensionObject;
	}
}
