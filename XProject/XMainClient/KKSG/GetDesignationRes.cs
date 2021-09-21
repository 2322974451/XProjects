using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200010C RID: 268
	[ProtoContract(Name = "GetDesignationRes")]
	[Serializable]
	public class GetDesignationRes : IExtensible
	{
		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x060010EC RID: 4332 RVA: 0x00022A08 File Offset: 0x00020C08
		// (set) Token: 0x060010ED RID: 4333 RVA: 0x00022A34 File Offset: 0x00020C34
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

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x060010EE RID: 4334 RVA: 0x00022A44 File Offset: 0x00020C44
		// (set) Token: 0x060010EF RID: 4335 RVA: 0x00022A64 File Offset: 0x00020C64
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

		// Token: 0x060010F0 RID: 4336 RVA: 0x00022AA8 File Offset: 0x00020CA8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x00022AC0 File Offset: 0x00020CC0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000573 RID: 1395
		// (get) Token: 0x060010F2 RID: 4338 RVA: 0x00022ACC File Offset: 0x00020CCC
		// (set) Token: 0x060010F3 RID: 4339 RVA: 0x00022AF8 File Offset: 0x00020CF8
		[ProtoMember(2, IsRequired = false, Name = "coverDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint coverDesignationID
		{
			get
			{
				return this._coverDesignationID ?? 0U;
			}
			set
			{
				this._coverDesignationID = new uint?(value);
			}
		}

		// Token: 0x17000574 RID: 1396
		// (get) Token: 0x060010F4 RID: 4340 RVA: 0x00022B08 File Offset: 0x00020D08
		// (set) Token: 0x060010F5 RID: 4341 RVA: 0x00022B28 File Offset: 0x00020D28
		[XmlIgnore]
		[Browsable(false)]
		public bool coverDesignationIDSpecified
		{
			get
			{
				return this._coverDesignationID != null;
			}
			set
			{
				bool flag = value == (this._coverDesignationID == null);
				if (flag)
				{
					this._coverDesignationID = (value ? new uint?(this.coverDesignationID) : null);
				}
			}
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x00022B6C File Offset: 0x00020D6C
		private bool ShouldSerializecoverDesignationID()
		{
			return this.coverDesignationIDSpecified;
		}

		// Token: 0x060010F7 RID: 4343 RVA: 0x00022B84 File Offset: 0x00020D84
		private void ResetcoverDesignationID()
		{
			this.coverDesignationIDSpecified = false;
		}

		// Token: 0x17000575 RID: 1397
		// (get) Token: 0x060010F8 RID: 4344 RVA: 0x00022B90 File Offset: 0x00020D90
		// (set) Token: 0x060010F9 RID: 4345 RVA: 0x00022BBC File Offset: 0x00020DBC
		[ProtoMember(3, IsRequired = false, Name = "abilityDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint abilityDesignationID
		{
			get
			{
				return this._abilityDesignationID ?? 0U;
			}
			set
			{
				this._abilityDesignationID = new uint?(value);
			}
		}

		// Token: 0x17000576 RID: 1398
		// (get) Token: 0x060010FA RID: 4346 RVA: 0x00022BCC File Offset: 0x00020DCC
		// (set) Token: 0x060010FB RID: 4347 RVA: 0x00022BEC File Offset: 0x00020DEC
		[XmlIgnore]
		[Browsable(false)]
		public bool abilityDesignationIDSpecified
		{
			get
			{
				return this._abilityDesignationID != null;
			}
			set
			{
				bool flag = value == (this._abilityDesignationID == null);
				if (flag)
				{
					this._abilityDesignationID = (value ? new uint?(this.abilityDesignationID) : null);
				}
			}
		}

		// Token: 0x060010FC RID: 4348 RVA: 0x00022C30 File Offset: 0x00020E30
		private bool ShouldSerializeabilityDesignationID()
		{
			return this.abilityDesignationIDSpecified;
		}

		// Token: 0x060010FD RID: 4349 RVA: 0x00022C48 File Offset: 0x00020E48
		private void ResetabilityDesignationID()
		{
			this.abilityDesignationIDSpecified = false;
		}

		// Token: 0x17000577 RID: 1399
		// (get) Token: 0x060010FE RID: 4350 RVA: 0x00022C54 File Offset: 0x00020E54
		[ProtoMember(4, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<bool> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		// Token: 0x17000578 RID: 1400
		// (get) Token: 0x060010FF RID: 4351 RVA: 0x00022C6C File Offset: 0x00020E6C
		// (set) Token: 0x06001100 RID: 4352 RVA: 0x00022C98 File Offset: 0x00020E98
		[ProtoMember(5, IsRequired = false, Name = "maxPPT", DataFormat = DataFormat.TwosComplement)]
		public uint maxPPT
		{
			get
			{
				return this._maxPPT ?? 0U;
			}
			set
			{
				this._maxPPT = new uint?(value);
			}
		}

		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x06001101 RID: 4353 RVA: 0x00022CA8 File Offset: 0x00020EA8
		// (set) Token: 0x06001102 RID: 4354 RVA: 0x00022CC8 File Offset: 0x00020EC8
		[XmlIgnore]
		[Browsable(false)]
		public bool maxPPTSpecified
		{
			get
			{
				return this._maxPPT != null;
			}
			set
			{
				bool flag = value == (this._maxPPT == null);
				if (flag)
				{
					this._maxPPT = (value ? new uint?(this.maxPPT) : null);
				}
			}
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x00022D0C File Offset: 0x00020F0C
		private bool ShouldSerializemaxPPT()
		{
			return this.maxPPTSpecified;
		}

		// Token: 0x06001104 RID: 4356 RVA: 0x00022D24 File Offset: 0x00020F24
		private void ResetmaxPPT()
		{
			this.maxPPTSpecified = false;
		}

		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x06001105 RID: 4357 RVA: 0x00022D30 File Offset: 0x00020F30
		// (set) Token: 0x06001106 RID: 4358 RVA: 0x00022D51 File Offset: 0x00020F51
		[ProtoMember(6, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x06001107 RID: 4359 RVA: 0x00022D5C File Offset: 0x00020F5C
		// (set) Token: 0x06001108 RID: 4360 RVA: 0x00022D78 File Offset: 0x00020F78
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06001109 RID: 4361 RVA: 0x00022DA8 File Offset: 0x00020FA8
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x0600110A RID: 4362 RVA: 0x00022DC0 File Offset: 0x00020FC0
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x0600110B RID: 4363 RVA: 0x00022DCC File Offset: 0x00020FCC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400043D RID: 1085
		private ErrorCode? _result;

		// Token: 0x0400043E RID: 1086
		private uint? _coverDesignationID;

		// Token: 0x0400043F RID: 1087
		private uint? _abilityDesignationID;

		// Token: 0x04000440 RID: 1088
		private readonly List<bool> _dataList = new List<bool>();

		// Token: 0x04000441 RID: 1089
		private uint? _maxPPT;

		// Token: 0x04000442 RID: 1090
		private string _name;

		// Token: 0x04000443 RID: 1091
		private IExtension extensionObject;
	}
}
