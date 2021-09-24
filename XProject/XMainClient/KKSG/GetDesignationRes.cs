using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDesignationRes")]
	[Serializable]
	public class GetDesignationRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "coverDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint coverDesignationID
		{
			get
			{
				return this._coverDesignationID ?? 0U;
			}
			set
			{
				this._coverDesignationID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool coverDesignationIDSpecified
		{
			get
			{
				return this._coverDesignationID != null;
			}
			set
			{
				bool flag = value == (this._coverDesignationID == null);
				if (flag)
				{
					this._coverDesignationID = (value ? new uint?(this.coverDesignationID) : null);
				}
			}
		}

		private bool ShouldSerializecoverDesignationID()
		{
			return this.coverDesignationIDSpecified;
		}

		private void ResetcoverDesignationID()
		{
			this.coverDesignationIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "abilityDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint abilityDesignationID
		{
			get
			{
				return this._abilityDesignationID ?? 0U;
			}
			set
			{
				this._abilityDesignationID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool abilityDesignationIDSpecified
		{
			get
			{
				return this._abilityDesignationID != null;
			}
			set
			{
				bool flag = value == (this._abilityDesignationID == null);
				if (flag)
				{
					this._abilityDesignationID = (value ? new uint?(this.abilityDesignationID) : null);
				}
			}
		}

		private bool ShouldSerializeabilityDesignationID()
		{
			return this.abilityDesignationIDSpecified;
		}

		private void ResetabilityDesignationID()
		{
			this.abilityDesignationIDSpecified = false;
		}

		[ProtoMember(4, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<bool> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "maxPPT", DataFormat = DataFormat.TwosComplement)]
		public uint maxPPT
		{
			get
			{
				return this._maxPPT ?? 0U;
			}
			set
			{
				this._maxPPT = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxPPTSpecified
		{
			get
			{
				return this._maxPPT != null;
			}
			set
			{
				bool flag = value == (this._maxPPT == null);
				if (flag)
				{
					this._maxPPT = (value ? new uint?(this.maxPPT) : null);
				}
			}
		}

		private bool ShouldSerializemaxPPT()
		{
			return this.maxPPTSpecified;
		}

		private void ResetmaxPPT()
		{
			this.maxPPTSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _coverDesignationID;

		private uint? _abilityDesignationID;

		private readonly List<bool> _dataList = new List<bool>();

		private uint? _maxPPT;

		private string _name;

		private IExtension extensionObject;
	}
}
