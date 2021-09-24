using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EffectData")]
	[Serializable]
	public class EffectData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "effectID", DataFormat = DataFormat.TwosComplement)]
		public uint effectID
		{
			get
			{
				return this._effectID ?? 0U;
			}
			set
			{
				this._effectID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool effectIDSpecified
		{
			get
			{
				return this._effectID != null;
			}
			set
			{
				bool flag = value == (this._effectID == null);
				if (flag)
				{
					this._effectID = (value ? new uint?(this.effectID) : null);
				}
			}
		}

		private bool ShouldSerializeeffectID()
		{
			return this.effectIDSpecified;
		}

		private void ReseteffectID()
		{
			this.effectIDSpecified = false;
		}

		[ProtoMember(2, Name = "multiParams", DataFormat = DataFormat.Default)]
		public List<EffectMultiParams> multiParams
		{
			get
			{
				return this._multiParams;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "isWork", DataFormat = DataFormat.Default)]
		public bool isWork
		{
			get
			{
				return this._isWork ?? false;
			}
			set
			{
				this._isWork = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isWorkSpecified
		{
			get
			{
				return this._isWork != null;
			}
			set
			{
				bool flag = value == (this._isWork == null);
				if (flag)
				{
					this._isWork = (value ? new bool?(this.isWork) : null);
				}
			}
		}

		private bool ShouldSerializeisWork()
		{
			return this.isWorkSpecified;
		}

		private void ResetisWork()
		{
			this.isWorkSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _effectID;

		private readonly List<EffectMultiParams> _multiParams = new List<EffectMultiParams>();

		private bool? _isWork;

		private IExtension extensionObject;
	}
}
