using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ActivateHairColorRes")]
	[Serializable]
	public class ActivateHairColorRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "hair_id", DataFormat = DataFormat.TwosComplement)]
		public uint hair_id
		{
			get
			{
				return this._hair_id ?? 0U;
			}
			set
			{
				this._hair_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hair_idSpecified
		{
			get
			{
				return this._hair_id != null;
			}
			set
			{
				bool flag = value == (this._hair_id == null);
				if (flag)
				{
					this._hair_id = (value ? new uint?(this.hair_id) : null);
				}
			}
		}

		private bool ShouldSerializehair_id()
		{
			return this.hair_idSpecified;
		}

		private void Resethair_id()
		{
			this.hair_idSpecified = false;
		}

		[ProtoMember(3, Name = "hair_colorid_list", DataFormat = DataFormat.TwosComplement)]
		public List<uint> hair_colorid_list
		{
			get
			{
				return this._hair_colorid_list;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _hair_id;

		private readonly List<uint> _hair_colorid_list = new List<uint>();

		private IExtension extensionObject;
	}
}
