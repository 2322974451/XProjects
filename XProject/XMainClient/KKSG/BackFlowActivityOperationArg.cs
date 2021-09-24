using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BackFlowActivityOperationArg")]
	[Serializable]
	public class BackFlowActivityOperationArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public BackFlowActOp type
		{
			get
			{
				return this._type ?? BackFlowActOp.BackFlowAct_TreasureData;
			}
			set
			{
				this._type = new BackFlowActOp?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new BackFlowActOp?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "arg", DataFormat = DataFormat.TwosComplement)]
		public uint arg
		{
			get
			{
				return this._arg ?? 0U;
			}
			set
			{
				this._arg = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool argSpecified
		{
			get
			{
				return this._arg != null;
			}
			set
			{
				bool flag = value == (this._arg == null);
				if (flag)
				{
					this._arg = (value ? new uint?(this.arg) : null);
				}
			}
		}

		private bool ShouldSerializearg()
		{
			return this.argSpecified;
		}

		private void Resetarg()
		{
			this.argSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private BackFlowActOp? _type;

		private uint? _arg;

		private IExtension extensionObject;
	}
}
