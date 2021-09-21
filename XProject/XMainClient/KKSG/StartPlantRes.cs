using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200024D RID: 589
	[ProtoContract(Name = "StartPlantRes")]
	[Serializable]
	public class StartPlantRes : IExtensible
	{
		// Token: 0x17000A47 RID: 2631
		// (get) Token: 0x060020F6 RID: 8438 RVA: 0x0004090C File Offset: 0x0003EB0C
		// (set) Token: 0x060020F7 RID: 8439 RVA: 0x00040938 File Offset: 0x0003EB38
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

		// Token: 0x17000A48 RID: 2632
		// (get) Token: 0x060020F8 RID: 8440 RVA: 0x00040948 File Offset: 0x0003EB48
		// (set) Token: 0x060020F9 RID: 8441 RVA: 0x00040968 File Offset: 0x0003EB68
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

		// Token: 0x060020FA RID: 8442 RVA: 0x000409AC File Offset: 0x0003EBAC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060020FB RID: 8443 RVA: 0x000409C4 File Offset: 0x0003EBC4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000A49 RID: 2633
		// (get) Token: 0x060020FC RID: 8444 RVA: 0x000409D0 File Offset: 0x0003EBD0
		// (set) Token: 0x060020FD RID: 8445 RVA: 0x000409FC File Offset: 0x0003EBFC
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

		// Token: 0x17000A4A RID: 2634
		// (get) Token: 0x060020FE RID: 8446 RVA: 0x00040A0C File Offset: 0x0003EC0C
		// (set) Token: 0x060020FF RID: 8447 RVA: 0x00040A2C File Offset: 0x0003EC2C
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

		// Token: 0x06002100 RID: 8448 RVA: 0x00040A70 File Offset: 0x0003EC70
		private bool ShouldSerializegrow_state()
		{
			return this.grow_stateSpecified;
		}

		// Token: 0x06002101 RID: 8449 RVA: 0x00040A88 File Offset: 0x0003EC88
		private void Resetgrow_state()
		{
			this.grow_stateSpecified = false;
		}

		// Token: 0x06002102 RID: 8450 RVA: 0x00040A94 File Offset: 0x0003EC94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000833 RID: 2099
		private ErrorCode? _result;

		// Token: 0x04000834 RID: 2100
		private PlantGrowState? _grow_state;

		// Token: 0x04000835 RID: 2101
		private IExtension extensionObject;
	}
}
