using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReplyPartyExchangeItemOptRes")]
	[Serializable]
	public class ReplyPartyExchangeItemOptRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "lauch_role_id", DataFormat = DataFormat.TwosComplement)]
		public uint lauch_role_id
		{
			get
			{
				return this._lauch_role_id ?? 0U;
			}
			set
			{
				this._lauch_role_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_role_idSpecified
		{
			get
			{
				return this._lauch_role_id != null;
			}
			set
			{
				bool flag = value == (this._lauch_role_id == null);
				if (flag)
				{
					this._lauch_role_id = (value ? new uint?(this.lauch_role_id) : null);
				}
			}
		}

		private bool ShouldSerializelauch_role_id()
		{
			return this.lauch_role_idSpecified;
		}

		private void Resetlauch_role_id()
		{
			this.lauch_role_idSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lauch_item_id", DataFormat = DataFormat.TwosComplement)]
		public uint lauch_item_id
		{
			get
			{
				return this._lauch_item_id ?? 0U;
			}
			set
			{
				this._lauch_item_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_item_idSpecified
		{
			get
			{
				return this._lauch_item_id != null;
			}
			set
			{
				bool flag = value == (this._lauch_item_id == null);
				if (flag)
				{
					this._lauch_item_id = (value ? new uint?(this.lauch_item_id) : null);
				}
			}
		}

		private bool ShouldSerializelauch_item_id()
		{
			return this.lauch_item_idSpecified;
		}

		private void Resetlauch_item_id()
		{
			this.lauch_item_idSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "lauch_status", DataFormat = DataFormat.Default)]
		public bool lauch_status
		{
			get
			{
				return this._lauch_status ?? false;
			}
			set
			{
				this._lauch_status = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_statusSpecified
		{
			get
			{
				return this._lauch_status != null;
			}
			set
			{
				bool flag = value == (this._lauch_status == null);
				if (flag)
				{
					this._lauch_status = (value ? new bool?(this.lauch_status) : null);
				}
			}
		}

		private bool ShouldSerializelauch_status()
		{
			return this.lauch_statusSpecified;
		}

		private void Resetlauch_status()
		{
			this.lauch_statusSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "target_role_id", DataFormat = DataFormat.TwosComplement)]
		public uint target_role_id
		{
			get
			{
				return this._target_role_id ?? 0U;
			}
			set
			{
				this._target_role_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool target_role_idSpecified
		{
			get
			{
				return this._target_role_id != null;
			}
			set
			{
				bool flag = value == (this._target_role_id == null);
				if (flag)
				{
					this._target_role_id = (value ? new uint?(this.target_role_id) : null);
				}
			}
		}

		private bool ShouldSerializetarget_role_id()
		{
			return this.target_role_idSpecified;
		}

		private void Resettarget_role_id()
		{
			this.target_role_idSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "target_item_id", DataFormat = DataFormat.TwosComplement)]
		public uint target_item_id
		{
			get
			{
				return this._target_item_id ?? 0U;
			}
			set
			{
				this._target_item_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool target_item_idSpecified
		{
			get
			{
				return this._target_item_id != null;
			}
			set
			{
				bool flag = value == (this._target_item_id == null);
				if (flag)
				{
					this._target_item_id = (value ? new uint?(this.target_item_id) : null);
				}
			}
		}

		private bool ShouldSerializetarget_item_id()
		{
			return this.target_item_idSpecified;
		}

		private void Resettarget_item_id()
		{
			this.target_item_idSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "target_status", DataFormat = DataFormat.TwosComplement)]
		public uint target_status
		{
			get
			{
				return this._target_status ?? 0U;
			}
			set
			{
				this._target_status = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool target_statusSpecified
		{
			get
			{
				return this._target_status != null;
			}
			set
			{
				bool flag = value == (this._target_status == null);
				if (flag)
				{
					this._target_status = (value ? new uint?(this.target_status) : null);
				}
			}
		}

		private bool ShouldSerializetarget_status()
		{
			return this.target_statusSpecified;
		}

		private void Resettarget_status()
		{
			this.target_statusSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _lauch_role_id;

		private uint? _lauch_item_id;

		private bool? _lauch_status;

		private uint? _target_role_id;

		private uint? _target_item_id;

		private uint? _target_status;

		private IExtension extensionObject;
	}
}
