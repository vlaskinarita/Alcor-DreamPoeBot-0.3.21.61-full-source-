using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;

namespace DreamPoeBot.WPFLocalizeExtension.TypeConverters;

internal class ThicknessConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		return sourceType == typeof(string);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		Thickness thickness = default(Thickness);
		uint num2 = default(uint);
		while (true)
		{
			double result = 0.0;
			while (true)
			{
				double result2 = 0.0;
				double result3 = 0.0;
				while (true)
				{
					double result4 = 0.0;
					while (true)
					{
						IL_00c6:
						if (value is string)
						{
							while (true)
							{
								IL_00a7:
								string[] array = ((string)value).Split(",".ToCharArray());
								int num = array.Length;
								while (true)
								{
									switch (num)
									{
									case 1:
										goto IL_0102;
									case 2:
										goto IL_0121;
									case 4:
										goto IL_0152;
									case 3:
										goto end_IL_0089;
									}
									int num3 = (int)(num2 * 2113146230) ^ -811987700;
									while (true)
									{
										switch ((num2 = (uint)num3 ^ 0xC7EFAEADu) % 18u)
										{
										case 3u:
											num3 = ((int)num2 * -592014574) ^ -106558333;
											continue;
										case 7u:
											break;
										case 0u:
											goto IL_00a7;
										case 16u:
											goto IL_00c6;
										case 15u:
											goto end_IL_00c6;
										case 4u:
											goto end_IL_00d3;
										case 1u:
										case 2u:
											goto end_IL_00e0;
										case 11u:
											goto IL_0102;
										case 17u:
											goto IL_0114;
										case 9u:
											goto IL_0121;
										case 13u:
											goto IL_0145;
										case 6u:
											goto IL_0152;
										case 8u:
											goto IL_0176;
										case 5u:
											goto IL_0188;
										default:
											goto end_IL_0089;
										}
										break;
									}
									continue;
									IL_0102:
									double.TryParse(array[0], NumberStyles.Any, culture, out result);
									goto IL_0114;
									IL_0114:
									thickness = new Thickness(result);
									break;
									IL_0152:
									double.TryParse(array[0], NumberStyles.Any, culture, out result);
									double.TryParse(array[1], NumberStyles.Any, culture, out result2);
									goto IL_0176;
									IL_0176:
									double.TryParse(array[2], NumberStyles.Any, culture, out result3);
									goto IL_0188;
									IL_0188:
									double.TryParse(array[3], NumberStyles.Any, culture, out result4);
									thickness = new Thickness(result, result2, result3, result4);
									break;
									IL_0121:
									double.TryParse(array[0], NumberStyles.Any, culture, out result);
									double.TryParse(array[1], NumberStyles.Any, culture, out result2);
									goto IL_0145;
									IL_0145:
									thickness = new Thickness(result, result2, result, result2);
									break;
									continue;
									end_IL_0089:
									break;
								}
								break;
							}
						}
						return thickness;
						continue;
						end_IL_00c6:
						break;
					}
					continue;
					end_IL_00d3:
					break;
				}
				continue;
				end_IL_00e0:
				break;
			}
		}
	}
}
