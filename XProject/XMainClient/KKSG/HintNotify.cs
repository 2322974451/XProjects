using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HintNotify")]
	[Serializable]
	public class HintNotify : IExtensible
	{

		[ProtoMember(1, Name = "systemid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> systemid
		{
			get
			{
				return this._systemid;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "isremove", DataFormat = DataFormat.Default)]
		public bool isremove
		{
			get
			{
				return this._isremove ?? false;
			}
			set
			{
				this._isremove = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isremoveSpecified
		{
			get
			{
				return this._isremove != null;
			}
			set
			{
				bool flag = value == (this._isremove == null);
				if (flag)
				{
					this._isremove = (value ? new bool?(this.isremove) : null);
				}
			}
		}

		private bool ShouldSerializeisremove()
		{
			return this.isremoveSpecified;
		}

		private void Resetisremove()
		{
			this.isremoveSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _systemid = new List<uint>();

		private bool? _isremove;

		private IExtension extensionObject;
	}
}
