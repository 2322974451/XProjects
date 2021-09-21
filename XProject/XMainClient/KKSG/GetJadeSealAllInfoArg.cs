using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000553 RID: 1363
	[ProtoContract(Name = "GetJadeSealAllInfoArg")]
	[Serializable]
	public class GetJadeSealAllInfoArg : IExtensible
	{
		// Token: 0x17001549 RID: 5449
		// (get) Token: 0x060045B0 RID: 17840 RVA: 0x000846F0 File Offset: 0x000828F0
		// (set) Token: 0x060045B1 RID: 17841 RVA: 0x0008471C File Offset: 0x0008291C
		[ProtoMember(1, IsRequired = false, Name = "equipPos", DataFormat = DataFormat.TwosComplement)]
		public int equipPos
		{
			get
			{
				return this._equipPos ?? 0;
			}
			set
			{
				this._equipPos = new int?(value);
			}
		}

		// Token: 0x1700154A RID: 5450
		// (get) Token: 0x060045B2 RID: 17842 RVA: 0x0008472C File Offset: 0x0008292C
		// (set) Token: 0x060045B3 RID: 17843 RVA: 0x0008474C File Offset: 0x0008294C
		[XmlIgnore]
		[Browsable(false)]
		public bool equipPosSpecified
		{
			get
			{
				return this._equipPos != null;
			}
			set
			{
				bool flag = value == (this._equipPos == null);
				if (flag)
				{
					this._equipPos = (value ? new int?(this.equipPos) : null);
				}
			}
		}

		// Token: 0x060045B4 RID: 17844 RVA: 0x00084790 File Offset: 0x00082990
		private bool ShouldSerializeequipPos()
		{
			return this.equipPosSpecified;
		}

		// Token: 0x060045B5 RID: 17845 RVA: 0x000847A8 File Offset: 0x000829A8
		private void ResetequipPos()
		{
			this.equipPosSpecified = false;
		}

		// Token: 0x060045B6 RID: 17846 RVA: 0x000847B4 File Offset: 0x000829B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001166 RID: 4454
		private int? _equipPos;

		// Token: 0x04001167 RID: 4455
		private IExtension extensionObject;
	}
}
