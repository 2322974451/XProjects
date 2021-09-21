using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200026C RID: 620
	[ProtoContract(Name = "GardenCookingFoodRes")]
	[Serializable]
	public class GardenCookingFoodRes : IExtensible
	{
		// Token: 0x17000AC1 RID: 2753
		// (get) Token: 0x06002294 RID: 8852 RVA: 0x000438F0 File Offset: 0x00041AF0
		// (set) Token: 0x06002295 RID: 8853 RVA: 0x0004391C File Offset: 0x00041B1C
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

		// Token: 0x17000AC2 RID: 2754
		// (get) Token: 0x06002296 RID: 8854 RVA: 0x0004392C File Offset: 0x00041B2C
		// (set) Token: 0x06002297 RID: 8855 RVA: 0x0004394C File Offset: 0x00041B4C
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

		// Token: 0x06002298 RID: 8856 RVA: 0x00043990 File Offset: 0x00041B90
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002299 RID: 8857 RVA: 0x000439A8 File Offset: 0x00041BA8
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000AC3 RID: 2755
		// (get) Token: 0x0600229A RID: 8858 RVA: 0x000439B4 File Offset: 0x00041BB4
		[ProtoMember(2, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x17000AC4 RID: 2756
		// (get) Token: 0x0600229B RID: 8859 RVA: 0x000439CC File Offset: 0x00041BCC
		// (set) Token: 0x0600229C RID: 8860 RVA: 0x000439F8 File Offset: 0x00041BF8
		[ProtoMember(3, IsRequired = false, Name = "cooking_level", DataFormat = DataFormat.TwosComplement)]
		public uint cooking_level
		{
			get
			{
				return this._cooking_level ?? 0U;
			}
			set
			{
				this._cooking_level = new uint?(value);
			}
		}

		// Token: 0x17000AC5 RID: 2757
		// (get) Token: 0x0600229D RID: 8861 RVA: 0x00043A08 File Offset: 0x00041C08
		// (set) Token: 0x0600229E RID: 8862 RVA: 0x00043A28 File Offset: 0x00041C28
		[XmlIgnore]
		[Browsable(false)]
		public bool cooking_levelSpecified
		{
			get
			{
				return this._cooking_level != null;
			}
			set
			{
				bool flag = value == (this._cooking_level == null);
				if (flag)
				{
					this._cooking_level = (value ? new uint?(this.cooking_level) : null);
				}
			}
		}

		// Token: 0x0600229F RID: 8863 RVA: 0x00043A6C File Offset: 0x00041C6C
		private bool ShouldSerializecooking_level()
		{
			return this.cooking_levelSpecified;
		}

		// Token: 0x060022A0 RID: 8864 RVA: 0x00043A84 File Offset: 0x00041C84
		private void Resetcooking_level()
		{
			this.cooking_levelSpecified = false;
		}

		// Token: 0x17000AC6 RID: 2758
		// (get) Token: 0x060022A1 RID: 8865 RVA: 0x00043A90 File Offset: 0x00041C90
		// (set) Token: 0x060022A2 RID: 8866 RVA: 0x00043ABC File Offset: 0x00041CBC
		[ProtoMember(4, IsRequired = false, Name = "cooking_experiences", DataFormat = DataFormat.TwosComplement)]
		public uint cooking_experiences
		{
			get
			{
				return this._cooking_experiences ?? 0U;
			}
			set
			{
				this._cooking_experiences = new uint?(value);
			}
		}

		// Token: 0x17000AC7 RID: 2759
		// (get) Token: 0x060022A3 RID: 8867 RVA: 0x00043ACC File Offset: 0x00041CCC
		// (set) Token: 0x060022A4 RID: 8868 RVA: 0x00043AEC File Offset: 0x00041CEC
		[XmlIgnore]
		[Browsable(false)]
		public bool cooking_experiencesSpecified
		{
			get
			{
				return this._cooking_experiences != null;
			}
			set
			{
				bool flag = value == (this._cooking_experiences == null);
				if (flag)
				{
					this._cooking_experiences = (value ? new uint?(this.cooking_experiences) : null);
				}
			}
		}

		// Token: 0x060022A5 RID: 8869 RVA: 0x00043B30 File Offset: 0x00041D30
		private bool ShouldSerializecooking_experiences()
		{
			return this.cooking_experiencesSpecified;
		}

		// Token: 0x060022A6 RID: 8870 RVA: 0x00043B48 File Offset: 0x00041D48
		private void Resetcooking_experiences()
		{
			this.cooking_experiencesSpecified = false;
		}

		// Token: 0x060022A7 RID: 8871 RVA: 0x00043B54 File Offset: 0x00041D54
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000893 RID: 2195
		private ErrorCode? _result;

		// Token: 0x04000894 RID: 2196
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x04000895 RID: 2197
		private uint? _cooking_level;

		// Token: 0x04000896 RID: 2198
		private uint? _cooking_experiences;

		// Token: 0x04000897 RID: 2199
		private IExtension extensionObject;
	}
}
