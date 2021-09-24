using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EnhanceItemRes")]
	[Serializable]
	public class EnhanceItemRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		[ProtoMember(2, Name = "comagates", DataFormat = DataFormat.Default)]
		public List<ComAgate> comagates
		{
			get
			{
				return this._comagates;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "isEnd", DataFormat = DataFormat.Default)]
		public bool isEnd
		{
			get
			{
				return this._isEnd ?? false;
			}
			set
			{
				this._isEnd = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isEndSpecified
		{
			get
			{
				return this._isEnd != null;
			}
			set
			{
				bool flag = value == (this._isEnd == null);
				if (flag)
				{
					this._isEnd = (value ? new bool?(this.isEnd) : null);
				}
			}
		}

		private bool ShouldSerializeisEnd()
		{
			return this.isEndSpecified;
		}

		private void ResetisEnd()
		{
			this.isEndSpecified = false;
		}

		[ProtoMember(4, Name = "nextAttrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> nextAttrs
		{
			get
			{
				return this._nextAttrs;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _ErrorCode;

		private readonly List<ComAgate> _comagates = new List<ComAgate>();

		private bool? _isEnd;

		private readonly List<AttributeInfo> _nextAttrs = new List<AttributeInfo>();

		private IExtension extensionObject;
	}
}
