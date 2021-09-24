using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EffectMultiParams")]
	[Serializable]
	public class EffectMultiParams : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "IDType", DataFormat = DataFormat.TwosComplement)]
		public uint IDType
		{
			get
			{
				return this._IDType ?? 0U;
			}
			set
			{
				this._IDType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool IDTypeSpecified
		{
			get
			{
				return this._IDType != null;
			}
			set
			{
				bool flag = value == (this._IDType == null);
				if (flag)
				{
					this._IDType = (value ? new uint?(this.IDType) : null);
				}
			}
		}

		private bool ShouldSerializeIDType()
		{
			return this.IDTypeSpecified;
		}

		private void ResetIDType()
		{
			this.IDTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "ID", DataFormat = DataFormat.TwosComplement)]
		public uint ID
		{
			get
			{
				return this._ID ?? 0U;
			}
			set
			{
				this._ID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool IDSpecified
		{
			get
			{
				return this._ID != null;
			}
			set
			{
				bool flag = value == (this._ID == null);
				if (flag)
				{
					this._ID = (value ? new uint?(this.ID) : null);
				}
			}
		}

		private bool ShouldSerializeID()
		{
			return this.IDSpecified;
		}

		private void ResetID()
		{
			this.IDSpecified = false;
		}

		[ProtoMember(3, Name = "effectParams", DataFormat = DataFormat.TwosComplement)]
		public List<int> effectParams
		{
			get
			{
				return this._effectParams;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _IDType;

		private uint? _ID;

		private readonly List<int> _effectParams = new List<int>();

		private IExtension extensionObject;
	}
}
