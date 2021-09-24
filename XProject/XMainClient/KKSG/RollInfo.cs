using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RollInfo")]
	[Serializable]
	public class RollInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "rollValue", DataFormat = DataFormat.TwosComplement)]
		public uint rollValue
		{
			get
			{
				return this._rollValue ?? 0U;
			}
			set
			{
				this._rollValue = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rollValueSpecified
		{
			get
			{
				return this._rollValue != null;
			}
			set
			{
				bool flag = value == (this._rollValue == null);
				if (flag)
				{
					this._rollValue = (value ? new uint?(this.rollValue) : null);
				}
			}
		}

		private bool ShouldSerializerollValue()
		{
			return this.rollValueSpecified;
		}

		private void ResetrollValue()
		{
			this.rollValueSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleID;

		private uint? _rollValue;

		private IExtension extensionObject;
	}
}
