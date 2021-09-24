using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RetAutoPlay")]
	[Serializable]
	public class RetAutoPlay : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "succ", DataFormat = DataFormat.Default)]
		public bool succ
		{
			get
			{
				return this._succ ?? false;
			}
			set
			{
				this._succ = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool succSpecified
		{
			get
			{
				return this._succ != null;
			}
			set
			{
				bool flag = value == (this._succ == null);
				if (flag)
				{
					this._succ = (value ? new bool?(this.succ) : null);
				}
			}
		}

		private bool ShouldSerializesucc()
		{
			return this.succSpecified;
		}

		private void Resetsucc()
		{
			this.succSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _succ;

		private IExtension extensionObject;
	}
}
