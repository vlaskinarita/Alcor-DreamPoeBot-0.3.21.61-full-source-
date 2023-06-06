using System;
using System.Collections.Generic;
using System.IO;

namespace DreamPoeBot.Structures.ns16;

internal class Class266
{
	internal class Class267
	{
		private const uint uint_0 = 1540483477u;

		private const int int_0 = 24;

		public unsafe static uint smethod_0(byte[] byte_0, uint uint_1 = 3314489979u)
		{
			//The blocks IL_0117, IL_011d, IL_0123, IL_0129, IL_0174, IL_0183 are reachable both inside and outside the pinned region starting at IL_010e. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			int num = byte_0.Length;
			if (num != 0)
			{
				uint num2 = uint_1 ^ (uint)num;
				int num3 = num & 3;
				int num4 = num >> 2;
				uint num5 = default(uint);
				uint num7 = default(uint);
				while (true)
				{
					fixed (byte* ptr = &byte_0[0])
					{
						while (true)
						{
							IL_0101:
							uint* ptr2 = (uint*)ptr;
							while (true)
							{
								IL_00fc:
								if (num4 == 0)
								{
									while (true)
									{
										IL_00a9:
										switch (num3)
										{
										case 1:
											goto IL_012e;
										case 2:
											goto IL_013e;
										case 3:
											goto IL_014f;
										}
										int num6 = (int)(num5 * 1710878203) ^ -1736296533;
										while (true)
										{
											switch ((num5 = (uint)num6 ^ 0x9C95A979u) % 27u)
											{
											case 7u:
												break;
											case 14u:
												num6 = ((int)num5 * -178789946) ^ -489652128;
												continue;
											case 2u:
												goto IL_00a9;
											case 20u:
												goto IL_00c2;
											case 10u:
												goto IL_00c7;
											case 6u:
												goto IL_00d1;
											case 0u:
												goto IL_00e5;
											case 12u:
												goto IL_00ed;
											case 5u:
											case 23u:
												goto IL_00fc;
											case 25u:
												goto IL_0101;
											case 21u:
												num4 = num >> 2;
												break;
											case 24u:
												num3 = num & 3;
												goto case 21u;
											case 4u:
												num2 = uint_1 ^ (uint)num;
												goto case 24u;
											case 22u:
											case 26u:
												if (num != 0)
												{
													goto case 4u;
												}
												goto case 19u;
											case 16u:
												goto IL_012e;
											case 13u:
												goto IL_013e;
											case 17u:
												goto IL_0145;
											case 15u:
												goto IL_014f;
											case 3u:
												goto IL_0156;
											case 9u:
												goto IL_0161;
											case 1u:
											case 8u:
											case 11u:
												goto end_IL_0107;
											default:
												num2 *= 1540483477;
												return num2 ^ (num2 >> 15);
											case 19u:
												return 0u;
											}
											break;
										}
										break;
										IL_0145:
										num2 *= 1540483477;
										goto end_IL_0107;
										IL_012e:
										num2 ^= *(byte*)ptr2;
										num2 *= 1540483477;
										goto end_IL_0107;
										IL_014f:
										num2 ^= (ushort)(*ptr2);
										goto IL_0156;
										IL_0156:
										num2 ^= (uint)(((byte*)ptr2)[2] << 16);
										goto IL_0161;
										IL_0161:
										num2 *= 1540483477;
										goto end_IL_0107;
										IL_013e:
										num2 ^= (ushort)(*ptr2);
										goto IL_0145;
									}
									break;
								}
								goto IL_00c2;
								IL_00ed:
								num2 ^= num7;
								num4--;
								ptr2++;
								continue;
								IL_00c2:
								num7 = *ptr2;
								goto IL_00c7;
								IL_00c7:
								num7 *= 1540483477;
								goto IL_00d1;
								IL_00d1:
								num7 ^= num7 >> 24;
								num7 *= 1540483477;
								goto IL_00e5;
								IL_00e5:
								num2 *= 1540483477;
								goto IL_00ed;
							}
							break;
						}
					}
					continue;
					end_IL_0107:
					break;
				}
				num2 ^= num2 >> 13;
				num2 *= 1540483477;
				return num2 ^ (num2 >> 15);
			}
			return 0u;
		}
	}

	internal Struct124 struct124_0;

	internal Struct125 struct125_0;

	private IntPtr[] intptr_0;

	public const string string_0 = "poe-3.3.1.2-r1 B";

	public const uint uint_0 = 1259488902u;

	public const uint uint_1 = 2672439318u;

	public const string string_1 = "poe_cis-2.2.2.6 B";

	public const uint uint_2 = 2127794603u;

	public const string string_2 = "poe_sg-2.2.2.5 B";

	public const uint uint_3 = 2429995333u;

	public const string string_3 = "poe_tw-2.2.2.4 B";

	public const uint uint_4 = 4195082080u;

	private T[] method_2<T>(ArraySegment<T> arraySegment_0) where T : struct
	{
		List<T> list = new List<T>();
		for (int i = arraySegment_0.Offset; i < arraySegment_0.Offset + arraySegment_0.Count; i++)
		{
			list.Add(arraySegment_0.Array[i]);
		}
		return list.ToArray();
	}

	private static uint smethod_0(uint uint_5, byte byte_0)
	{
		uint num = (uint)((byte_0 << 24) | (byte_0 << 16) | (byte_0 << 8) | byte_0);
		return uint_5 ^ num;
	}

	public void method_3()
	{
		intptr_0 = null;
		struct124_0 = default(Struct124);
		struct125_0 = default(Struct125);
	}

	public static uint smethod_1(string string_4)
	{
		return Class267.smethod_0(File.ReadAllBytes(string_4));
	}

	public void method_4(IntPtr[] intptr_1, out ArraySegment<IntPtr> arraySegment_0, out ArraySegment<IntPtr> arraySegment_1)
	{
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 53);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 53, 134);
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 53);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 53, 134);
	}

	public void method_5(IntPtr[] intptr_1, out ArraySegment<IntPtr> arraySegment_0, out ArraySegment<IntPtr> arraySegment_1)
	{
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 35);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 35, 102);
	}

	public void method_6(IntPtr[] intptr_1, out ArraySegment<IntPtr> arraySegment_0, out ArraySegment<IntPtr> arraySegment_1)
	{
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 35);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 35, 102);
	}

	public void method_7(IntPtr[] intptr_1, out ArraySegment<IntPtr> arraySegment_0, out ArraySegment<IntPtr> arraySegment_1)
	{
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 35);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 35, 102);
	}
}
