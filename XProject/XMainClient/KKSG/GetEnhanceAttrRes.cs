using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetEnhanceAttrRes")]
	[Serializable]
	public class GetEnhanceAttrRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isEnd", DataFormat = DataFormat.Default)]
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

		[ProtoMember(2, Name = "attrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> attrs
		{
			get
			{
				return this._attrs;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isEnd;

		private readonly List<AttributeInfo> _attrs = new List<AttributeInfo>();

		private IExtension extensionObject;
	}
}
