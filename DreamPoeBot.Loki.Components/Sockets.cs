using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Sockets : Component
{
	public class SocketedGem
	{
		public int SocketIndex;

		public Entity GemEntity;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Struct212
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		[UnsafeValueType]
		public struct Struct213
		{
			public int int_0;

			public int int_1;

			public int int_2;

			public int int_3;

			public int int_4;

			public int int_5;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		[UnsafeValueType]
		public struct Struct214
		{
			public long long_0;

			public long long_1;

			public long long_2;

			public long long_3;

			public long long_4;

			public long long_5;
		}

		private Struct253 struct253_0;

		private IntPtr intptr_0;

		public Struct213 struct213_Colors;

		public Struct214 struct214_Gems;

		public NativeVector nativeVector_SocketLinks;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;
	}

	private PerFrameCachedValue<Struct212> perFrameCachedValue_1;

	public int LargestLinkSize
	{
		get
		{
			if (base.Address == 0L)
			{
				return 0;
			}
			long first = Struct212_0.nativeVector_SocketLinks.First;
			long last = Struct212_0.nativeVector_SocketLinks.Last;
			long num = last - first;
			if (num > 0L && num <= 6L)
			{
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					int num3 = base.M.ReadByte(first + i);
					if (num3 > num2)
					{
						num2 = num3;
					}
				}
				return num2;
			}
			return 0;
		}
	}

	public List<int[]> Links
	{
		get
		{
			List<int[]> list = new List<int[]>();
			if (base.Address != 0L)
			{
				long first = Struct212_0.nativeVector_SocketLinks.First;
				long last = Struct212_0.nativeVector_SocketLinks.Last;
				long num = last - first;
				if (num > 0L && num <= 6L)
				{
					int num2 = 0;
					List<int> socketList = SocketList;
					for (int i = 0; i < num; i++)
					{
						int num3 = base.M.ReadByte(first + i);
						int[] array = new int[num3];
						for (int j = 0; j < num3; j++)
						{
							array[j] = socketList[j + num2];
						}
						list.Add(array);
						num2 += num3;
					}
					return list;
				}
				return list;
			}
			return list;
		}
	}

	public List<int> SocketList
	{
		get
		{
			List<int> list = new List<int>();
			if (base.Address != 0L)
			{
				Struct212.Struct213 struct213_Colors = Struct212_0.struct213_Colors;
				if (struct213_Colors.int_0 >= 1 && struct213_Colors.int_0 <= 5)
				{
					list.Add(struct213_Colors.int_0);
				}
				if (struct213_Colors.int_1 >= 1 && struct213_Colors.int_1 <= 5)
				{
					list.Add(struct213_Colors.int_1);
				}
				if (struct213_Colors.int_2 >= 1 && struct213_Colors.int_2 <= 5)
				{
					list.Add(struct213_Colors.int_2);
				}
				if (struct213_Colors.int_3 >= 1 && struct213_Colors.int_3 <= 5)
				{
					list.Add(struct213_Colors.int_3);
				}
				if (struct213_Colors.int_4 >= 1 && struct213_Colors.int_4 <= 5)
				{
					list.Add(struct213_Colors.int_4);
				}
				if (struct213_Colors.int_5 >= 1 && struct213_Colors.int_5 <= 5)
				{
					list.Add(struct213_Colors.int_5);
				}
				return list;
			}
			return list;
		}
	}

	public int NumberOfSockets => SocketList.Count;

	public bool IsRGB
	{
		get
		{
			if (base.Address != 0L)
			{
				return Links.Any((int[] current) => current.Length >= 3 && current.Contains(1) && current.Contains(2) && current.Contains(3));
			}
			return false;
		}
	}

	public List<string> SocketGroup
	{
		get
		{
			List<string> list = new List<string>();
			using List<int[]>.Enumerator enumerator = Links.GetEnumerator();
			uint num3 = default(uint);
			while (enumerator.MoveNext())
			{
				while (true)
				{
					int[] current = enumerator.Current;
					while (true)
					{
						StringBuilder stringBuilder = new StringBuilder();
						while (true)
						{
							int[] array = current;
							while (true)
							{
								int num = 0;
								while (true)
								{
									if (num < array.Length)
									{
										while (true)
										{
											int num2 = array[num];
											while (true)
											{
												switch (num2)
												{
												case 1:
													goto IL_00c7;
												case 2:
													goto IL_00d5;
												case 3:
													goto IL_00e3;
												case 4:
													goto IL_00f1;
												case 5:
													goto IL_00ff;
												}
												int num4 = ((int)num3 * -1203243409) ^ 0x6AE567B9;
												while (true)
												{
													switch ((num3 = (uint)num4 ^ 0x8B8E869Bu) % 20u)
													{
													case 3u:
														num4 = (int)((num3 * 237010329) ^ 0x28199187);
														continue;
													case 19u:
														break;
													case 10u:
														goto end_IL_009c;
													case 15u:
														goto IL_00c7;
													case 11u:
														goto IL_00d5;
													case 8u:
														goto IL_00e3;
													case 0u:
														goto IL_00f1;
													case 6u:
														goto IL_00ff;
													case 1u:
													case 7u:
														goto IL_0108;
													case 13u:
													case 18u:
														goto end_IL_00be;
													case 14u:
														goto end_IL_010e;
													case 9u:
														goto end_IL_0118;
													case 5u:
														goto end_IL_011d;
													case 2u:
													case 17u:
														goto end_IL_0122;
													case 4u:
														goto IL_0134;
													case 12u:
														goto end_IL_012a;
													default:
														return list;
													case 16u:
														return list;
													}
													break;
												}
												continue;
												IL_00c7:
												stringBuilder.Append("R");
												goto IL_0108;
												IL_0108:
												num++;
												goto end_IL_00be;
												IL_00ff:
												stringBuilder.Append('A');
												goto IL_0108;
												IL_00f1:
												stringBuilder.Append("W");
												goto IL_0108;
												IL_00e3:
												stringBuilder.Append("B");
												goto IL_0108;
												IL_00d5:
												stringBuilder.Append("G");
												goto IL_0108;
												continue;
												end_IL_009c:
												break;
											}
											continue;
											end_IL_00be:
											break;
										}
										continue;
									}
									goto IL_0134;
									IL_0134:
									list.Add(stringBuilder.ToString());
									goto end_IL_012a;
									continue;
									end_IL_010e:
									break;
								}
								continue;
								end_IL_0118:
								break;
							}
							continue;
							end_IL_011d:
							break;
						}
						continue;
						end_IL_0122:
						break;
					}
					continue;
					end_IL_012a:
					break;
				}
			}
			return list;
		}
	}

	public List<SocketedGem> SocketedGems
	{
		get
		{
			List<SocketedGem> list = new List<SocketedGem>();
			Struct212.Struct214 struct214_Gems = Struct212_0.struct214_Gems;
			if (struct214_Gems.long_0 != 0L)
			{
				list.Add(new SocketedGem
				{
					SocketIndex = 0,
					GemEntity = ReadObject<EntityWrapper>(struct214_Gems.long_0)
				});
			}
			if (struct214_Gems.long_1 != 0L)
			{
				list.Add(new SocketedGem
				{
					SocketIndex = 1,
					GemEntity = ReadObject<EntityWrapper>(struct214_Gems.long_1)
				});
			}
			if (struct214_Gems.long_2 != 0L)
			{
				list.Add(new SocketedGem
				{
					SocketIndex = 2,
					GemEntity = ReadObject<EntityWrapper>(struct214_Gems.long_2)
				});
			}
			if (struct214_Gems.long_3 != 0L)
			{
				list.Add(new SocketedGem
				{
					SocketIndex = 3,
					GemEntity = ReadObject<EntityWrapper>(struct214_Gems.long_3)
				});
			}
			if (struct214_Gems.long_4 != 0L)
			{
				list.Add(new SocketedGem
				{
					SocketIndex = 4,
					GemEntity = ReadObject<EntityWrapper>(struct214_Gems.long_4)
				});
			}
			if (struct214_Gems.long_5 != 0L)
			{
				list.Add(new SocketedGem
				{
					SocketIndex = 5,
					GemEntity = ReadObject<EntityWrapper>(struct214_Gems.long_5)
				});
			}
			return list;
		}
	}

	public string DisplayString
	{
		get
		{
			SocketColor[] socketColors = SocketColors;
			if (socketColors.All((SocketColor x) => x == SocketColor.None))
			{
				return "<None>";
			}
			byte[] socketLinks = SocketLinks;
			int num = 0;
			string text = "";
			byte[] array = socketLinks;
			foreach (byte b in array)
			{
				for (int j = 0; j < b; j++)
				{
					text += socketColors[num++].ToString()[0];
					text = ((b <= 1 || j >= b - 1) ? (text + " ") : (text + "-"));
				}
			}
			return text;
		}
	}

	public Item[] Gems
	{
		get
		{
			Item[] array = new Item[6];
			for (int i = 0; i < 6; i++)
			{
				long num = 0L;
				switch (i)
				{
				case 0:
					num = Struct212_0.struct214_Gems.long_0;
					break;
				case 1:
					num = Struct212_0.struct214_Gems.long_1;
					break;
				case 2:
					num = Struct212_0.struct214_Gems.long_2;
					break;
				case 3:
					num = Struct212_0.struct214_Gems.long_3;
					break;
				case 4:
					num = Struct212_0.struct214_Gems.long_4;
					break;
				case 5:
					num = Struct212_0.struct214_Gems.long_5;
					break;
				}
				if (num != 0L)
				{
					array[i] = new Item(num, -(i + 1));
				}
			}
			return array;
		}
	}

	public SocketColor[] SocketColors
	{
		get
		{
			SocketColor[] array = new SocketColor[6];
			uint num2 = default(uint);
			while (true)
			{
				int num = 0;
				while (true)
				{
					if (num < 6)
					{
						while (true)
						{
							SocketColor socketColor = SocketColor.None;
							while (true)
							{
								switch (num)
								{
								default:
								{
									int num3 = (int)(num2 * 2052408819) ^ -1314770453;
									while (true)
									{
										switch ((num2 = (uint)num3 ^ 0x47A377A9u) % 16u)
										{
										case 5u:
											num3 = (int)(num2 * 53111077) ^ -1052366661;
											continue;
										case 13u:
											break;
										case 0u:
											goto end_IL_007d;
										case 7u:
											goto IL_00a4;
										case 3u:
											goto IL_00b8;
										case 2u:
											goto IL_00cc;
										case 1u:
											goto IL_00e0;
										case 12u:
											goto IL_00f4;
										case 4u:
											goto IL_0108;
										case 10u:
										case 11u:
											goto IL_011a;
										case 6u:
											goto IL_011e;
										case 8u:
											goto end_IL_00a0;
										case 14u:
										case 15u:
											goto end_IL_0122;
										default:
											goto IL_012f;
										}
										break;
									}
									break;
								}
								case 0:
									goto IL_00a4;
								case 1:
									goto IL_00b8;
								case 2:
									goto IL_00cc;
								case 3:
									goto IL_00e0;
								case 4:
									goto IL_00f4;
								case 5:
									goto IL_0108;
									IL_011e:
									num++;
									goto end_IL_00a0;
									IL_0108:
									socketColor = (SocketColor)Struct212_0.struct213_Colors.int_5;
									goto IL_011a;
									IL_00f4:
									socketColor = (SocketColor)Struct212_0.struct213_Colors.int_4;
									goto IL_011a;
									IL_00e0:
									socketColor = (SocketColor)Struct212_0.struct213_Colors.int_3;
									goto IL_011a;
									IL_00cc:
									socketColor = (SocketColor)Struct212_0.struct213_Colors.int_2;
									goto IL_011a;
									IL_00b8:
									socketColor = (SocketColor)Struct212_0.struct213_Colors.int_1;
									goto IL_011a;
									IL_00a4:
									socketColor = (SocketColor)Struct212_0.struct213_Colors.int_0;
									goto IL_011a;
									IL_011a:
									array[num] = socketColor;
									goto IL_011e;
								}
								continue;
								end_IL_007d:
								break;
							}
							continue;
							end_IL_00a0:
							break;
						}
						continue;
					}
					goto IL_012f;
					IL_012f:
					return array;
					continue;
					end_IL_0122:
					break;
				}
			}
		}
	}

	public List<Item[]> SocketedSkillGemsByLinks
	{
		get
		{
			List<Item[]> list = new List<Item[]>();
			byte[] socketLinks = SocketLinks;
			int num = 0;
			byte[] array = socketLinks;
			foreach (byte b in array)
			{
				if (b != 0)
				{
					Item[] array2 = new Item[b];
					for (int j = 0; j < b; j++)
					{
						array2[j] = Gems[num++];
					}
					list.Add(array2);
				}
			}
			return list;
		}
	}

	public byte[] SocketLinks
	{
		get
		{
			byte[] array = new byte[6];
			List<byte> list = Containers.StdByteVector<byte>(Struct212_0.nativeVector_SocketLinks);
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = list[i];
			}
			return array;
		}
	}

	internal Struct212 Struct212_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct212>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	private Struct212 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct212>(base.Address);
	}
}
