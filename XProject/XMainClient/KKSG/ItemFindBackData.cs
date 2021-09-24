using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemFindBackData")]
	[Serializable]
	public class ItemFindBackData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isDayFirstNofity", DataFormat = DataFormat.Default)]
		public bool isDayFirstNofity
		{
			get
			{
				return this._isDayFirstNofity ?? false;
			}
			set
			{
				this._isDayFirstNofity = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isDayFirstNofitySpecified
		{
			get
			{
				return this._isDayFirstNofity != null;
			}
			set
			{
				bool flag = value == (this._isDayFirstNofity == null);
				if (flag)
				{
					this._isDayFirstNofity = (value ? new bool?(this.isDayFirstNofity) : null);
				}
			}
		}

		private bool ShouldSerializeisDayFirstNofity()
		{
			return this.isDayFirstNofitySpecified;
		}

		private void ResetisDayFirstNofity()
		{
			this.isDayFirstNofitySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isDayFirstNofity;

		private IExtension extensionObject;
	}
}
