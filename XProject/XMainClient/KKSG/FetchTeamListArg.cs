using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FetchTeamListArg")]
	[Serializable]
	public class FetchTeamListArg : IExtensible
	{

		[ProtoMember(1, Name = "categoryID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> categoryID
		{
			get
			{
				return this._categoryID;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "expID", DataFormat = DataFormat.TwosComplement)]
		public uint expID
		{
			get
			{
				return this._expID ?? 0U;
			}
			set
			{
				this._expID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expIDSpecified
		{
			get
			{
				return this._expID != null;
			}
			set
			{
				bool flag = value == (this._expID == null);
				if (flag)
				{
					this._expID = (value ? new uint?(this.expID) : null);
				}
			}
		}

		private bool ShouldSerializeexpID()
		{
			return this.expIDSpecified;
		}

		private void ResetexpID()
		{
			this.expIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _categoryID = new List<uint>();

		private uint? _expID;

		private IExtension extensionObject;
	}
}
