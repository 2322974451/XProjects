using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StartPlantRes")]
	[Serializable]
	public class StartPlantRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "grow_state", DataFormat = DataFormat.TwosComplement)]
		public PlantGrowState grow_state
		{
			get
			{
				return this._grow_state ?? PlantGrowState.growDrought;
			}
			set
			{
				this._grow_state = new PlantGrowState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool grow_stateSpecified
		{
			get
			{
				return this._grow_state != null;
			}
			set
			{
				bool flag = value == (this._grow_state == null);
				if (flag)
				{
					this._grow_state = (value ? new PlantGrowState?(this.grow_state) : null);
				}
			}
		}

		private bool ShouldSerializegrow_state()
		{
			return this.grow_stateSpecified;
		}

		private void Resetgrow_state()
		{
			this.grow_stateSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private PlantGrowState? _grow_state;

		private IExtension extensionObject;
	}
}
