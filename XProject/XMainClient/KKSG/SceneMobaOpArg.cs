using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SceneMobaOpArg")]
	[Serializable]
	public class SceneMobaOpArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public MobaOp op
		{
			get
			{
				return this._op ?? MobaOp.MobaOp_LevelSkill;
			}
			set
			{
				this._op = new MobaOp?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new MobaOp?(this.op) : null);
				}
			}
		}

		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		private void Resetop()
		{
			this.opSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public uint param
		{
			get
			{
				return this._param ?? 0U;
			}
			set
			{
				this._param = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new uint?(this.param) : null);
				}
			}
		}

		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private MobaOp? _op;

		private uint? _param;

		private IExtension extensionObject;
	}
}
