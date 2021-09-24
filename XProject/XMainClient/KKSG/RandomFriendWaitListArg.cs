using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RandomFriendWaitListArg")]
	[Serializable]
	public class RandomFriendWaitListArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "match", DataFormat = DataFormat.Default)]
		public string match
		{
			get
			{
				return this._match ?? "";
			}
			set
			{
				this._match = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool matchSpecified
		{
			get
			{
				return this._match != null;
			}
			set
			{
				bool flag = value == (this._match == null);
				if (flag)
				{
					this._match = (value ? this.match : null);
				}
			}
		}

		private bool ShouldSerializematch()
		{
			return this.matchSpecified;
		}

		private void Resetmatch()
		{
			this.matchSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _match;

		private IExtension extensionObject;
	}
}
