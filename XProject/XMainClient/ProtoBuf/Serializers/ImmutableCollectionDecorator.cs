using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000867 RID: 2151
	internal sealed class ImmutableCollectionDecorator : ListDecorator
	{
		// Token: 0x1700298F RID: 10639
		// (get) Token: 0x060083A9 RID: 33705 RVA: 0x000FFF3C File Offset: 0x000FE13C
		protected override bool RequireAdd
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060083AA RID: 33706 RVA: 0x000FFF50 File Offset: 0x000FE150
		private static Type ResolveIReadOnlyCollection(Type declaredType, Type t)
		{
			foreach (Type type in declaredType.GetInterfaces())
			{
				bool flag = type.IsGenericType && type.Name.StartsWith("IReadOnlyCollection`");
				if (flag)
				{
					bool flag2 = t != null;
					if (flag2)
					{
						Type[] genericArguments = type.GetGenericArguments();
						bool flag3 = genericArguments.Length != 1 && genericArguments[0] != t;
						if (flag3)
						{
							goto IL_68;
						}
					}
					return type;
				}
				IL_68:;
			}
			return null;
		}

		// Token: 0x060083AB RID: 33707 RVA: 0x000FFFD8 File Offset: 0x000FE1D8
		internal static bool IdentifyImmutable(TypeModel model, Type declaredType, out MethodInfo builderFactory, out MethodInfo add, out MethodInfo addRange, out MethodInfo finish)
		{
			MethodInfo methodInfo;
			finish = (methodInfo = null);
			addRange = (methodInfo = methodInfo);
			add = (methodInfo = methodInfo);
			builderFactory = methodInfo;
			bool flag = model == null || declaredType == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !declaredType.IsGenericType;
				if (flag2)
				{
					result = false;
				}
				else
				{
					Type[] genericArguments = declaredType.GetGenericArguments();
					int num = genericArguments.Length;
					Type[] array;
					if (num != 1)
					{
						if (num != 2)
						{
							return false;
						}
						Type type = model.MapType(typeof(KeyValuePair<, >));
						bool flag3 = type == null;
						if (flag3)
						{
							return false;
						}
						type = type.MakeGenericType(genericArguments);
						array = new Type[]
						{
							type
						};
					}
					else
					{
						array = genericArguments;
					}
					bool flag4 = ImmutableCollectionDecorator.ResolveIReadOnlyCollection(declaredType, null) == null;
					if (flag4)
					{
						result = false;
					}
					else
					{
						string text = declaredType.Name;
						int num2 = text.IndexOf('`');
						bool flag5 = num2 <= 0;
						if (flag5)
						{
							result = false;
						}
						else
						{
							text = (declaredType.IsInterface ? text.Substring(1, num2 - 1) : text.Substring(0, num2));
							Type type2 = model.GetType(declaredType.Namespace + "." + text, declaredType.Assembly);
							bool flag6 = type2 == null && text == "ImmutableSet";
							if (flag6)
							{
								type2 = model.GetType(declaredType.Namespace + ".ImmutableHashSet", declaredType.Assembly);
							}
							bool flag7 = type2 == null;
							if (flag7)
							{
								result = false;
							}
							else
							{
								foreach (MethodInfo methodInfo2 in type2.GetMethods())
								{
									bool flag8 = !methodInfo2.IsStatic || methodInfo2.Name != "CreateBuilder" || !methodInfo2.IsGenericMethodDefinition || methodInfo2.GetParameters().Length != 0 || methodInfo2.GetGenericArguments().Length != genericArguments.Length;
									if (!flag8)
									{
										builderFactory = methodInfo2.MakeGenericMethod(genericArguments);
										break;
									}
								}
								Type type3 = model.MapType(typeof(void));
								bool flag9 = builderFactory == null || builderFactory.ReturnType == null || builderFactory.ReturnType == type3;
								if (flag9)
								{
									result = false;
								}
								else
								{
									add = Helpers.GetInstanceMethod(builderFactory.ReturnType, "Add", array);
									bool flag10 = add == null;
									if (flag10)
									{
										result = false;
									}
									else
									{
										finish = Helpers.GetInstanceMethod(builderFactory.ReturnType, "ToImmutable", Helpers.EmptyTypes);
										bool flag11 = finish == null || finish.ReturnType == null || finish.ReturnType == type3;
										if (flag11)
										{
											result = false;
										}
										else
										{
											bool flag12 = finish.ReturnType != declaredType && !Helpers.IsAssignableFrom(declaredType, finish.ReturnType);
											if (flag12)
											{
												result = false;
											}
											else
											{
												addRange = Helpers.GetInstanceMethod(builderFactory.ReturnType, "AddRange", new Type[]
												{
													declaredType
												});
												bool flag13 = addRange == null;
												if (flag13)
												{
													Type type4 = model.MapType(typeof(IEnumerable<>), false);
													bool flag14 = type4 != null;
													if (flag14)
													{
														addRange = Helpers.GetInstanceMethod(builderFactory.ReturnType, "AddRange", new Type[]
														{
															type4.MakeGenericType(array)
														});
													}
												}
												result = true;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060083AC RID: 33708 RVA: 0x00100324 File Offset: 0x000FE524
		internal ImmutableCollectionDecorator(TypeModel model, Type declaredType, Type concreteType, IProtoSerializer tail, int fieldNumber, bool writePacked, WireType packedWireType, bool returnList, bool overwriteList, bool supportNull, MethodInfo builderFactory, MethodInfo add, MethodInfo addRange, MethodInfo finish) : base(model, declaredType, concreteType, tail, fieldNumber, writePacked, packedWireType, returnList, overwriteList, supportNull)
		{
			this.builderFactory = builderFactory;
			this.add = add;
			this.addRange = addRange;
			this.finish = finish;
		}

		// Token: 0x060083AD RID: 33709 RVA: 0x0010036C File Offset: 0x000FE56C
		public override object Read(object value, ProtoReader source)
		{
			object obj = this.builderFactory.Invoke(null, null);
			int fieldNumber = source.FieldNumber;
			object[] s_argsRead = ProtoDecoratorBase.s_argsRead;
			bool flag = base.AppendToCollection && value != null && ((IList)value).Count != 0;
			if (flag)
			{
				bool flag2 = this.addRange != null;
				if (flag2)
				{
					s_argsRead[0] = value;
					this.addRange.Invoke(obj, s_argsRead);
				}
				else
				{
					foreach (object obj2 in ((IList)value))
					{
						s_argsRead[0] = obj2;
						this.add.Invoke(obj, s_argsRead);
					}
				}
			}
			bool flag3 = this.packedWireType != WireType.None && source.WireType == WireType.String;
			if (flag3)
			{
				SubItemToken token = ProtoReader.StartSubItem(source);
				while (ProtoReader.HasSubValue(this.packedWireType, source))
				{
					s_argsRead[0] = this.Tail.Read(null, source);
					this.add.Invoke(obj, s_argsRead);
				}
				ProtoReader.EndSubItem(token, source);
			}
			else
			{
				do
				{
					s_argsRead[0] = this.Tail.Read(null, source);
					this.add.Invoke(obj, s_argsRead);
				}
				while (source.TryReadFieldHeader(fieldNumber));
			}
			return this.finish.Invoke(obj, null);
		}

		// Token: 0x040028E8 RID: 10472
		private readonly MethodInfo builderFactory;

		// Token: 0x040028E9 RID: 10473
		private readonly MethodInfo add;

		// Token: 0x040028EA RID: 10474
		private readonly MethodInfo addRange;

		// Token: 0x040028EB RID: 10475
		private readonly MethodInfo finish;
	}
}
