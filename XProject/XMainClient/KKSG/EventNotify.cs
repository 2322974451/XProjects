using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EventNotify")]
	[Serializable]
	public class EventNotify : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "notify", DataFormat = DataFormat.Default)]
		public string notify
		{
			get
			{
				return this._notify ?? "";
			}
			set
			{
				this._notify = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool notifySpecified
		{
			get
			{
				return this._notify != null;
			}
			set
			{
				bool flag = value == (this._notify == null);
				if (flag)
				{
					this._notify = (value ? this.notify : null);
				}
			}
		}

		private bool ShouldSerializenotify()
		{
			return this.notifySpecified;
		}

		private void Resetnotify()
		{
			this.notifySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _notify;

		private IExtension extensionObject;
	}
}
