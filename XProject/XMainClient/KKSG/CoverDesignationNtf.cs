using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CoverDesignationNtf")]
	[Serializable]
	public class CoverDesignationNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "designationID", DataFormat = DataFormat.TwosComplement)]
		public uint designationID
		{
			get
			{
				return this._designationID ?? 0U;
			}
			set
			{
				this._designationID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool designationIDSpecified
		{
			get
			{
				return this._designationID != null;
			}
			set
			{
				bool flag = value == (this._designationID == null);
				if (flag)
				{
					this._designationID = (value ? new uint?(this.designationID) : null);
				}
			}
		}

		private bool ShouldSerializedesignationID()
		{
			return this.designationIDSpecified;
		}

		private void ResetdesignationID()
		{
			this.designationIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "desname", DataFormat = DataFormat.Default)]
		public string desname
		{
			get
			{
				return this._desname ?? "";
			}
			set
			{
				this._desname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool desnameSpecified
		{
			get
			{
				return this._desname != null;
			}
			set
			{
				bool flag = value == (this._desname == null);
				if (flag)
				{
					this._desname = (value ? this.desname : null);
				}
			}
		}

		private bool ShouldSerializedesname()
		{
			return this.desnameSpecified;
		}

		private void Resetdesname()
		{
			this.desnameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _designationID;

		private string _desname;

		private IExtension extensionObject;
	}
}
