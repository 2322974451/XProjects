using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ActiveCookbookRes")]
	[Serializable]
	public class ActiveCookbookRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "food_id", DataFormat = DataFormat.TwosComplement)]
		public uint food_id
		{
			get
			{
				return this._food_id ?? 0U;
			}
			set
			{
				this._food_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool food_idSpecified
		{
			get
			{
				return this._food_id != null;
			}
			set
			{
				bool flag = value == (this._food_id == null);
				if (flag)
				{
					this._food_id = (value ? new uint?(this.food_id) : null);
				}
			}
		}

		private bool ShouldSerializefood_id()
		{
			return this.food_idSpecified;
		}

		private void Resetfood_id()
		{
			this.food_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _food_id;

		private IExtension extensionObject;
	}
}
