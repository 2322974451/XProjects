using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ExpFindBackArg")]
	[Serializable]
	public class ExpFindBackArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isFree", DataFormat = DataFormat.Default)]
		public bool isFree
		{
			get
			{
				return this._isFree ?? false;
			}
			set
			{
				this._isFree = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isFreeSpecified
		{
			get
			{
				return this._isFree != null;
			}
			set
			{
				bool flag = value == (this._isFree == null);
				if (flag)
				{
					this._isFree = (value ? new bool?(this.isFree) : null);
				}
			}
		}

		private bool ShouldSerializeisFree()
		{
			return this.isFreeSpecified;
		}

		private void ResetisFree()
		{
			this.isFreeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isFree;

		private IExtension extensionObject;
	}
}
