using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PhotographEffect")]
	[Serializable]
	public class PhotographEffect : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, Name = "photograph_effect", DataFormat = DataFormat.TwosComplement)]
		public List<uint> photograph_effect
		{
			get
			{
				return this._photograph_effect;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "charm", DataFormat = DataFormat.TwosComplement)]
		public uint charm
		{
			get
			{
				return this._charm ?? 0U;
			}
			set
			{
				this._charm = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool charmSpecified
		{
			get
			{
				return this._charm != null;
			}
			set
			{
				bool flag = value == (this._charm == null);
				if (flag)
				{
					this._charm = (value ? new uint?(this.charm) : null);
				}
			}
		}

		private bool ShouldSerializecharm()
		{
			return this.charmSpecified;
		}

		private void Resetcharm()
		{
			this.charmSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<uint> _photograph_effect = new List<uint>();

		private uint? _charm;

		private IExtension extensionObject;
	}
}
