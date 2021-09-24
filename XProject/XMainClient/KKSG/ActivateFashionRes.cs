using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ActivateFashionRes")]
	[Serializable]
	public class ActivateFashionRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "active_count", DataFormat = DataFormat.TwosComplement)]
		public uint active_count
		{
			get
			{
				return this._active_count ?? 0U;
			}
			set
			{
				this._active_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool active_countSpecified
		{
			get
			{
				return this._active_count != null;
			}
			set
			{
				bool flag = value == (this._active_count == null);
				if (flag)
				{
					this._active_count = (value ? new uint?(this.active_count) : null);
				}
			}
		}

		private bool ShouldSerializeactive_count()
		{
			return this.active_countSpecified;
		}

		private void Resetactive_count()
		{
			this.active_countSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _active_count;

		private IExtension extensionObject;
	}
}
