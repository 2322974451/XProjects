using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WordNotify")]
	[Serializable]
	public class WordNotify : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "hint", DataFormat = DataFormat.Default)]
		public string hint
		{
			get
			{
				return this._hint ?? "";
			}
			set
			{
				this._hint = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hintSpecified
		{
			get
			{
				return this._hint != null;
			}
			set
			{
				bool flag = value == (this._hint == null);
				if (flag)
				{
					this._hint = (value ? this.hint : null);
				}
			}
		}

		private bool ShouldSerializehint()
		{
			return this.hintSpecified;
		}

		private void Resethint()
		{
			this.hintSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _hint;

		private IExtension extensionObject;
	}
}
