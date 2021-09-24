using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "Attribute")]
	[Serializable]
	public class Attribute : IExtensible
	{

		[ProtoMember(1, Name = "basicAttribute", DataFormat = DataFormat.TwosComplement)]
		public List<double> basicAttribute
		{
			get
			{
				return this._basicAttribute;
			}
		}

		[ProtoMember(2, Name = "percentAttribute", DataFormat = DataFormat.TwosComplement)]
		public List<double> percentAttribute
		{
			get
			{
				return this._percentAttribute;
			}
		}

		[ProtoMember(3, Name = "attrID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> attrID
		{
			get
			{
				return this._attrID;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<double> _basicAttribute = new List<double>();

		private readonly List<double> _percentAttribute = new List<double>();

		private readonly List<uint> _attrID = new List<uint>();

		private IExtension extensionObject;
	}
}
