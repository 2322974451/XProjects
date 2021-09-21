using System;
using System.Reflection;

namespace ProtoBuf.Meta
{
	// Token: 0x02000886 RID: 2182
	public class CallbackSet
	{
		// Token: 0x060084A0 RID: 33952 RVA: 0x00103288 File Offset: 0x00101488
		internal CallbackSet(MetaType metaType)
		{
			bool flag = metaType == null;
			if (flag)
			{
				throw new ArgumentNullException("metaType");
			}
			this.metaType = metaType;
		}

		// Token: 0x170029EA RID: 10730
		internal MethodInfo this[TypeModel.CallbackType callbackType]
		{
			get
			{
				MethodInfo result;
				switch (callbackType)
				{
				case TypeModel.CallbackType.BeforeSerialize:
					result = this.beforeSerialize;
					break;
				case TypeModel.CallbackType.AfterSerialize:
					result = this.afterSerialize;
					break;
				case TypeModel.CallbackType.BeforeDeserialize:
					result = this.beforeDeserialize;
					break;
				case TypeModel.CallbackType.AfterDeserialize:
					result = this.afterDeserialize;
					break;
				default:
					throw new ArgumentException("Callback type not supported: " + callbackType.ToString(), "callbackType");
				}
				return result;
			}
		}

		// Token: 0x060084A2 RID: 33954 RVA: 0x00103328 File Offset: 0x00101528
		internal static bool CheckCallbackParameters(TypeModel model, MethodInfo method)
		{
			ParameterInfo[] parameters = method.GetParameters();
			for (int i = 0; i < parameters.Length; i++)
			{
				Type parameterType = parameters[i].ParameterType;
				bool flag = parameterType == model.MapType(typeof(SerializationContext));
				if (!flag)
				{
					bool flag2 = parameterType == model.MapType(typeof(Type));
					if (!flag2)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060084A3 RID: 33955 RVA: 0x001033A0 File Offset: 0x001015A0
		private MethodInfo SanityCheckCallback(TypeModel model, MethodInfo callback)
		{
			this.metaType.ThrowIfFrozen();
			bool flag = callback == null;
			MethodInfo result;
			if (flag)
			{
				result = callback;
			}
			else
			{
				bool isStatic = callback.IsStatic;
				if (isStatic)
				{
					throw new ArgumentException("Callbacks cannot be static", "callback");
				}
				bool flag2 = callback.ReturnType != model.MapType(typeof(void)) || !CallbackSet.CheckCallbackParameters(model, callback);
				if (flag2)
				{
					throw CallbackSet.CreateInvalidCallbackSignature(callback);
				}
				result = callback;
			}
			return result;
		}

		// Token: 0x060084A4 RID: 33956 RVA: 0x00103418 File Offset: 0x00101618
		internal static Exception CreateInvalidCallbackSignature(MethodInfo method)
		{
			return new NotSupportedException("Invalid callback signature in " + method.DeclaringType.FullName + "." + method.Name);
		}

		// Token: 0x170029EB RID: 10731
		// (get) Token: 0x060084A5 RID: 33957 RVA: 0x00103450 File Offset: 0x00101650
		// (set) Token: 0x060084A6 RID: 33958 RVA: 0x00103468 File Offset: 0x00101668
		public MethodInfo BeforeSerialize
		{
			get
			{
				return this.beforeSerialize;
			}
			set
			{
				this.beforeSerialize = this.SanityCheckCallback(this.metaType.Model, value);
			}
		}

		// Token: 0x170029EC RID: 10732
		// (get) Token: 0x060084A7 RID: 33959 RVA: 0x00103484 File Offset: 0x00101684
		// (set) Token: 0x060084A8 RID: 33960 RVA: 0x0010349C File Offset: 0x0010169C
		public MethodInfo BeforeDeserialize
		{
			get
			{
				return this.beforeDeserialize;
			}
			set
			{
				this.beforeDeserialize = this.SanityCheckCallback(this.metaType.Model, value);
			}
		}

		// Token: 0x170029ED RID: 10733
		// (get) Token: 0x060084A9 RID: 33961 RVA: 0x001034B8 File Offset: 0x001016B8
		// (set) Token: 0x060084AA RID: 33962 RVA: 0x001034D0 File Offset: 0x001016D0
		public MethodInfo AfterSerialize
		{
			get
			{
				return this.afterSerialize;
			}
			set
			{
				this.afterSerialize = this.SanityCheckCallback(this.metaType.Model, value);
			}
		}

		// Token: 0x170029EE RID: 10734
		// (get) Token: 0x060084AB RID: 33963 RVA: 0x001034EC File Offset: 0x001016EC
		// (set) Token: 0x060084AC RID: 33964 RVA: 0x00103504 File Offset: 0x00101704
		public MethodInfo AfterDeserialize
		{
			get
			{
				return this.afterDeserialize;
			}
			set
			{
				this.afterDeserialize = this.SanityCheckCallback(this.metaType.Model, value);
			}
		}

		// Token: 0x170029EF RID: 10735
		// (get) Token: 0x060084AD RID: 33965 RVA: 0x00103520 File Offset: 0x00101720
		public bool NonTrivial
		{
			get
			{
				return this.beforeSerialize != null || this.beforeDeserialize != null || this.afterSerialize != null || this.afterDeserialize != null;
			}
		}

		// Token: 0x04002933 RID: 10547
		private readonly MetaType metaType;

		// Token: 0x04002934 RID: 10548
		private MethodInfo beforeSerialize;

		// Token: 0x04002935 RID: 10549
		private MethodInfo afterSerialize;

		// Token: 0x04002936 RID: 10550
		private MethodInfo beforeDeserialize;

		// Token: 0x04002937 RID: 10551
		private MethodInfo afterDeserialize;
	}
}
