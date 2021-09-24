using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AllBuffsInfo")]
	[Serializable]
	public class AllBuffsInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "BuffState", DataFormat = DataFormat.TwosComplement)]
		public uint BuffState
		{
			get
			{
				return this._BuffState ?? 0U;
			}
			set
			{
				this._BuffState = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool BuffStateSpecified
		{
			get
			{
				return this._BuffState != null;
			}
			set
			{
				bool flag = value == (this._BuffState == null);
				if (flag)
				{
					this._BuffState = (value ? new uint?(this.BuffState) : null);
				}
			}
		}

		private bool ShouldSerializeBuffState()
		{
			return this.BuffStateSpecified;
		}

		private void ResetBuffState()
		{
			this.BuffStateSpecified = false;
		}

		[ProtoMember(2, Name = "StateParamIndex", DataFormat = DataFormat.TwosComplement)]
		public List<int> StateParamIndex
		{
			get
			{
				return this._StateParamIndex;
			}
		}

		[ProtoMember(3, Name = "StateParamValues", DataFormat = DataFormat.TwosComplement)]
		public List<int> StateParamValues
		{
			get
			{
				return this._StateParamValues;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _BuffState;

		private readonly List<int> _StateParamIndex = new List<int>();

		private readonly List<int> _StateParamValues = new List<int>();

		private IExtension extensionObject;
	}
}
