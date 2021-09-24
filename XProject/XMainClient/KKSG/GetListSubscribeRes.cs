using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetListSubscribeRes")]
	[Serializable]
	public class GetListSubscribeRes : IExtensible
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

		[ProtoMember(2, Name = "list", DataFormat = DataFormat.Default)]
		public List<SubScribe> list
		{
			get
			{
				return this._list;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "more", DataFormat = DataFormat.Default)]
		public bool more
		{
			get
			{
				return this._more ?? false;
			}
			set
			{
				this._more = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool moreSpecified
		{
			get
			{
				return this._more != null;
			}
			set
			{
				bool flag = value == (this._more == null);
				if (flag)
				{
					this._more = (value ? new bool?(this.more) : null);
				}
			}
		}

		private bool ShouldSerializemore()
		{
			return this.moreSpecified;
		}

		private void Resetmore()
		{
			this.moreSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<SubScribe> _list = new List<SubScribe>();

		private bool? _more;

		private IExtension extensionObject;
	}
}
