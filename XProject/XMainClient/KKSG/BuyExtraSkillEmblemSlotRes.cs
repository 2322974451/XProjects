using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BuyExtraSkillEmblemSlotRes")]
	[Serializable]
	public class BuyExtraSkillEmblemSlotRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "extraSkillEmblemSlot", DataFormat = DataFormat.TwosComplement)]
		public uint extraSkillEmblemSlot
		{
			get
			{
				return this._extraSkillEmblemSlot ?? 0U;
			}
			set
			{
				this._extraSkillEmblemSlot = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool extraSkillEmblemSlotSpecified
		{
			get
			{
				return this._extraSkillEmblemSlot != null;
			}
			set
			{
				bool flag = value == (this._extraSkillEmblemSlot == null);
				if (flag)
				{
					this._extraSkillEmblemSlot = (value ? new uint?(this.extraSkillEmblemSlot) : null);
				}
			}
		}

		private bool ShouldSerializeextraSkillEmblemSlot()
		{
			return this.extraSkillEmblemSlotSpecified;
		}

		private void ResetextraSkillEmblemSlot()
		{
			this.extraSkillEmblemSlotSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _extraSkillEmblemSlot;

		private IExtension extensionObject;
	}
}
